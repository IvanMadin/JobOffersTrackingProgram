using System;
using System.Collections.Generic;
using Autofac;
using JOTCA.Database;

namespace JobOffersTrackingConsoleApp.AutoConfig
{
    public static class ConfigurationBuilder
    {
        public static IContainer RunBuilder()
        {
            ContainerBuilder container = new ContainerBuilder();

            container.RegisterType<Service>().AsSelf();
            container.RegisterType<JOTCAContext>().AsSelf();

            return container.Build();
        }
    }
}
