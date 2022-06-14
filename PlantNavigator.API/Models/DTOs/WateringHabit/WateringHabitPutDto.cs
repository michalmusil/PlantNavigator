using PlantNavigator.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.WateringHabit
{
    public class WateringHabitPutDto
    {
        [Required]
        public int DaysFrequency { get; set; }
        public string? Description { get; set; }
        [Range(1, 12)]
        public Month? TimeFrom { get; set; }
        [Range(1, 12)]
        public Month? TimeTo { get; set; }
    }
}
