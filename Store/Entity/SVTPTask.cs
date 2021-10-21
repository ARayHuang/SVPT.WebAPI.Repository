using SVPT.WebAPI.Constant;
using System;
using System.Collections.Generic;

namespace SVPT.WebAPI.Store.Entity
{
    public class SVTPTask : Default
    {
        public Guid Id { get; set; }
        public string Project { get; set; }
        public string PlatformType { get; set; }
        public string Phase { get; set; }
        public string Year { get; set; }
        public string Version { get; set; }
        public string Series { get; set; }
        public PlanStatus status { get; set; }

        public string SystemBoard { get; set; }
        public string ODM { get; set; }
        public string TestUnit { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }

        public ICollection<TaskNotifies> TaskNotifies { get; set; }
    }
}
