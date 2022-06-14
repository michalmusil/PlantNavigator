using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.FertilizingHabit;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class FertilizingHabitProfile : Profile
    {
        public FertilizingHabitProfile()
        {
            CreateMap<FertilizingHabit, FertilizingHabitGetDto>();
            CreateMap<FertilizingHabitPostDto, FertilizingHabit>();
            CreateMap<FertilizingHabitPutDto, FertilizingHabit>();
        }
    }
}
