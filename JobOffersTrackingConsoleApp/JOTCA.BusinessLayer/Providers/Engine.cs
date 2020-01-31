using JOTCA.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JOTCA.BusinessLayer.Providers
{
    public class Engine
    {
        private readonly CommandFactory commandFactory;

        public Engine(CommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Run()
        {
            StringBuilder allResults = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                try
                {
                    var result = this.commandFactory.InvokeCommand(input).Execute();

                    Console.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
