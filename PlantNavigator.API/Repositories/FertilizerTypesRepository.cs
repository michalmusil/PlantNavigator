using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class FertilizerTypesRepository : IFertilizerTypesRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public FertilizerTypesRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<FertilizerType>> GetAll(string? typeName, int? plantId)
        {
            var all = dbContext.Set<FertilizerType>().AsNoTracking();

            if (typeName != null)
            {
                all = all.Where(t => t.Name.ToLower().Contains(typeName.ToLower()));
            }

            if (plantId != null)
            {
                all = all.Where(h => h.FertilizingHabit_FertilizerTypes.Any(p => p.FertilizingHabit.Plant_FertilizingHabits.Any(x => x.PlantId == plantId)));
            }

            return await all.ToListAsync();
        }

        public async Task<FertilizerType> GetById(int id)
        {
            return await dbContext.FertilizerTypes.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddFertilizerType(FertilizerType type)
        {
            dbContext.FertilizerTypes.Add(type);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFertilizerType(FertilizerType type)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFertilizerType(FertilizerType type)
        {
            dbContext.Remove(type);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> FertilizerTypeExists(int id)
        {
            return await dbContext.FertilizerTypes.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> FertilizingHabitExists(int id)
        {
            return await dbContext.FertilizingHabits.AnyAsync(c => c.Id == id);
        }



        public async Task<FertilizingHabit_FertilizerType> GetFertilizingHabitFertilizerTypeById(int FertilizingHabitId, int FertilizerTypeId)
        {
            return await dbContext.FertilizingHabits_FertilizerTypes.Where(c => c.FertilizingHabitId == FertilizingHabitId && c.FertilizerTypeId == FertilizerTypeId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddFertilizingHabitFertilizerTypeJoin(FertilizingHabit_FertilizerType join)
        {
            dbContext.FertilizingHabits_FertilizerTypes.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteFertilizingHabitFertilizerType(FertilizingHabit_FertilizerType FertilizingHabitFertilizerType)
        {
            dbContext.Remove(FertilizingHabitFertilizerType);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}

