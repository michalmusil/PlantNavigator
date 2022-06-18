using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IPlantsRepository
    {
        public Task<IEnumerable<Plant>> GetAll(string? plantName, int? classificationId, int? soilId, int? pestId, int? diseaseId,
            int? lightConditionId, int? waterConditionId, int? wateringHabitId, int? fertilizingHabitId);

        public Task<Plant> GetById(int id);

        public Task<bool> AddPlant(Plant plant);

        public Task<bool> UpdatePlant(Plant plant);

        public Task<bool> DeletePlant(Plant plant);

        public Task<bool> PlantExists(int id);

        public Task<bool> WateringConditionExists(int? id);

        public Task<bool> LightConditionExists(int? id);

    }
}
