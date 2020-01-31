using JOTCA.Database.Configurations;
using JOTCA.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace JOTCA.Database
{
    public class JOTCAContext : DbContext
    {
        public JOTCAContext(DbContextOptions options) : base(options)
        {
        }
        public JOTCAContext()
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<LoggingChanges> LoggingChanges { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                const string connectionString = @"Server=.\SQLEXPRESS;Database=JobOffers;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<Company>(new CompanyConfigurations());
            builder.ApplyConfiguration<JobOffer>(new JobOffersConfigurations());
            builder.ApplyConfiguration<LoggingChanges>(new LoggingChangesConfigurations());
        }
    }
}
