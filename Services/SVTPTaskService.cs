using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Helper;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Services.Contracts;
using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services
{
    public class SVTPTaskService : ISVTPTaskService
    {
        private readonly IDbRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SVTPTaskService(
            IDbRepositoryManager repositoryManager,
            IMapper mapper
        )
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SVTPTaskReturnModel>> GetSVTPTasksAsync()
        {
            var svtpTasks = await _repositoryManager.SVTPTask.GetSVTPTasksAsync();

            return _mapper.Map<IEnumerable<SVTPTaskReturnModel>>(svtpTasks);
        }

        public async Task<SVTPTaskReturnModel> GetSVTPTaskAsync(Guid svtpId)
        {
            var svtpTask = await _repositoryManager.SVTPTask.GetSVTPTaskAsync(svtpId);
            if (svtpTask == null)
            {
                return null;
            }

            return _mapper.Map<SVTPTaskReturnModel>(svtpTask);
        }

        public async Task<IEnumerable<SVTPTaskReturnModel>> AddSVTPTaskAsync(SVTPTaskModel svtpTask)
        {
            var svtpTaskEntity = _mapper.Map<SVTPTask>(svtpTask);

            foreach (var phase in svtpTask.Phases)
            {
                var newTask = ObjectCloneHelper.Clone<SVTPTask>(svtpTaskEntity);

                newTask.Phase = phase;

                _repositoryManager.SVTPTask.AddSVTPTask(newTask);
            }
            await _repositoryManager.SaveAsync();

            var svtpTasksFromNewProject = await _repositoryManager.SVTPTask.GetSVTPTaskByProjectAsync(svtpTask.Project);
            var svtpTaskReturnModels = _mapper.Map<IEnumerable<SVTPTaskReturnModel>>(svtpTasksFromNewProject);

            await AddTaskItemsFromTemplate(svtpTaskReturnModels.Select(x => x.Id).ToList());

            await _repositoryManager.SaveAsync();

            return svtpTaskReturnModels;
        }

        private async Task AddTaskItemsFromTemplate(IEnumerable<Guid> svtpTaskIds)
        {
            if (svtpTaskIds == null)
            {
                throw new ArgumentNullException();
            }

            var svtpTemplateItems = await _repositoryManager.SVTPTemplateItem.GetSVTPTemplateItemFromLatestVersionAsync();
            var taskItems = new List<TaskItem>();

            foreach (var id in svtpTaskIds)
            {
                foreach (var svtpTemplateItem in svtpTemplateItems)
                {
                    var taskItem = _mapper.Map<TaskItem>(svtpTemplateItem);
                    taskItem.Id = Guid.NewGuid();
                    taskItem.TaskId = id;
                    taskItem.CreatedAt = DateTime.Now;
                    taskItem.UpdatedAt = DateTime.Now;

                    taskItems.Add(taskItem);
                }
            }

            _repositoryManager.SVTPTaskItem.AddTaskItems(taskItems);
        }

        public async Task<IEnumerable<TaskItemReturnModel>> GetTaskItemsAsync(Guid taskId)
        {
            if (!await _repositoryManager.SVTPTask.IsSVTPTaskExistAsync(taskId))
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            var taskItems = await _repositoryManager.SVTPTaskItem.GetTaskItemsAsync(taskId);

            return _mapper.Map<IEnumerable<TaskItemReturnModel>>(taskItems);
        }
        public async Task<IEnumerable<TaskItemReturnModel>> AddTaskItemsAsync(Guid taskId, ICollection<Guid> itemTemplateIds)
        {
            if (!await _repositoryManager.SVTPTask.IsSVTPTaskExistAsync(taskId))
            {
                return null;
            }

            var svtpTemplateItems = await _repositoryManager.SVTPTemplateItem.GetSVTPTemplateItemFromLatestVersionAsync();

            var matchTemplateItems = svtpTemplateItems
                .Where(x => itemTemplateIds.Contains(x.Id)).ToList();

            var taskItems = new List<TaskItem>();
            foreach (var item in matchTemplateItems)
            {
                var taskItem = _mapper.Map<TaskItem>(item);
                taskItem.Id = Guid.NewGuid();
                taskItem.TaskId = taskId;
                taskItem.CreatedAt = DateTime.Now;
                taskItem.UpdatedAt = DateTime.Now;

                taskItems.Add(taskItem);
            }

            _repositoryManager.SVTPTaskItem.AddTaskItems(taskItems);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<IEnumerable<TaskItemReturnModel>>(taskItems);
        }

        public async Task DeleteTaskItems(Guid taskId, ICollection<Guid> taskItemIds)
        {
            if (!await _repositoryManager.SVTPTask.IsSVTPTaskExistAsync(taskId))
            {
                throw new ArgumentNullException(nameof(taskId));
            }

            await _repositoryManager.SVTPTaskItem.DeleteTaskItemsAsync(taskItemIds);
            await _repositoryManager.SaveAsync();
        }

        //public void UpdateSVTPTask(SVTPTaskModel svtpTask)
        //{
        //    _svtpDbContext.Instance.Entry(svtpTask).State = EntityState.Modified;
        //}

        //public void DeleteSVTPTask(SVTPTaskModel svtpTask)
        //{
        //    if (svtpTask == null)
        //    {
        //        throw new ArgumentNullException(nameof(svtpTask));
        //    }

        //    _svtpDbContext.tblSVTPTask.Remove(svtpTask);
        //}
    }
}
