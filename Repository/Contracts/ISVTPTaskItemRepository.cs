using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface ISVTPTaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetTaskItemsAsync(Guid svtpTaskId);
        Task<TaskItem> GetTaskItemAsync(Guid taskItemId);
        Task<TaskItem> GetTaskItemAsync(string version, string project, string phase, string item, string subItem);
        void AddTaskItem(Guid svtpTaskId, TaskItem taskItem);
        void AddTaskItems(IEnumerable<TaskItem> taskItems);
        void UpdateTaskItem(TaskItem taskItem);
        void DeleteTaskItem(TaskItem taskItem);
        Task DeleteTaskItemsAsync(ICollection<Guid> taskItemIds);
        Task<bool> IsTaskItemExistAsync(Guid itemId);
    }
}
