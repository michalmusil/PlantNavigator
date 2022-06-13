using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Post;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IClassificationsRepository
    {
        public Task<IEnumerable<Classification>> GetAll(string? name = null);

        public Task<Classification> GetById(int id);

        public Task<bool> AddClassification(Classification classification);

        public Task<bool> UpdateClassification(Classification classification);

        public Task<bool> DeleteClassification(Classification classification);

        public Task<bool> ClassificationExists(int id);
    }
}
