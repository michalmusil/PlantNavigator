using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Pest
{
    public class PestPostDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
