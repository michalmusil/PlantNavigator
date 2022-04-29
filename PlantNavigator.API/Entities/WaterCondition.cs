using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Entities
{
    public class WaterCondition : IDatabaseIdentifiable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public WateringIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
