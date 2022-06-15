using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IDiseasesRepository
    {
        public Task<IEnumerable<Disease>> GetAll(string? name = null, int? plantId = null, bool? includeAsociatedPlants = null);

        public Task<Disease> GetById(int id);

        public Task<bool> AddDisease(Disease disease);

        public Task<bool> UpdateDisease(Disease disease);

        public Task<bool> DeleteDisease(Disease disease);

        public Task<bool> PlantExists(int id);

        public Task<bool> DiseaseExists(int id);



        public Task<Plant_Disease> GetPlantDiseaseById(int plantId, int diseaseId);

        public Task<bool> AddPlantDiseaseJoin(Plant_Disease join);

        public Task<bool> DeletePlantDisease(Plant_Disease plantDisease);
    }
}
