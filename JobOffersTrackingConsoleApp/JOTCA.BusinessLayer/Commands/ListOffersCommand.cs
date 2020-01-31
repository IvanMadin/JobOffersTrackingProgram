using JOTCA.BusinessLayer.Commands.Abstraction;
using JOTCA.BusinessLayer.Services;
using System;
using System.Text;

namespace JOTCA.BusinessLayer.Commands
{
    public class ListOffersCommand : ICommand
    {
        private readonly JobOffersService offersService;

        public ListOffersCommand(JobOffersService offersService)
        {
            this.offersService = offersService;
        }
        public string Execute()
        {
            StringBuilder result = new StringBuilder();
            var jobOffers = offersService.GetAllJobOffers();

            foreach (var jobOffer in jobOffers)
            {
                result.AppendLine(@$"{Environment.NewLine}Company name: {jobOffer.Company.Name} 
Location: {jobOffer.Location}
Status: {jobOffer.Status}
Send On Date: {jobOffer.DateOfSendingEmail.ToShortDateString()}");
            }

            return result.ToString() + $"\r\nNumber of job offers {jobOffers.Count} All job offers are listed above.";
        }
    }
}
