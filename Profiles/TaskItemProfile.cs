using AutoMapper;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Profiles
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<SVTPTemplateItem, TaskItem>();

            CreateMap<TaskItem, TaskItemReturnModel>();
        }
    }
}
