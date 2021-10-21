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
    public class SVTPTaskRepository : DbRepositoryBase<SVTPTask>, ISVTPTaskRepository
    {
        private readonly SVTPDbContext _svtpDbContext;

        public SVTPTaskRepository(SVTPDbContext context)
            : base(context)
        {
            _svtpDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SVTPTask>> GetSVTPTasksAsync()
        {
            return await base.GetAllAsync(trackChanges: false);
        }

        public async Task<SVTPTask> GetSVTPTaskAsync(Guid svtpId)
        {
            return await base.GetSingleByConditionAsync(x => x.Id == svtpId, trackChanges: false);
        }

        public async Task<IEnumerable<SVTPTask>> GetSVTPTaskByProjectAsync(string project)
        {
            if (string.IsNullOrEmpty(project))
            {
                throw new ArgumentNullException(nameof(project));
            }

            return await base.GetByConditionAsync(x => x.Project == project, trackChanges: false);
        }

        public void AddSVTPTask(SVTPTask svtpTask)
        {
            if (svtpTask == null)
            {
                throw new ArgumentNullException(nameof(svtpTask));
            }

            svtpTask.Id = Guid.NewGuid();
            svtpTask.CreatedAt = DateTime.Now;
            svtpTask.UpdatedAt = DateTime.Now;

            if (svtpTask.TaskNotifies != null)
            {
                foreach (var notifies in svtpTask.TaskNotifies)
                {
                    notifies.Id = Guid.NewGuid();
                    notifies.CreatedAt = DateTime.Now;
                    notifies.UpdatedAt = DateTime.Now;
                }
            }

            base.Create(svtpTask);
        }

        public void UpdateSVTPTask(SVTPTask svtpTask)
        {
            base.Update(svtpTask);
        }

        public void DeleteSVTPTask(SVTPTask svtpTask)
        {
            if (svtpTask == null)
            {
                throw new ArgumentNullException(nameof(svtpTask));
            }
            base.Delete(svtpTask);
        }

        public async Task<bool> IsSVTPTaskExistAsync(Guid svtpId)
        {
            if (svtpId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(svtpId));
            }

            return await base.IsEntityExistAsync(x => x.Id == svtpId, trackChanges: false);
        }
    }
}
