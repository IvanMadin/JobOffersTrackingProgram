using JOTCA.BusinessLayer.Commands.Abstraction;
using JOTCA.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Commands
{
    public class AddCommand : ICommand
    {
        private readonly JobOffersService offersService;

        public AddCommand(JobOffersService offersService)
        {
            this.offersService = offersService;
        }

        public string Execute()
        {
            return "Do Working!!!!";
        }
    }
}
