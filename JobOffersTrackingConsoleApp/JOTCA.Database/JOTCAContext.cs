using JOTCA.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
            builder.Entity<Company>().HasKey(c => c.Id);
            builder.Entity<Company>().HasMany(c => c.JobOffers).WithOne(jo => jo.Company).HasForeignKey(jo => jo.CompanyId);
            builder.Entity<Company>().HasMany(c => c.LoggingChanges).WithOne(lc => lc.Company).HasForeignKey(lc => lc.CompanyId);

            builder.Entity<JobOffer>().HasKey(jo => jo.Id);
            builder.Entity<JobOffer>().HasOne(jo => jo.Company).WithMany(c => c.JobOffers).HasForeignKey(jo => jo.CompanyId);
            builder.Entity<JobOffer>().Property(jo => jo.DateOfReceivingReply).IsRequired(false);
            builder.Entity<JobOffer>().Property(jo => jo.DateOfSendingEmail).IsRequired(true);
            builder.Entity<JobOffer>().Property(jo => jo.Position).IsRequired(false);
            builder.Entity<JobOffer>().Property(jo => jo.Status).HasConversion(tstr => tstr.ToString(), x => (ReplyType)Enum.Parse(typeof(ReplyType), x));

            builder.Entity<LoggingChanges>().HasKey(lc => lc.Id);
            builder.Entity<LoggingChanges>().HasOne(lc => lc.Company).WithMany(c => c.LoggingChanges).HasForeignKey(lc => lc.CompanyId);
            builder.Entity<LoggingChanges>().Property(lc => lc.DateOfChanging).ValueGeneratedOnAdd().IsRequired(true);


        }
    }
}
