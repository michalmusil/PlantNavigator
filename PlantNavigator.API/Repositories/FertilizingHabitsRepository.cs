using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class FertilizingHabitsRepository : IFertilizingHabitsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public FertilizingHabitsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<FertilizingHabit>> GetAll(int? plantId, bool? includeAsociatedPlants)
        {
            var all = dbContext.Set<FertilizingHabit>().AsNoTracking();

            if (includeAsociatedPlants == true)
            {
                all = all.Include(h => h.Plant_FertilizingHabits);
            }

            if (plantId != null)
            {
                all = all.Where(h => h.Plant_FertilizingHabits.Any(p => p.PlantId == plantId));
            }

            return await all.ToListAsync();
        }

        public async Task<FertilizingHabit> GetById(int id)
        {
            return await dbContext.FertilizingHabits.Include(h => h.Plant_FertilizingHabits).Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddFertilizingHabit(FertilizingHabit habit)
        {
            dbContext.FertilizingHabits.Add(habit);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFertilizingHabit(FertilizingHabit habit)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFertilizingHabit(FertilizingHabit habit)
        {
            dbContext.Remove(habit);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> FertilizingHabitExists(int id)
        {
            return await dbContext.FertilizingHabits.AnyAsync(c => c.Id == id);
        }




        public async Task<Plant_FertilizingHabit> GetPlantFertilizingHabitById(int plantId, int fertilizingHabitId)
        {
            return await dbContext.Plants_FertilizingHabits.Where(c => c.PlantId == plantId && c.FertilizingHabitId == fertilizingHabitId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantFertilizingHabitJoin(Plant_FertilizingHabit join)
        {
            dbContext.Plants_FertilizingHabits.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantFertilizingHabit(Plant_FertilizingHabit plantFertilizingHabit)
        {
            dbContext.Remove(plantFertilizingHabit);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
