using AutoMapper;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.FertilizerType;

namespace PlantNavigator.API.AutoMapperProfiles
{
    public class FertilizerTypeProfile : Profile
    {
        public FertilizerTypeProfile()
        {
            CreateMap<FertilizerType, FertilizerTypeGetDto>();
            CreateMap<FertilizerTypePostDto, FertilizerType>();
            CreateMap<FertilizerTypePutDto, FertilizerType>();
        }
    }
}
