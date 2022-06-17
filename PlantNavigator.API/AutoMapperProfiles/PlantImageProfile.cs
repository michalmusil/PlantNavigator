using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.PlantImage;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class PlantImageProfile : Profile
    {
        public PlantImageProfile()
        {
            CreateMap<PlantImage, PlantImageGetDto>();
        }
    }
}
