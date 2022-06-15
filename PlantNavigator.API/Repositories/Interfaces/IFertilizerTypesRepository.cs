using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IFertilizerTypesRepository
    {
        public Task<IEnumerable<FertilizerType>> GetAll(string? typeName, int? plantId);

        public Task<FertilizerType> GetById(int id);

        public Task<bool> AddFertilizerType(FertilizerType type);

        public Task<bool> UpdateFertilizerType(FertilizerType type);

        public Task<bool> DeleteFertilizerType(FertilizerType type);

        public Task<bool> PlantExists(int id);

        public Task<bool> FertilizerTypeExists(int id);

        public Task<bool> FertilizingHabitExists(int id);



        public Task<FertilizingHabit_FertilizerType> GetFertilizingHabitFertilizerTypeById(int FertilizingHabitId, int FertilizerTypeId);

        public Task<bool> AddFertilizingHabitFertilizerTypeJoin(FertilizingHabit_FertilizerType join);

        public Task<bool> DeleteFertilizingHabitFertilizerType(FertilizingHabit_FertilizerType FertilizingHabitFertilizerType);
    }
}
