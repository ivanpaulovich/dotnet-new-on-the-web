namespace TaskRunnerApp.Infrastructure.Modules
{
    using Autofac;
    using TaskRunnerApp.Application;

    public class ApplicationModule : Autofac.Module
    {
        public string DownloadUrlBase { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in TaskRunnerApp.Application
            //
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}