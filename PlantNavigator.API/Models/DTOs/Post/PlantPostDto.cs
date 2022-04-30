using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Post
{
    public class PlantPostDto
    {
        [Required]
        [MaxLength(200)]
        public string Species { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
