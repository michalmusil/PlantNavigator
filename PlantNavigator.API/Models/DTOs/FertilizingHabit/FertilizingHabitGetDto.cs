using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.FertilizingHabit
{
    public class FertilizingHabitGetDto
    {
        public int DaysFrequency { get; set; }
        public string? Description { get; set; }
        public Month? TimeFrom { get; set; }
        public Month? TimeTo { get; set; }

        public List<Plant_FertilizingHabitGetDto> Plant_FertilizingHabits { get; set; }
    }
}
