using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface ILightConditionsRepository
    {
        public Task<IEnumerable<LightCondition>> GetAll(string? name = null, SunlightIntensity? lightIntensity = null);

        public Task<LightCondition> GetById(int id);

        public Task<bool> AddLightCondition(LightCondition lightCondition);

        public Task<bool> UpdateLightCondition(LightCondition lightCondition);

        public Task<bool> DeleteLightCondition(LightCondition lightCondition);

    }
}
