using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IPestsRepository
    {
        public Task<IEnumerable<Pest>> GetAll(string? name = null);

        public Task<Pest> GetById(int id);

        public Task<bool> AddPest(Pest pest);

        public Task<bool> UpdatePest(Pest pest);

        public Task<bool> DeletePest(Pest pest);

        public Task<bool> PlantExists(int id);

        public Task<bool> PestExists(int id);



        public Task<Plant_Pest> GetPlantPestById(int plantId, int pestId);

        public Task<bool> AddPlantPestJoin(Plant_Pest join);

        public Task<bool> DeletePlantPest(Plant_Pest plantPest);
    }
}
