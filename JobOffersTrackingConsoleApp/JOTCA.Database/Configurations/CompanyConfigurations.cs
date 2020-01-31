using JOTCA.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOTCA.Database.Configurations
{
    internal class CompanyConfigurations : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasMany(c => c.JobOffers)
                .WithOne(jo => jo.Company)
                .HasForeignKey(jo => jo.CompanyId);

            builder
                .HasMany(c => c.LoggingChanges)
                .WithOne(lc => lc.Company)
                .HasForeignKey(lc => lc.CompanyId);
        }
    }
}