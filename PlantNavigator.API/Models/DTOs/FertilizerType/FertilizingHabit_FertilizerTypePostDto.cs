using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.FertilizerType
{
    public class FertilizingHabit_FertilizerTypePostDto
    {
        [Required]
        public int FertilizingHabitId { get; set; }
        [Required]
        public int FertilizerTypeId { get; set; }
    }
}
