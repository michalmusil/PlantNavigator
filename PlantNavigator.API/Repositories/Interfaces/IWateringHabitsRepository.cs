using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IWateringHabitsRepository
    {
        public Task<IEnumerable<WateringHabit>> GetAll(int? plantId, bool? includeAsociatedPlants);

        public Task<WateringHabit> GetById(int id);

        public Task<bool> AddWateringHabit(WateringHabit habit);

        public Task<bool> UpdateWateringHabit(WateringHabit habit);

        public Task<bool> DeleteWateringHabit(WateringHabit habit);

        public Task<bool> PlantExists(int id);

        public Task<bool> WateringHabitExists(int id);



        public Task<Plant_WateringHabit> GetPlantWateringHabitById(int plantId, int wateringHabitId);

        public Task<bool> AddPlantWateringHabitJoin(Plant_WateringHabit join);

        public Task<bool> DeletePlantWateringHabit(Plant_WateringHabit plantWateringHabit);
    }
}
