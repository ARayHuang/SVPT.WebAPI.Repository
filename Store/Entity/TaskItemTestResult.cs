using SVPT.WebAPI.Constant;
using System;
using System.Collections.Generic;

namespace SVPT.WebAPI.Store.Entity
{
    public class TaskItemTestResult : Default
    {
        public Guid Id { get; set; }
        public Guid TaskItemId { get; set; }
        public string Item { get; set; }
        public string Vendor { get; set; }
        public string ExtraKey { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public ResultStatus Status { get; set; }
        public string WaiveOrBlock { get; set; }
        public string Category { get; set; }
        public string LeverageFrom { get; set; }

        public string OBS { get; set; }
        public string OBSDescription { get; set; }

        public TaskItem TaskItem { get; set; }
        public ICollection<TaskItemTestResultFile> TaskItemTestResultFiles { get; set; }
    }
}
