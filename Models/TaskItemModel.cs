using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class TaskItemModel
    {
        public ICollection<Guid> ItemIds { get; set; }
    }
}
