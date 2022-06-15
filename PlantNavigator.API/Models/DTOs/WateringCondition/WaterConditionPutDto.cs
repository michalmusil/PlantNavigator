using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.WateringCondition
{
    public class WaterConditionPutDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 4)]
        public WateringIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
