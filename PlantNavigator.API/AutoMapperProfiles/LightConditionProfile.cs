using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class LightConditionProfile : Profile
    {
        public LightConditionProfile()
        {
            CreateMap<LightCondition, LightConditionGetDto>();
        }
    }
}
