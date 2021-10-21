using SVPT.WebAPI.Models;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services.Contracts
{
    public interface ISVTPTaskService
    {
        Task<IEnumerable<SVTPTaskReturnModel>> GetSVTPTasksAsync();
        Task<SVTPTaskReturnModel> GetSVTPTaskAsync(Guid svtpId);
        Task<IEnumerable<SVTPTaskReturnModel>> AddSVTPTaskAsync(SVTPTaskModel svtpTask);
        Task<IEnumerable<TaskItemReturnModel>> GetTaskItemsAsync(Guid taskId);
        Task<IEnumerable<TaskItemReturnModel>> AddTaskItemsAsync(Guid taskId, ICollection<Guid> itemTemplateIds);
        Task DeleteTaskItems(Guid taskId, ICollection<Guid> taskItemIds);
        //Task<SVTPTaskReturnModel> UpdateSVTPTask(SVTPTaskModel svtpTask);
        //void DeleteSVTPTask(SVTPTaskModel svtpTask);
    }
}
