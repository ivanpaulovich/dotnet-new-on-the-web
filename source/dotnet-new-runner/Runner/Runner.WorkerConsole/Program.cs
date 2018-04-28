namespace Runner.WorkerConsole
{
    using Autofac;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Autofac.Configuration;
    using Runner.WorkerConsole.UseCases.GenerateClean;

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

            builder.RegisterType<CleanController>()
                .As<CleanController>()
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
