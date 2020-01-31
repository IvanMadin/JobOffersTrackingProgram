using System;
using System.Collections.Generic;
using System.Text;

namespace JOTCA.BusinessLayer.Providers
{
    public class RWConsoleHelper
    {

        public string InputHelper(string output)
        {
            Console.Write($"{output}: ");
            return Console.ReadLine();
        }
    }
}
