using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface ISVTPTaskRepository
    {
        Task<IEnumerable<SVTPTask>> GetSVTPTasksAsync();
        Task<SVTPTask> GetSVTPTaskAsync(Guid svtpId);
        Task<IEnumerable<SVTPTask>> GetSVTPTaskByProjectAsync(string project);
        void AddSVTPTask(SVTPTask svtpTask);
        void UpdateSVTPTask(SVTPTask svtpTask);
        void DeleteSVTPTask(SVTPTask svtpTask);
        Task<bool> IsSVTPTaskExistAsync(Guid svtpId);
    }
}
