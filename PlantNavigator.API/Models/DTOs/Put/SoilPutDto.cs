using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Put
{
    public class SoilPutDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
