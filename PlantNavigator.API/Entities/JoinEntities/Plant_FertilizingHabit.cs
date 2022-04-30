namespace PlantNavigator.API.Entities.JoinEntities
{
    public class Plant_FertilizingHabit : BaseEntity
    {
        public string? Description { get; set; }

        public Plant Plant { get; set; }
        public int PlantId { get; set; }

        public FertilizingHabit FertilizingHabit { get; set; }
        public int FertilizingHabitId { get; set; }
    }
}
