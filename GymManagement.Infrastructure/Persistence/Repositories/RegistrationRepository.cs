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
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly GymManagementDbContext _context;

        public RegistrationRepository(GymManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Registration registration)
        {
            await _context.Registrations.AddAsync(registration);
        }

        public async Task DeleteAsync(Registration registration)
        {
            _context.RemoveRange(registration);
        }

        public async Task<IEnumerable<Registration>> GetAllAsync()
        {
            return await _context.Registrations
                .Include(r => r.Student)
                .Include(r => r.Plan)
                .ToListAsync();
        }

        public async Task<Registration> GetByCodeAsync(string code)
        {
            return await _context.Registrations.FirstOrDefaultAsync(r => r.Code == code);
        }

        public async Task<Registration> GetByCodeStudentAsync(string code)
        {
            return await _context.Registrations.FirstOrDefaultAsync(r => r.StudentCode == code && r.IsActive);
        }


        public async Task SalveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Registration registration)
        {
            throw new NotImplementedException();
        }
    }
}
