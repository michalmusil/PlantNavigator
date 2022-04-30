using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("Classifications")]
    public class Classification : BaseEntity
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public ClassificationType ClassificationType { get; set; } 

        public List<Plant_Classification> Plant_Classifications { get; set; }
    }
}
