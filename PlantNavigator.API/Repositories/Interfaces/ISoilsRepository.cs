using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface ISoilsRepository
    {
        public Task<IEnumerable<Soil>> GetAll(string? name = null, int? plantId = null, bool? includeAsociatedPlants = null);

        public Task<Soil> GetById(int id);

        public Task<bool> AddSoil(Soil soil);

        public Task<bool> UpdateSoil(Soil soil);

        public Task<bool> DeleteSoil(Soil soil);

        public Task<bool> PlantExists(int id);

        public Task<bool> SoilExists(int id);



        public Task<Plant_Soil> GetPlantSoilById(int plantId, int soilId);

        public Task<bool> AddPlantSoilJoin(Plant_Soil join);

        public Task<bool> DeletePlantSoil(Plant_Soil plantSoil);
    }
}
