using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.Database.Entities
{
    public class LoggingChanges
    {
        public int Id { get; set; }

        public string OldStatus { get; set; }
        public string ChangeToStatus { get; set; }
        public DateTime DateOfChanging { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
