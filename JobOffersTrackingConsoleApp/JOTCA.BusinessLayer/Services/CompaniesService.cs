using JOTCA.Database;
using JOTCA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var company = this.FindCompany(companyName);

            if (company is null)
            {
                var newCompany = new Company { Name = companyName, Email = email };
                this.context.Companies.Add(newCompany);
                this.context.SaveChanges();

                return newCompany;
            }

            return company;
        }

        private Company FindCompany(string companyName)
        {
            var company = this.context.Companies.FirstOrDefault(c => c.Name == companyName);
            return company;
        }
    }
}
