using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;

namespace SVPT.WebAPI.Store.Data
{
    public class SVTPTemplateData : IBulkData<SVTPTemplate>
    {
        private SVTPDbContext _svtpDbContext;

        public SVTPTemplateData(SVTPDbContext context)
        {
            this._svtpDbContext = context;
        }

        public void InsertBulkData()
        {
            List<SVTPTemplate> data = GenerateData();
            this._svtpDbContext.tblSVTPTemplate.AddRange(data);
        }

        public List<SVTPTemplate> GenerateData()
        {
            List<SVTPTemplate> bulkData = new List<SVTPTemplate>();

            bulkData.Add(new SVTPTemplate
            {
                Id = Guid.Parse("18691110-5CDF-45A2-B258-6699DAE71BD2"),
                Version = 702,
                releadDate = DateTime.Now.Date,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            return bulkData;
        }
    }
}
