using Microsoft.EntityFrameworkCore;
using SVPT.WebAPI.Repository.Contracts;
using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository
{
    public class SVTPTaskItemTestResultRepository : DbRepositoryBase<TaskItemTestResult>, ISVTPTaskItemTestResultRepository
    {
        public SVTPTaskItemTestResultRepository(SVTPDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<TaskItemTestResult>> GetTaskItemTestResultsAsync(Guid taskItemId)
        {
            if (taskItemId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return await base.GetByConditionAsync(a => a.TaskItemId == taskItemId);
        }

        public async Task<TaskItemTestResult> GetTaskItemTestResultAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await base.GetSingleByConditionAsync(x => x.Id == id);
        }

        public async Task<TaskItemTestResult> GetTaskItemTestResultAsync(Guid taskItemId, string item, string vendor, string extraKey)
        {
            if (taskItemId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(taskItemId));
            }

            return await base.GetSingleByConditionAsync(x => x.TaskItemId == taskItemId
                                                            && x.Item == item
                                                            && x.Vendor == vendor
                                                            && x.ExtraKey == extraKey);
        }

        public void AddTaskItemTestResult(Guid taskItemId, TaskItemTestResult taskItemTestResult)
        {
            if (taskItemId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            if (taskItemTestResult == null)
            {
                throw new ArgumentNullException(nameof(taskItemTestResult));
            }

            taskItemTestResult.Id = Guid.NewGuid();
            taskItemTestResult.TaskItemId = taskItemId;

            taskItemTestResult.CreatedAt = DateTime.Now;
            taskItemTestResult.UpdatedAt = DateTime.Now;

            base.Create(taskItemTestResult);
        }

        public void UpdateTaskItemTestResult(TaskItemTestResult taskItemTestResult)
        {
            base.Update(taskItemTestResult);
        }

        public async Task DeleteTaskItemTestResult(Guid testResultId)
        {
            if (testResultId == null)
            {
                throw new ArgumentNullException(nameof(testResultId));
            }

            var matchData = await base.GetSingleByConditionAsync(x => x.Id == testResultId);

            base.Delete(matchData);
        }
    }
}
