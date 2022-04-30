using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("Diseases")]
    public class Disease : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Plant_Disease> Plant_Diseases { get; set; }
    }
}
