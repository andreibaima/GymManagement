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
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Student)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.StudentCode)
                .HasPrincipalKey<Student>(s => s.Code)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
