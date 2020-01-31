using JOTCA.Database;
using JOTCA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Services
{
    public class JobOffersService
    {
        private readonly JOTCAContext context;

        public JobOffersService(JOTCAContext context)
        {
            this.context = context;
        }

        public string AddOffer(int companyId, DateTime dateOfsending, string position)
        {
            this.context.JobOffers.Add(new JobOffer { CompanyId = companyId, DateOfSendingEmail = dateOfsending, Position = position });
            this.context.SaveChanges();

            return "Succesfully added Offer to DB";
        }
    }
}
