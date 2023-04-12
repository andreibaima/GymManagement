using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.Persistence.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymManagementDbContext _dbContext;

        public PlanRepository(GymManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Plan plan)
        {
            await _dbContext.Plans.AddAsync(plan);
        }       

        public async Task<List<Plan>> GetAllAsync()
        {
            return await _dbContext.Plans.ToListAsync();
        }

        public async Task<Plan> GetByCodeAsync(string Code)
        {
            return await _dbContext.Plans.FirstOrDefaultAsync(p => p.Code == Code);
        }

        public async Task SalveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePlanAsync(Plan plan)
        {
            _dbContext.Remove(plan);
            await _dbContext.SaveChangesAsync();
        }
    }
}
