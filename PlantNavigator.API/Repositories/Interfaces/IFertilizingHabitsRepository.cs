using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IFertilizingHabitsRepository
    {
        public Task<IEnumerable<FertilizingHabit>> GetAll(int? plantId, bool? includeAsociatedPlants);

        public Task<FertilizingHabit> GetById(int id);

        public Task<bool> AddFertilizingHabit(FertilizingHabit habit);

        public Task<bool> UpdateFertilizingHabit(FertilizingHabit habit);

        public Task<bool> DeleteFertilizingHabit(FertilizingHabit habit);

        public Task<bool> PlantExists(int id);

        public Task<bool> FertilizingHabitExists(int id);



        public Task<Plant_FertilizingHabit> GetPlantFertilizingHabitById(int plantId, int fertilizingHabitId);

        public Task<bool> AddPlantFertilizingHabitJoin(Plant_FertilizingHabit join);

        public Task<bool> DeletePlantFertilizingHabit(Plant_FertilizingHabit plantFertilizingHabit);
    }
}
