using AutoMapper;
using SVPT.WebAPI.Constant;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI.Profiles
{
    public class TaskItemTestResultProfile : Profile
    {
        public TaskItemTestResultProfile()
        {
            CreateMap<TaskItemTestResult, TaskItemTestResultReturnModel>()
                .ForMember(
                    dest => dest.ResultStatus,
                    opt => opt.MapFrom(src => ResultStatusMapping.Mapping(src.Status))
                );
        }
    }
}
