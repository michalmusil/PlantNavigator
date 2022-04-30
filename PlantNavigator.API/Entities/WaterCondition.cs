using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("WaterConditions")]
    public class WaterCondition : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public WateringIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
