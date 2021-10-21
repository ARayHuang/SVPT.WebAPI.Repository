using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SVPT.WebAPI.Store.Entity
{
    public class TaskItem : Default
    {
        public Guid Id { get; set; }
        
        public string Item { get; set; }
        public string SubItem { get; set; }
        public string Information { get; set; }

        [ForeignKey(nameof(SVTPTask))]
        public Guid TaskId { get; set; }
        public SVTPTask SVTPTask { get; set; }

        public ICollection<TaskItemTestResult> TaskItemTestResults { get; set; }
    }
}
