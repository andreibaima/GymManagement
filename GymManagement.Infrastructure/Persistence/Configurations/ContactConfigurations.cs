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
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Student)
                .WithOne(s => s.Contact)
                .HasForeignKey<Contact>(c => c.StudentCode)
                .HasPrincipalKey<Student>(s => s.Code)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
