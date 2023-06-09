﻿using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.Persistence.Repositories
{
    public class MonthlyPaymentRepository : IMonthlyPayments
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
            throw new NotImplementedException();
        }

        public async Task<List<MonthlyPayment>> GetByCodeRegistrationAsync(string code)
        {
            return await _context.MonthlyPayments.Where(mp => mp.RegistrationCode == code).ToListAsync();
        }

        public async Task SalveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
