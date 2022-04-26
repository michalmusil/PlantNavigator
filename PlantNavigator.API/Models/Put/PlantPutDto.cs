using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.Put
{
    public class PlantPutDto
    {
        [MaxLength(200)]
        public string? Species { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
