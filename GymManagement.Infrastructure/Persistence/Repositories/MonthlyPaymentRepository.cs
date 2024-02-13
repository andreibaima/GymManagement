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
    public class MonthlyPaymentRepository : IMonthlyPaymentsRepository
    {
        private readonly GymManagementDbContext _context;

        public MonthlyPaymentRepository(GymManagementDbContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(MonthlyPayment monthlyPayment)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsyncRange(List<MonthlyPayment> monthlyPaymentList)
        {
            _context.RemoveRange(monthlyPaymentList);
        }

        public Task<List<MonthlyPayment>> GetAllAsync()
        {
            return _context.MonthlyPayments
                .Include(mp => mp.Registration)
                .ThenInclude(r => r.Student)
                .ToListAsync();
        }

        public async Task<List<MonthlyPayment>> GetByCodeRegistrationAsync(string code)
        {
            return await _context.MonthlyPayments.Where(mp => mp.RegistrationCode == code).ToListAsync();
        }

        public async Task<MonthlyPayment> GetById(int Id)
        {
            return await _context.MonthlyPayments.FirstOrDefaultAsync(mp => mp.Id == Id);
        }

        public async Task MakePayment(MonthlyPayment monthlyPayment)
        {
            _context.Update(monthlyPayment);
        }

        public async Task SalveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
