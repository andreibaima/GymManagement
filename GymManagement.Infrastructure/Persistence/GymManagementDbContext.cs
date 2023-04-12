using GymManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.Persistence
{
    public class GymManagementDbContext : DbContext
    {
        public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanModality> PlanModalities { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<MonthlyPayment> MonthlyPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // carregar todas configurações a partir do Assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
