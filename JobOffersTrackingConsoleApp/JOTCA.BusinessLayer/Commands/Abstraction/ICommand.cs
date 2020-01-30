using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Commands.Abstraction
{
    public interface ICommand
    {
        string Execute();
    }
}
