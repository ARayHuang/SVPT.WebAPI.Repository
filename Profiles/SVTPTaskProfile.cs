using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SVPT.WebAPI.Constant;
using SVPT.WebAPI.Models;
using SVPT.WebAPI.Store.Entity;

namespace SVPT.WebAPI.Profiles
{
    public class SVTPTaskProfile : Profile
    {
        public SVTPTaskProfile()
        {
            CreateMap<SVTPTask, SVTPTaskReturnModel>()
                .ForMember(
                    dest => dest.status,
                    opt => opt.MapFrom( src => PlanStatusMapping.Mapping(src.status))
                );

            CreateMap<SVTPTaskModel, SVTPTask>()
                .ForMember(
                    dest => dest.status,
                    opt => opt.MapFrom(src => (PlanStatus)src.status)
                );
        }
    }
}
