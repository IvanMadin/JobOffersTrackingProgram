using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using JOTCA.BusinessLayer.Commands.Abstraction;

namespace JOTCA.BusinessLayer.Providers
{
    public class CommandFactory
    {
        private readonly IComponentContext componentContext;

        public CommandFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public ICommand InvokeCommand(string commandName)
        {
            bool isCommandFound = this.componentContext.IsRegisteredWithName<ICommand>(commandName.ToLower());

            if(!isCommandFound)
            {
                throw new ArgumentException($"There is no such command name: {commandName}");
            }
            var command = this.componentContext.ResolveNamed<ICommand>(commandName.ToLower());

            return command;
        }
    }
}
