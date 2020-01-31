using JOTCA.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOTCA.Database.Configurations
{
    internal class LoggingChangesConfigurations : IEntityTypeConfiguration<LoggingChanges>
    {
        public void Configure(EntityTypeBuilder<LoggingChanges> builder)
        {
            builder
                .HasKey(lc => lc.Id);

            builder
                .HasOne(lc => lc.Company)
                .WithMany(c => c.LoggingChanges)
                .HasForeignKey(lc => lc.CompanyId);

            builder
                .Property(lc => lc.DateOfChanging)
                .ValueGeneratedOnAdd()
                .IsRequired(true);
        }
    }
}