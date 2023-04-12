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
    public class FlatModalityConfigurations : IEntityTypeConfiguration<PlanModality>
    {
        public void Configure(EntityTypeBuilder<PlanModality> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(fm => fm.Plan)
                .WithMany(f => f.Modalities)
                .HasForeignKey(fm => fm.Plancode)
                .HasPrincipalKey(f => f.Code);

            builder.HasOne(fm => fm.Modality)
                .WithMany(m => m.Plans)
                .HasForeignKey(fm => fm.ModalityCode)
                .HasPrincipalKey(m => m.Code);
        }
    }
}
