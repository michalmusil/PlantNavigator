using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.LightCondition
{
    public class LightConditionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SunlightIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
