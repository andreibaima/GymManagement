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
    public class ModalityRepository : IModalityRepository
    {
        private GymManagementDbContext _dbContext;

        public ModalityRepository(GymManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Modality modality)
        {
            await _dbContext.Modalities.AddAsync(modality);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Modality modality)
        {
            _dbContext.Remove(modality);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Modality>> GetAllAsync()
        {
            return await _dbContext.Modalities.ToListAsync();
        }

        public async Task<Modality> GetByCodeAsync(string code)
        {
            return await _dbContext.Modalities.FirstOrDefaultAsync(m => m.Code == code);
        }

        public async Task SalveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
