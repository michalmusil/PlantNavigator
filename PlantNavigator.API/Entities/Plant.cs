using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("Plants")]
    public class Plant : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Month? FloweringFrom { get; set; }
        public Month? FloweringTo { get; set; }
        public bool? MistingAppropriate { get; set; }

        public WaterCondition? WaterCondition { get; set; } 
        public int? WaterConditionId { get; set; }

        public LightCondition? LightCondition { get; set; }
        public int? LightConditionId { get; set; }

        public List<Plant_Soil> Plant_Soils { get; set; }
        public List<Plant_Pest> Plant_Pests { get; set; }
        public List<Plant_Disease> Plant_Diseases { get; set; }
        public List<Plant_WateringHabit> Plant_WateringHabits { get; set; }
        public List<Plant_FertilizingHabit> Plant_FertilizingHabits { get; set; }
        public List<Plant_Classification> Plant_Classifications { get; set;}
    }
}
