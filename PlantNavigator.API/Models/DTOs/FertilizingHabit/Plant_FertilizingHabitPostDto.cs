using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.FertilizingHabit
{
    public class Plant_FertilizingHabitPostDto
    {
        public string? Description { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int FertilizingHabitId { get; set; }
    }
}
