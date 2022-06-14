using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Classification
{
    public class Plant_ClassificationPostDto
    {
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int ClassificationId { get; set; }
    }
}
