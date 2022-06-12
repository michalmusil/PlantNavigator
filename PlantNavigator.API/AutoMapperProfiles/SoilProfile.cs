using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;
using PlantNavigator.API.Models.DTOs.Post;
using PlantNavigator.API.Models.DTOs.Put;

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
