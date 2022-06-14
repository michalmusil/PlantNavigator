using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class WateringHabitsRepository : IWateringHabitsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public WateringHabitsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WateringHabit>> GetAll(int? plantId, bool? includeAsociatedPlants)
        {
            var all = dbContext.Set<WateringHabit>().AsNoTracking();

            if (includeAsociatedPlants == true)
            {
                all = all.Include(h => h.Plant_WateringHabits);
            }

            if (plantId != null)
            {
                all = all.Where(h => h.Plant_WateringHabits.Any(p => p.PlantId == plantId));
            }

            return await all.ToListAsync();
        }

        public async Task<WateringHabit> GetById(int id)
        {
            return await dbContext.WateringHabits.Include(h => h.Plant_WateringHabits).Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddWateringHabit(WateringHabit habit)
        {
            dbContext.WateringHabits.Add(habit);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateWateringHabit(WateringHabit habit)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteWateringHabit(WateringHabit habit)
        {
            dbContext.Remove(habit);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> WateringHabitExists(int id)
        {
            return await dbContext.WateringHabits.AnyAsync(c => c.Id == id);
        }




        public async Task<Plant_WateringHabit> GetPlantWateringHabitById(int plantId, int wateringHabitId)
        {
            return await dbContext.Plants_WateringHabits.Where(c => c.PlantId == plantId && c.WateringHabitId == wateringHabitId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantWateringHabitJoin(Plant_WateringHabit join)
        {
            dbContext.Plants_WateringHabits.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantWateringHabit(Plant_WateringHabit plantWateringHabit)
        {
            dbContext.Remove(plantWateringHabit);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
