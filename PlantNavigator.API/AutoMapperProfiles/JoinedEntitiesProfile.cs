using AutoMapper;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.ManyToMany;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class JoinedEntitiesProfile : Profile
    {
        public JoinedEntitiesProfile()
        {
            CreateMap<Plant_SoilPostDto, Plant_Soil>();

            CreateMap<Plant_PestPostDto, Plant_Pest>();

            CreateMap<Plant_WateringHabitPostDto, Plant_WateringHabit>();
            CreateMap<Plant_WateringHabit, Plant_WateringHabitGetDto>();
        }
    }
}
