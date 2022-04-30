namespace PlantNavigator.API.Entities.JoinEntities
{
    public class Plant_Classification : BaseEntity
    {
        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public Classification Classification { get; set; }
        public int ClassificationId { get; set; }
    }
}
