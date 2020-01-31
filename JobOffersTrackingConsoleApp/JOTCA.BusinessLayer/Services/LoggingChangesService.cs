using JOTCA.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Services
{
    public class LoggingChangesService
    {
        private readonly JOTCAContext context;

        public LoggingChangesService(JOTCAContext context)
        {
            this.context = context;
        }
    }
}
