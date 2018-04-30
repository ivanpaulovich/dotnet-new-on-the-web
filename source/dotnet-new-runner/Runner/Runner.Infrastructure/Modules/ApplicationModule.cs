namespace Runner.Infrastructure.Modules
{
    using Autofac;
    using Runner.Application;

    public class ApplicationModule : Autofac.Module
    {
        public string DownloadUrlBase { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Runner.Application
            //
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .WithParameter("downloadUrlBase", DownloadUrlBase)
                .InstancePerLifetimeScope();
        }
    }
}