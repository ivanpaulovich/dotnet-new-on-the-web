namespace Runner.WorkerConsole
{
    using Autofac;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Autofac.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("autofac.json")
                .AddEnvironmentVariables()
                .Build();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationModule(configuration));

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {

            }
        }
    }
}
