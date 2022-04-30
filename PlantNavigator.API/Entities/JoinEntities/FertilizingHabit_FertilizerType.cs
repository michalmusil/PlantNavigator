namespace PlantNavigator.API.Entities.JoinEntities
{
    public class FertilizingHabit_FertilizerType : BaseEntity
    {
        public FertilizingHabit FertilizingHabit { get; set; }
        public int FertilizingHabitId { get; set; }

        public FertilizerType FertilizerType { get; set; }
        public int FertilizerTypeId { get; set; }
    }
}
