using JOTCA.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobOffersTrackingConsoleApp
{
    public class Service
    {
        private readonly JOTCAContext context;
        public Service(JOTCAContext context)
        {
            this.context = context;
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if(input == "exit")
                {
                    break;
                }

                AddToDb("Asd", "asag");
            }
        }
        public void AddToDb(string name, string email)
        {
            this.context.Companies.Add(new JOTCA.Database.Entities.Company
            {
                Name = name,
                Email = email
            });
            this.context.SaveChanges();
        }
    }
}
