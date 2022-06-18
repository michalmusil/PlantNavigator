using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Models.DTOs.FertilizerType;

namespace PlantNavigator.API.Models.DTOs.FertilizingHabit
{
    public class FertilizingHabitGetDto
    {
        public int Id { get; set; }
        public int DaysFrequency { get; set; }
        public string? Description { get; set; }
        public Month? TimeFrom { get; set; }
        public Month? TimeTo { get; set; }

        public List<Plant_FertilizingHabitGetDto> Plant_FertilizingHabits { get; set; }
    }
}
