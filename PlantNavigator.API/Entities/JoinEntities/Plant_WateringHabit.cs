namespace PlantNavigator.API.Entities.JoinEntities
{
    public class Plant_WateringHabit : BaseEntity
    {
        public string? Description { get; set; }

        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public WateringHabit WateringHabit { get; set; }
        public int WateringHabitId { get; set; }
    }
}
