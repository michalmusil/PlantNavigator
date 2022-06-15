using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.WateringCondition;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class WaterConditionProfile : Profile
    {
        public WaterConditionProfile()
        {
            CreateMap<WaterCondition, WaterConditionGetDto>();
            CreateMap<WaterConditionPostDto, WaterCondition>();
            CreateMap<WaterConditionPutDto, WaterCondition>();
        }
    }
}
