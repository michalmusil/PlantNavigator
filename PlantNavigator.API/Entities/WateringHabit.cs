using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("WateringHabits")]
    public class WateringHabit : BaseEntity
    {
        [Required]
        public int DaysFrequency { get; set; }
        public string? Description { get; set; }
        public Month? TimeFrom { get; set; }
        public Month? TimeTo { get; set; }

        public List<Plant_WateringHabit> Plant_WateringHabits { get; set; }
    }
}
