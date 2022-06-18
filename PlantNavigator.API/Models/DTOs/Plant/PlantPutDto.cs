using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Plant
{
    public class PlantPutDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(1, 12)]
        public Month? FloweringFrom { get; set; }
        [Range(1, 12)]
        public Month? FloweringTo { get; set; }
        public int? TemperatureFrom { get; set; }
        public int? TemperatureTo { get; set; }
        public bool? MistingAppropriate { get; set; }

        public int? WaterConditionId { get; set; }

        public int? LightConditionId { get; set; }
    }
}
