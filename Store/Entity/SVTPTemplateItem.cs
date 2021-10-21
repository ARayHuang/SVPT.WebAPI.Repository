using System;

namespace SVPT.WebAPI.Store.Entity
{
    public class SVTPTemplateItem : Default
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public string SubItem { get; set; }
        public string Information { get; set; }
        public Guid SVTPTemplateId { get; set; }

        public SVTPTemplate SVTPTemplate { get; set; }
    }
}
