namespace TaskRunnerApp.WorkerConsole
{
    using Autofac;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Autofac.Configuration;
    using TaskRunnerApp.WorkerConsole.UseCases;

    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("autofac.json")
                .AddEnvironmentVariables()
                .Build();

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationModule(configuration));

            builder.RegisterInstance(configuration)
                .As<IConfiguration>()
                .SingleInstance();

            builder.RegisterType<ControllerFactory>()
                .As<ControllerFactory>()
                .SingleInstance();

            builder.RegisterType<UseCases.RunCleanTemplate.RunController>()
                .As<UseCases.RunCleanTemplate.RunController>()
                .SingleInstance();

            builder.RegisterType<UseCases.RunEventSourcingTemplate.RunController>()
                .As<UseCases.RunEventSourcingTemplate.RunController>()
                .SingleInstance();

            builder.RegisterType<UseCases.RunHexagonalTemplate.RunController>()
                .As<UseCases.RunHexagonalTemplate.RunController>()
                .SingleInstance();

            IContainer container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                IStartup startup = container.Resolve<IStartup>();
                startup.Run();
            }
        }
    }
}
