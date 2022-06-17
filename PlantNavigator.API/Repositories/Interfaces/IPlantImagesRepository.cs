using PlantNavigator.API.Entities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IPlantImagesRepository
    {
        public Task<IEnumerable<PlantImage>> GetAll(int? plantId = null);

        public Task<PlantImage> GetById(int id);

        public Task<bool> AddPlantImage(PlantImage plantImage);

        public Task<bool> DeletePlantImage(PlantImage plantImage);
    }
}
