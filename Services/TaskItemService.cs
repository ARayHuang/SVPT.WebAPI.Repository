using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Services.Contracts;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly IDbRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TaskItemService(
            IDbRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TaskItemReturnModel> GetTaskItemAsync(Guid taskItemId)
        {
            var taskItem = await _repositoryManager.SVTPTaskItem.GetTaskItemAsync(taskItemId);
            if (taskItem == null)
            {
                return null;
            }

            return _mapper.Map<TaskItemReturnModel>(taskItem);
        }

        public async Task<IEnumerable<TaskItemTestResultReturnModel>> GetTestResultsAsync(Guid taskItemId)
        {
            if (!await _repositoryManager.SVTPTaskItem.IsTaskItemExistAsync(taskItemId))
            {
                throw new ArgumentNullException(nameof(taskItemId));
            }

            var taskItemTestResults = await _repositoryManager.SVTPTaskItemTestResult.GetTaskItemTestResultsAsync(taskItemId);

            return _mapper.Map<IEnumerable<TaskItemTestResultReturnModel>>(taskItemTestResults);
        }
    }
}
