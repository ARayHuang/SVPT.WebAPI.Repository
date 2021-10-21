using SVPT.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Services.Contracts
{
    public interface ITaskItemService
    {
        Task<TaskItemReturnModel> GetTaskItemAsync (Guid taskItemId);
        Task<IEnumerable<TaskItemTestResultReturnModel>> GetTestResultsAsync(Guid taskItemId);
    }
}
