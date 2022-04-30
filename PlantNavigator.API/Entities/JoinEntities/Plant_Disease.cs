namespace PlantNavigator.API.Entities.JoinEntities
{
    public class Plant_Disease : BaseEntity
    {
        public string? Condition { get; set; }

        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public Disease Disease { get; set; }
        public int DiseaseId { get; set; }
    }
}
