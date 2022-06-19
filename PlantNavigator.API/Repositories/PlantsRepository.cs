using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories
{
    public class PlantsRepository : IPlantsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public PlantsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public async Task<IEnumerable<Plant>> GetAll(string? plantName, int? classificationId, int? soilId, int? pestId, int? diseaseId,
            int? lightConditionId, int? waterConditionId, int? wateringHabitId, int? fertilizingHabitId)
        {
            var all = dbContext.Set<Plant>().AsNoTracking();

            if (plantName != null)
            {
                all = all.Where(p => p.Name.ToLower().Contains(plantName.ToLower()));
            }

            if (classificationId != null)
            {
                all = all.Where(p => p.Plant_Classifications.Any(x => x.ClassificationId == classificationId));
            }

            if (soilId != null)
            {
                all = all.Where(p => p.Plant_Soils.Any(x => x.SoilId == soilId));
            }

            if (pestId != null)
            {
                all = all.Where(p => p.Plant_Pests.Any(x => x.PestId == pestId));
            }

            if (diseaseId != null)
            {
                all = all.Where(p => p.Plant_Diseases.Any(x => x.DiseaseId == diseaseId));
            }

            if (lightConditionId != null)
            {
                all = all.Where(p => p.LightConditionId == lightConditionId);
            }

            if (waterConditionId != null)
            {
                all = all.Where(p => p.WaterConditionId == waterConditionId);
            }

            if (wateringHabitId != null)
            {
                all = all.Where(p => p.Plant_WateringHabits.Any(x => x.WateringHabitId == wateringHabitId));
            }

            if (fertilizingHabitId != null)
            {
                all = all.Where(p => p.Plant_FertilizingHabits.Any(x => x.FertilizingHabitId == fertilizingHabitId));
            }

            all = all.Include(p => p.WaterCondition).Include(p => p.LightCondition);

            return await all.ToListAsync();
        }

        public async Task<Plant> GetById(int id)
        {
            return await dbContext.Plants.Include(p => p.WaterCondition).Include(p => p.LightCondition).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlant(Plant plant)
        {
            dbContext.Plants.Add(plant);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePlant(Plant plant)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlant(Plant plant)
        {
            dbContext.Remove(plant);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> WateringConditionExists(int? id)
        {
            return await dbContext.WaterConditions.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> LightConditionExists(int? id)
        {
            return await dbContext.LightConditions.AnyAsync(c => c.Id == id);
        }
        



        public async Task<IEnumerable<Classification>> GetPlantsClassifications(int plantId)
        {
            return await dbContext.Classifications.Where(d => d.Plant_Classifications.Any(x => x.PlantId == plantId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Disease>> GetPlantsDiseases(int plantId)
        {
            return await dbContext.Diseases.Where(d => d.Plant_Diseases.Any(x => x.PlantId == plantId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Soil>> GetPlantsSoils(int plantId)
        {
            return await dbContext.Soils.Where(s => s.Plant_Soils.Any(x => x.PlantId == plantId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pest>> GetPlantsPests(int plantId)
        {
            return await dbContext.Pests.Where(p => p.Plant_Pests.Any(x => x.PlantId == plantId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<WateringHabit>> GetPlantsWateringHabits(int plantId)
        {
            return await dbContext.WateringHabits.Where(w => w.Plant_WateringHabits.Any(x => x.PlantId == plantId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<FertilizingHabit>> GetPlantsFertilizingHabits(int plantId)
        {
            return await dbContext.FertilizingHabits.Where(d => d.Plant_FertilizingHabits.Any(x => x.PlantId == plantId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PlantImage>> GetPlantsImages(int plantId)
        {
            return await dbContext.PlantImages.Where(d => d.PlantId == plantId).AsNoTracking().ToListAsync();
        }
    }
}
