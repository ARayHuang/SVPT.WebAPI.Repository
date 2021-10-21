using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Helper;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository
{
    public class SVTPTaskItemRepository : DbRepositoryBase<TaskItem>, ISVTPTaskItemRepository
    {
        public SVTPTaskItemRepository(SVTPDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync(Guid svtpTaskId)
        {
            if (svtpTaskId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return await base.GetByConditionIncludeAsync(a => a.TaskId == svtpTaskId, i => i.SVTPTask, false);
        }

        public async Task<TaskItem> GetTaskItemAsync(Guid taskItemId)
        {
            if (taskItemId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return await base.GetSingleByConditionAsync(a => a.Id == taskItemId);
        }

        public async Task<TaskItem> GetTaskItemAsync(string version, string project, string phase, string item, string subItem)
        {            
            Expression<Func<TaskItem, bool>> expression = (x => x.SVTPTask.Project == project
                                    && x.SVTPTask.Phase == phase
                                    && x.Item == item);

            if (!string.IsNullOrWhiteSpace(subItem))
            {
                Expression<Func<TaskItem, bool>> expression1 = (x => x.SubItem == subItem);
                expression = LinqExpressionHelper.And<TaskItem>(expression, expression1);
            }

            var list = await base.SVTPDbContext.tblTaskItem.Include(t => t.SVTPTask).FirstOrDefaultAsync(expression);

            return list;
        }

        public void AddTaskItem(Guid svtpTaskId, TaskItem taskItem)
        {
            if (svtpTaskId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            if (taskItem == null)
            {
                throw new ArgumentNullException(nameof(taskItem));
            }

            taskItem.Id = Guid.NewGuid();
            taskItem.TaskId = svtpTaskId;
            //TODO: use MSSQL auto Datetime
            taskItem.CreatedAt = DateTime.Now;
            taskItem.UpdatedAt = DateTime.Now;

            base.Create(taskItem);
        }

        public void AddTaskItems(IEnumerable<TaskItem> taskItems)
        {
            if (taskItems == null)
            {
                throw new ArgumentNullException();
            }

            base.CreateBulk(taskItems);
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            base.Update(taskItem);
        }

        public void DeleteTaskItem(TaskItem taskItem)
        {
            if (taskItem == null)
            {
                throw new ArgumentNullException(nameof(taskItem));
            }

            base.Delete(taskItem);
        }

        public async Task DeleteTaskItemsAsync(ICollection<Guid> taskItemIds)
        {
            if (taskItemIds == null)
            {
                throw new ArgumentNullException(nameof(taskItemIds));
            }

            var matchData = await base.GetByConditionAsync(x => taskItemIds.Contains(x.Id));

            base.DeleteBulk(matchData);
        }

        public async Task<bool> IsTaskItemExistAsync(Guid itemId)
        {
            if (itemId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(itemId));
            }

            return await base.IsEntityExistAsync(x => x.Id == itemId);
        }
    }
}
