using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Entities
{
    public class LightCondition : IDatabaseIdentifiable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public SunlightIntensity Intensity { get; set; }
        public string? Description { get; set; }
    }
}
