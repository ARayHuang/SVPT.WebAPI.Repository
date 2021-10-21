using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class TestResultUpdateScheduleModel
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
