using SVPT.WebAPI.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class SVTPTaskReturnModel
    {
        public Guid Id { get; set; }
        public string Project { get; set; }
        public string PlatformType { get; set; }
        public string Phase { get; set; }
        public string Year { get; set; }
        public string Series { get; set; }
        public string status { get; set; }
    }
}
