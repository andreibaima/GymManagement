using Dapper;
using GymManagement.Core.DTOs;
using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GymManagement.Infrastructure.Persistence.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymManagementDbContext _dbContext;
        private readonly string _connectionString;

        public PlanRepository(GymManagementDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("GymManagement");
        }

        public async Task AddAsync(Plan plan)
        {
            await _dbContext.Plans.AddAsync(plan);
        }       

        public async Task<List<PlanDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT  P.Code, P.Description, P.Valor, M.Code, M.Description FROM Plans AS P "
                    + "INNER JOIN PlanModalities AS PM ON P.Code = PM.Plancode " +
                    "INNER JOIN Modalities AS M ON M.Code = PM.ModalityCode ";

                var planosDictionary = new Dictionary<string, PlanDTO>();
                /* QueryAsync recebe três tipos genericos: 
                 * primeiro => é o tipo de objeto que você deseja mapear
                 * segundo => tipo de objeto que deseja mapear como subobjeto do primeiro objeto
                 * terceiro é o tipo do objeto  que você deseja retornar
                 */
                await sqlConnection.QueryAsync<Plan, Modality, PlanDTO>(
                    script,
                    (plano, modalidade) =>
                    {
                        /* TryGetValue verifica se já adicionamos o plano ao dicionário. Se Sim, adicionamos a modalidade a lista 
                         * de modalidades do plano. Se não adicionamos o pklano ao dicionário e inicializamos sua lista de modalidades
                         */
                        if (!planosDictionary.TryGetValue(plano.Code, out PlanDTO planoEntry))
                        {
                            planoEntry = new PlanDTO() {
                                Code = plano.Code,
                                Description = plano.Description,
                                Valor = plano.Valor,
                                Modalities = new List<Modality>(),
                            };

                            planosDictionary.Add(planoEntry.Code, planoEntry);
                        }

                        planoEntry.Modalities.Add(modalidade);
                        return planoEntry;
                    },
                    splitOn: "Code, Code"
                );
                return planosDictionary.Values.ToList();
            }
            //return await _dbContext.Plans.ToListAsync();
        }

        public async Task<Plan> GetByCodeAsync(string code)
        {
            return await _dbContext.Plans.FirstOrDefaultAsync(p => p.Code == code);
            /* return await _dbContext.Plans
                .Include(p => p.Modalities)
                .ThenInclude(m => m.Modality)
                .FirstOrDefaultAsync(p => p.Code == Code);*/
        }

        public async Task SalveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePlanAsync(Plan plan)
        {
            _dbContext.Remove(plan);
        }        

        public async Task<List<PlanModality>> GetPlanModalities(string codePlan)
        {
            return await _dbContext.PlanModalities
                .Include(pm => pm.Modality)
                .Where(pm => pm.Plancode == codePlan).AsNoTracking().ToListAsync();
        }
        public async Task DeletePlanModalities(List<PlanModality> planModalities)
        {
             _dbContext.RemoveRange(planModalities);
        }
    }
}
