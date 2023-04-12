using GymManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infrastructure.Persistence.Configurations
{
    public class MonthlyPaymentConfigurations : IEntityTypeConfiguration<MonthlyPayment>
    {
        public void Configure(EntityTypeBuilder<MonthlyPayment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(m => m.Registration)
                .WithMany(r => r.MonthlyPayments)
                .HasForeignKey(r => r.RegistrationCode)
                .HasPrincipalKey(m => m.Code);
        }
    }
}
