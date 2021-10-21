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
    public class SVTPTemplateItemRepository : DbRepositoryBase<SVTPTemplateItem>, ISVTPTemplateItemRepository
    {
        public SVTPTemplateItemRepository(SVTPDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<SVTPTemplateItem>> GetSVTPTemplateItemFromLatestVersionAsync()
        {
            var lastVersionTemplateId = await SVTPDbContext.tblSVTPTemplate
                    .OrderByDescending(x => x.Version).ThenByDescending(x => x.releadDate).FirstOrDefaultAsync();

            if (lastVersionTemplateId == null)
            {
                throw new ArgumentNullException();
            }

            return await SVTPDbContext.tblSVTPTemplateItem
                .Where(x => x.SVTPTemplateId == lastVersionTemplateId.Id).ToListAsync();
        }
    }
}
