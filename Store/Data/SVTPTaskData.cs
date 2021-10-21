using SVPT.WebAPI.Constant;
using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Store.Data
{
    public class SVTPTaskData : IBulkData<SVTPTask>
    {
        private SVTPDbContext _svtpDbContext;

        public SVTPTaskData(SVTPDbContext context)
        {
            this._svtpDbContext = context;
        }

        public void InsertBulkData()
        {
            List<SVTPTask> data = GenerateData();
            this._svtpDbContext.tblSVTPTask.AddRange(data);
        }

        public List<SVTPTask> GenerateData()
        {
            List<SVTPTask> bulkData = new List<SVTPTask>();

            bulkData.Add(new SVTPTask
            {
                Id = Guid.Parse("300DB8C0-3E4D-4322-B96D-E1E4DF8FDD24"),
                Project = "Ronin13",
                PlatformType = "X360",
                Phase = "DB",
                Year = "2022",
                Version = "702",
                Series = "800",
                status = PlanStatus.DRAFT,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            bulkData.Add(new SVTPTask
            {
                Id = Guid.Parse("07CB9617-0F84-4D96-99CB-B57CE010D513"),
                Project = "Thanos13",
                PlatformType = "NB",
                Phase = "DB",
                Year = "2022",
                Version = "702",
                Series = "600",
                status = PlanStatus.DRAFT,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            return bulkData;
        }
    }
}
