using System;
using System.Collections.Generic;

namespace SVPT.WebAPI.Store.Entity
{
    public class SVTPTemplate : Default
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTime releadDate { get; set; }

        public ICollection<SVTPTemplateItem> SVPTTemplateReleaseItems { get; set; }
    }
}
