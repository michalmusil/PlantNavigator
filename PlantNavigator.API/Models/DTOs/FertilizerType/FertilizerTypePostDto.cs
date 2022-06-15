using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.FertilizerType
{
    public class FertilizerTypePostDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
