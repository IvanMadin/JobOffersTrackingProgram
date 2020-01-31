using JOTCA.Database;
using JOTCA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Services
{
    public class CompaniesService
    {
        private readonly JOTCAContext context;

        public CompaniesService(JOTCAContext context)
        {
            this.context = context;
        }

        public Company AddCompany(string companyName, string email)
        {
            var newCompany = new Company { Name = companyName, Email = email };
            this.context.Companies.Add(newCompany);
            this.context.SaveChanges();

            return newCompany;
        }
    }
}
