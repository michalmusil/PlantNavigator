﻿using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class PestsRepository : IPestsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public PestsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Pest>> GetAll(string? name = null)
        {
            var all = dbContext.Set<Pest>().AsNoTracking();

            if (name != null)
            {
                all = all.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            }

            return await all.ToListAsync();
        }

        public async Task<Pest> GetById(int id)
        {
            return await dbContext.Pests.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPest(Pest pest)
        {
            dbContext.Pests.Add(pest);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePest(Pest pest)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePest(Pest pest)
        {
            dbContext.Remove(pest);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> PestExists(int id)
        {
            return await dbContext.Pests.AnyAsync(c => c.Id == id);
        }




        public async Task<Plant_Pest> GetPlantPestById(int plantId, int pestId)
        {
            return await dbContext.Plants_Pests.Where(c => c.PlantId == plantId && c.PestId == pestId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantPestJoin(Plant_Pest join)
        {
            dbContext.Plants_Pests.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantPest(Plant_Pest plantPest)
        {
            dbContext.Remove(plantPest);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
