using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.WateringHabit;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class WateringHabitProfile : Profile
    {
        public WateringHabitProfile()
        {
            CreateMap<WateringHabit, WateringHabitGetDto>();
            CreateMap<WateringHabitPostDto, WateringHabit>();
            CreateMap<WateringHabitPutDto, WateringHabit>();
        }
    }
}
