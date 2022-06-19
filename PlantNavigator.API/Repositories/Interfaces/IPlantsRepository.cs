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



        public Task<IEnumerable<Classification>> GetPlantsClassifications(int plantId);

        public Task<IEnumerable<Disease>> GetPlantsDiseases(int plantId);

        public Task<IEnumerable<Soil>> GetPlantsSoils(int plantId);

        public Task<IEnumerable<Pest>> GetPlantsPests(int plantId);

        public Task<IEnumerable<WateringHabit>> GetPlantsWateringHabits(int plantId);

        public Task<IEnumerable<FertilizingHabit>> GetPlantsFertilizingHabits(int plantId);

        public Task<IEnumerable<PlantImage>> GetPlantsImages(int plantId);

    }
}
