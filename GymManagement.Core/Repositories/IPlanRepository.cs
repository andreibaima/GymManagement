using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Repositories
{
    public interface IPlanRepository
    {
        Task<List<Plan>> GetAllAsync();
        Task<Plan> GetByCodeAsync(string Code);
        Task AddAsync(Plan plan);
        Task SalveChangesAsync();
        Task DeletePlanAsync(Plan plan);
    }
}
