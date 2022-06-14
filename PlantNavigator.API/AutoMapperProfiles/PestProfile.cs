using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Pest;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class PestProfile : Profile
    {
        public PestProfile() 
        {
            CreateMap<Pest, PestGetDto>();
            CreateMap<PestPostDto, Pest>();
            CreateMap<PestPutDto, Pest>();
        }
    }
}
