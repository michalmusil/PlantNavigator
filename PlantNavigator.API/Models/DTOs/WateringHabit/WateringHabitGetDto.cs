using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.WateringHabit
{
    public class WateringHabitGetDto
    {
        public int DaysFrequency { get; set; }
        public string? Description { get; set; }
        public Month? TimeFrom { get; set; }
        public Month? TimeTo { get; set; }

        public List<Plant_WateringHabitGetDto> Plant_WateringHabits { get; set; }
    }
}
