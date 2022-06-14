using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.ManyToMany
{
    public class Plant_PestPostDto
    {
        public string? Condition { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int PestId { get; set; }
    }
}
