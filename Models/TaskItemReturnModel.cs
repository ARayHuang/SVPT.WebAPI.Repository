using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class TaskItemReturnModel
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public string SubItem { get; set; }
        public string Information { get; set; }
    }
}
