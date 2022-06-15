using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Disease
{
    public class DiseasePostDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
