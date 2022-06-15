using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Models.DTOs.Classification;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class ClassificationProfile : Profile
    {
        public ClassificationProfile()
        {
            CreateMap<Classification, ClassificationGetDto>();
            CreateMap<ClassificationPostDto, Classification>();
            CreateMap<ClassificationPutDto, Classification>();
        }
    }
}
