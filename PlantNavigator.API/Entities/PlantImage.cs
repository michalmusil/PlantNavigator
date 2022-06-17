using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    [Table("PlantImages")]
    public class PlantImage : BaseEntity
    {
        [Required]
        public Plant Plant { get; set; }
        [Required]
        public int PlantId { get; set; }

        [Required]
        public string path { get; set; }
    }
}
