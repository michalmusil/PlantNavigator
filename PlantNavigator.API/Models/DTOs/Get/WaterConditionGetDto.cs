using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.Get
{
    public class WaterConditionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WateringIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
