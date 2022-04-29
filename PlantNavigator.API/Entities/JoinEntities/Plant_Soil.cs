using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities.JoinEntities
{
    public class Plant_Soil: BaseEntity
    {
        public string? Condition { get; set; }

        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public Soil Soil { get; set; }
        public int SoilId { get; set; }
    }
}
