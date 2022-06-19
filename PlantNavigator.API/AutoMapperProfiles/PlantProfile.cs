using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Plant;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, PlantGetDto>();
            CreateMap<Plant, PlantGetExtendedDto>();
            CreateMap<PlantPostDto, Plant>();
            CreateMap<PlantPutDto, Plant>();
        }
    }
}
