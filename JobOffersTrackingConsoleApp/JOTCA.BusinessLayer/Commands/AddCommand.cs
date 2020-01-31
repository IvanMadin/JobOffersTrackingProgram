using JOTCA.BusinessLayer.Commands.Abstraction;
using JOTCA.BusinessLayer.Providers;
using JOTCA.BusinessLayer.Services;
using System;
using JOTCA.BusinessLayer.Utilities;
using System.Collections.Generic;
using System.Text;
using JOTCA.Database.Entities;

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
            string companyName = helper.InputHelper(ConstantText.ENTER_COMPANY_NAME);
            string companyEmail = helper.InputHelper(ConstantText.ENTER_EMAIL);
            string position = helper.InputHelper(ConstantText.ENTER_POSITION);
            DateTime dateOfSending = DateTime.Parse(helper.InputHelper(ConstantText.ENTER_SENDING));
            string location = helper.InputHelper(ConstantText.ENTER_LOCATION);


            var companyId = this.companiesService.AddCompany(companyName, companyEmail).Id;
            this.offersService.AddOffer(companyId, dateOfSending, position, location);

            return ConstantText.SUCCESSFULLY_ADDED_OFFER;
        }
    }
}
