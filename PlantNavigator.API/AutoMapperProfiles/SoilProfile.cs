using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Soil;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class SoilProfile : Profile
    {
        public SoilProfile()
        {
            CreateMap<Soil, SoilGetDto>();
            CreateMap<SoilPostDto, Soil>();
            CreateMap<SoilPutDto, Soil>();
        }
    }
}
