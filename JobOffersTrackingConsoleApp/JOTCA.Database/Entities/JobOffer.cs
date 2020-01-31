using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.Database.Entities
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public ReplyType Status { get; set; }
        public CityLocation Location { get; set; }
        public DateTime DateOfSendingEmail { get; set; }
        public DateTime? DateOfReceivingReply { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public enum ReplyType
    {
        WaitingForReply = 0,
        WaitingforOffer = 1,
        ReceivedRejection = 2,
        Approved = 3
    }
    public enum CityLocation
    {
        Sofia = 0,
        Plovdiv = 1
    }
}
