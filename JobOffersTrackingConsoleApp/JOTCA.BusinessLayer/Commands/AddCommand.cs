using JOTCA.BusinessLayer.Commands.Abstraction;
using JOTCA.BusinessLayer.Providers;
using JOTCA.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Commands
{
    public class AddCommand : ICommand
    {
        private readonly JobOffersService offersService;
        private readonly CompaniesService companiesService;
        private readonly RWConsoleHelper helper;

        public AddCommand(JobOffersService offersService, CompaniesService companiesService, RWConsoleHelper helper)
        {
            this.offersService = offersService;
            this.companiesService = companiesService;
            this.helper = helper;
        }

        public string Execute()
        {
            string companyName = helper.InputHelper("Enter Company Name: ");
            string companyEmail = helper.InputHelper("Enter E-mail: ");
            string position = helper.InputHelper("Enter Position Name: ");
            string dateOfSending = helper.InputHelper("Enter Date Of Sending: ");
            var asd = DateTime.Parse(dateOfSending);

            var companyId = this.companiesService.AddCompany(companyName, companyEmail).Id;
            this.offersService.AddOffer(companyId, asd, position);
            return "Do Working!!!!";
        }
    }
}
