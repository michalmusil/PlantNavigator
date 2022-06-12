using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;
using PlantNavigator.API.Models.DTOs.Post;
using PlantNavigator.API.Models.DTOs.Put;

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
