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
    public class RegistrationConfigurations : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(r => r.Student)
                .WithOne(s => s.Registration)
                .HasForeignKey<Registration>(r => r.StudentCode)
                .HasPrincipalKey<Student>(s => s.Code);

            builder.HasOne(r => r.Plan)
                .WithMany(f => f.Registrations)
                .HasForeignKey(r => r.PlanCode)
                .HasPrincipalKey(f => f.Code);
        }
    }
}
