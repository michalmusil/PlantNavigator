using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class WaterConditionProfile : Profile
    {
        public WaterConditionProfile()
        {
            CreateMap<WaterCondition, WaterConditionGetDto>();
        }
    }
}
