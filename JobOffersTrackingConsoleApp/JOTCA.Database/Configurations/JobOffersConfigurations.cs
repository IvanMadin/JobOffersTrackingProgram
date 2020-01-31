using JOTCA.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JOTCA.Database.Configurations
{
    internal class JobOffersConfigurations : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            builder
                .HasKey(jo => jo.Id);

            builder
                .HasOne(jo => jo.Company)
                .WithMany(c => c.JobOffers)
                .HasForeignKey(jo => jo.CompanyId);

            builder
                .Property(jo => jo.DateOfReceivingReply)
                .IsRequired(false);

            builder
                .Property(jo => jo.DateOfSendingEmail)
                .IsRequired(true);

            builder
                .Property(jo => jo.Position)
                .IsRequired(false);

            builder
                .Property(jo => jo.Status)
                .HasConversion(tstr => tstr.ToString(), x => (ReplyType)Enum.Parse(typeof(ReplyType), x));

            builder
                .Property(jo => jo.Location)
                .HasConversion(tstr => tstr.ToString(), x => (CityLocation)Enum.Parse(typeof(CityLocation), x));
        }
    }
}