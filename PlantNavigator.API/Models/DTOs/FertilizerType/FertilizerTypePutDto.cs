using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.FertilizerType
{
    public class FertilizerTypePutDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
