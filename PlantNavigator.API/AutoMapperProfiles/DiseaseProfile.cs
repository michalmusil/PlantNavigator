using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Disease;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class DiseaseProfile : Profile
    {
        public DiseaseProfile()
        {
            CreateMap<Disease, DiseaseGetDto>();
            CreateMap<DiseasePostDto, Disease>();
            CreateMap<DiseasePutDto, Disease>();
        }
    }
}
