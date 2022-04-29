using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    public class Plant : IDatabaseIdentifiable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [ForeignKey("WaterConditionId")]
        public WaterCondition? WaterCondition { get; set; } 
        public int WaterConditionId { get; set; }
    }
}
