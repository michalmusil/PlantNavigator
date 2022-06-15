using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.LightCondition
{
    public class LightConditionPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 3)]
        public SunlightIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
