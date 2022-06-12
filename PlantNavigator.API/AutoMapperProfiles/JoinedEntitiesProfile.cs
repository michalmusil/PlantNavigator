using AutoMapper;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.Post;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class JoinedEntitiesProfile : Profile
    {
        public JoinedEntitiesProfile()
        {
            CreateMap<Plant_SoilPostDto, Plant_Soil>();
            CreateMap<Plant_Soil, Plant_SoilPostDto>();
        }
    }
}
