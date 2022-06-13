using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.WateringCondition
{
    public class WaterConditionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WateringIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
