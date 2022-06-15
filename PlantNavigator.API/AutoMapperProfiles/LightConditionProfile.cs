using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.LightCondition;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class LightConditionProfile : Profile
    {
        public LightConditionProfile()
        {
            CreateMap<LightCondition, LightConditionGetDto>();
            CreateMap<LightConditionPostDto, LightCondition>();
            CreateMap<LightConditionPutDto, LightCondition>();
        }
    }
}
