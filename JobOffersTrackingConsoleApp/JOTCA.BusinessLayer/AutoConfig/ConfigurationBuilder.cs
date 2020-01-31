using Autofac;
using JOTCA.BusinessLayer.Commands;
using JOTCA.BusinessLayer.Commands.Abstraction;
using JOTCA.BusinessLayer.Providers;
using JOTCA.BusinessLayer.Services;
using JOTCA.Database;
using System.Linq;
using System.Reflection;

namespace JOTCA.BusinessLayer.AutoConfig
{
    public static class ConfigurationBuilder
    {
        public static IContainer RunBuilder()
        {
            ContainerBuilder container = new ContainerBuilder();

            container.RegisterType<JOTCAContext>().SingleInstance().AsSelf();
            container.RegisterType<CommandFactory>().AsSelf();
            container.RegisterType<Engine>().AsSelf();
            container.RegisterType<JobOffersService>().AsSelf();
            container.RegisterType<CompaniesService>().AsSelf();
            container.RegisterType<RWConsoleHelper>().AsSelf();

            RegisterCommans(container);

            return container.Build();
        }

        private static void RegisterCommans(ContainerBuilder container)
        {
            var commands = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(x => x.ImplementedInterfaces.Contains(typeof(ICommand))).ToList();

            commands.ForEach(
                command =>
                container
                .RegisterType(command.AsType())
                .Named<ICommand>(command.Name.ToLower().Substring(0, command.Name.Length - 7)));
        }
    }
}
