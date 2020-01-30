using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.Database.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<JobOffer> JobOffers { get; set; }
        public ICollection<LoggingChanges> LoggingChanges { get; set; }
    }
}
