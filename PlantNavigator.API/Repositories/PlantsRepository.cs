﻿using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
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




        public async Task<IEnumerable<Plant>> GetAll(Expression<Func<Plant, bool>> predicate = null)
        {
            var all = dbContext.Set<Plant>().AsNoTracking();

            if (predicate != null)
            {
                all = all.Where(predicate);
            }

            all = all.Include(p => p.WaterCondition).Include(p => p.LightCondition);

            return await all.ToListAsync();
        }

    }
}
