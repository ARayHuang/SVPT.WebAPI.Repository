using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Repository.Contracts
{
    public interface ISVTPTemplateItemRepository
    {
        Task<IEnumerable<SVTPTemplateItem>> GetSVTPTemplateItemFromLatestVersionAsync();
    }
}
