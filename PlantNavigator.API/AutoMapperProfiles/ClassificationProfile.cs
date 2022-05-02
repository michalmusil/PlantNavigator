using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;
using PlantNavigator.API.Models.DTOs.Post;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class ClassificationProfile : Profile
    {
        public ClassificationProfile()
        {
            CreateMap<Classification, ClassificationGetDto>();
            CreateMap<ClassificationPostDto, Classification>();
        }
    }
}
