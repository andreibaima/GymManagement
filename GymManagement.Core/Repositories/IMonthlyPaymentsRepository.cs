using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Repositories
{
    public interface IMonthlyPaymentsRepository
    {
        Task<List<MonthlyPayment>> GetAllAsync();
        Task<List<MonthlyPayment>> GetByCodeRegistrationAsync(string Code);
        Task<MonthlyPayment> GetById(int Id);
        Task SalveChangesAsync();
        Task DeleteAsync(MonthlyPayment monthlyPayment);
        Task DeleteAsyncRange(List<MonthlyPayment> monthlyPaymentList);
        Task MakePayment(MonthlyPayment model);

    }
}
