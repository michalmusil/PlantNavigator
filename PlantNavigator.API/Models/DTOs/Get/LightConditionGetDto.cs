using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.Get
{
    public class LightConditionGetDto
    {
        public string Name { get; set; }
        public SunlightIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
