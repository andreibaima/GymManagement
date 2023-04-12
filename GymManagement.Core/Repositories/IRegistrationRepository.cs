using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Repositories
{
    public interface IRegistrationRepository
    {
        Task AddAsync(Registration registration);
        Task UpdateAsync(Registration registration);
        Task<Registration> GetByCodeAsync(string code);
        Task<IEnumerable<Registration>> GetAllAsync();
        Task SalveChangesAsync();
        Task DeleteAsync(Registration registration);
    }
}
