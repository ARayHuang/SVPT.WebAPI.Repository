using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface ISVTPTaskItemTestResultRepository
    {
        Task<IEnumerable<TaskItemTestResult>> GetTaskItemTestResultsAsync(Guid taskItemId);
        Task<TaskItemTestResult> GetTaskItemTestResultAsync(Guid id);
        Task<TaskItemTestResult> GetTaskItemTestResultAsync(Guid taskItemId, string item, string vendor, string extraKey);
        void AddTaskItemTestResult(Guid taskItemId, TaskItemTestResult taskItemTestResult);
        void UpdateTaskItemTestResult(TaskItemTestResult taskItemTestResult);
        Task DeleteTaskItemTestResult(Guid testResultId);
    }
}
