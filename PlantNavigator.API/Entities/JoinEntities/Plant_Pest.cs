namespace PlantNavigator.API.Entities.JoinEntities
{
    public class Plant_Pest : BaseEntity
    {
        public string? Condition { get; set; }

        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public Pest Pest { get; set; }
        public int PestId { get; set; }
    }
}
