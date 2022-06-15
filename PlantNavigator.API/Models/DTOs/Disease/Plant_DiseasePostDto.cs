using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Disease
{
    public class Plant_DiseasePostDto
    {
        public string? Condition { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int DiseaseId { get; set; }
    }
}
