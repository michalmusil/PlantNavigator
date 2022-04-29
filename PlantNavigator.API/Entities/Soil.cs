using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Entities
{
    public class Soil : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Plant_Soil> Plant_Soils { get; set; }
    }
}
