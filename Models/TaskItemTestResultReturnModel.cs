using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class TaskItemTestResultReturnModel
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public string Vendor { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string ResultStatus { get; set; }
        public string WaiveOrBlock { get; set; }
        public string Category { get; set; }
        public string LeverageFrom { get; set; }

    }
}
