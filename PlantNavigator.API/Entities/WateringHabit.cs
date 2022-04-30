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
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }

        public List<Plant_WateringHabit> Plant_WateringHabits { get; set; }
    }
}
