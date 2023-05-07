using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Repositories
{
    public interface IMonthlyPayments
    {
        Task<List<MonthlyPayment>> GetAllAsync();
        Task<List<MonthlyPayment>> GetByCodeRegistrationAsync(string Code);
        Task SalveChangesAsync();
        Task DeleteAsync(MonthlyPayment monthlyPayment);
        Task DeleteAsyncRange(List<MonthlyPayment> monthlyPaymentList);

    }
}
