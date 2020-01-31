using Autofac;
using JOTCA.BusinessLayer.Commands;
using JOTCA.BusinessLayer.Commands.Abstraction;
using JOTCA.BusinessLayer.Providers;
using JOTCA.BusinessLayer.Services;
using JOTCA.Database;

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

            container.RegisterType<AddCommand>().Named<ICommand>("add").AsSelf();

            return container.Build();
        }
    }
}
