using AutoMapper;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.Classification;
using PlantNavigator.API.Models.DTOs.FertilizerType;
using PlantNavigator.API.Models.DTOs.FertilizingHabit;
using PlantNavigator.API.Models.DTOs.Pest;
using PlantNavigator.API.Models.DTOs.Soil;
using PlantNavigator.API.Models.DTOs.WateringHabit;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class JoinedEntitiesProfile : Profile
    {
        public JoinedEntitiesProfile()
        {
            CreateMap<Plant_ClassificationPostDto, Plant_Classification>();
            CreateMap<Plant_Classification, Plant_ClassificationGetDto>();

            CreateMap<Plant_SoilPostDto, Plant_Soil>();
            CreateMap<Plant_Soil, Plant_SoilGetDto>();

            CreateMap<Plant_PestPostDto, Plant_Pest>();
            CreateMap<Plant_Pest, Plant_PestGetDto>();

            CreateMap<Plant_WateringHabitPostDto, Plant_WateringHabit>();
            CreateMap<Plant_WateringHabit, Plant_WateringHabitGetDto>();

            CreateMap<Plant_FertilizingHabitPostDto, Plant_FertilizingHabit>();
            CreateMap<Plant_FertilizingHabit, Plant_FertilizingHabitGetDto>();

            CreateMap<FertilizingHabit_FertilizerTypePostDto, FertilizingHabit_FertilizerType>();
        }
    }
}
