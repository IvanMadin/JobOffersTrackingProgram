using JOTCA.Database;
using JOTCA.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JOTCA.BusinessLayer.Services
{
    public class JobOffersService
    {
        private readonly JOTCAContext context;

        public JobOffersService(JOTCAContext context)
        {
            this.context = context;
        }

        public JobOffer AddOffer(int companyId, DateTime dateOfsending, string position, string inputLocation)
        {

            bool isValid = Enum.TryParse(inputLocation, true, out CityLocation location);

            if (!isValid)
            {
                throw new ArgumentException($"There is no such town like: {inputLocation}");
            }

            var newOffer = new JobOffer
            {
                CompanyId = companyId,
                DateOfSendingEmail = dateOfsending,
                Position = position,
                Location = location
            };

            this.context.JobOffers.Add(newOffer);
            this.context.SaveChanges();

            return newOffer;
        }

        public IReadOnlyCollection<JobOffer> GetAllJobOffers()
        {
            return this.context.JobOffers.Include(j => j.Company).ToList().AsReadOnly();
        }
    }
}
