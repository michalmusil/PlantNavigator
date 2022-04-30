using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, PlantGetDto>();
        }
    }
}
