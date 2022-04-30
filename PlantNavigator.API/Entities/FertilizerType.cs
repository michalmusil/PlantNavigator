using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("FertilizerTypes")]
    public class FertilizerType : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<FertilizingHabit_FertilizerType> FertilizingHabit_FertilizerTypes { get; set; }
    }
}
