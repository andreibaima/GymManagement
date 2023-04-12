using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Repositories
{
    public interface IModalityRepository
    {
        Task<List<Modality>> GetAllAsync();
        Task<Modality> GetByCodeAsync(string code);
        Task AddAsync(Modality modality);
        Task SalveChangesAsync();

        Task DeleteAsync(Modality modality);
    }
}
