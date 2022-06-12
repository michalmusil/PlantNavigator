using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Put
{
    public class ClassificationPutDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(0, 6)]
        public ClassificationType ClassificationType { get; set; }
    }
}
