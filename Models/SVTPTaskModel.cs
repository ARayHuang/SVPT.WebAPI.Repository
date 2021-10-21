using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Models
{
    public class SVTPTaskModel
    {
        [Display(Name = "Project Name")]
        [Required(ErrorMessage= "{0} is required")]
        public string Project { get; set; }
        public string PlatformType { get; set; }

        [Display(Name = "Phase")]
        [Required(ErrorMessage = "{0} is required")]
        public ICollection<string> Phases { get; set; }
        public string Year { get; set; }
        public string Series { get; set; }
        public int status { get; set; }

        public ICollection<TaskNotifiesModel> TaskNotifies { get; set; } = new List<TaskNotifiesModel>();
    }
}
