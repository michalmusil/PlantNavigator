using PlantNavigator.API.Entities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface ISoilsRepository
    {
        public Task<IEnumerable<Soil>> GetAll(string? name = null);

        public Task<Soil> GetById(int id);

        public Task<bool> AddSoil(Soil soil);

        public Task<bool> UpdateSoil(Soil soil);

        public Task<bool> SoilExists(int id);
    }
}
