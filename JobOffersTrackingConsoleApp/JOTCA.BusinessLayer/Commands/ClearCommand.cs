using JOTCA.BusinessLayer.Commands.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Commands
{
    public class ClearCommand : ICommand
    {
        public string Execute()
        {
            Console.Clear();
            return "==>";
        }
    }
}
