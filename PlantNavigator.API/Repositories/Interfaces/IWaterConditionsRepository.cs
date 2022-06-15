using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IWaterConditionsRepository
    {
        public Task<IEnumerable<WaterCondition>> GetAll(string? name = null, WateringIntensity? wateringIntensity = null);

        public Task<WaterCondition> GetById(int id);

        public Task<bool> AddWaterCondition(WaterCondition waterCondition);

        public Task<bool> UpdateWaterCondition(WaterCondition waterCondition);

        public Task<bool> DeleteWaterCondition(WaterCondition waterCondition);
    }
}
