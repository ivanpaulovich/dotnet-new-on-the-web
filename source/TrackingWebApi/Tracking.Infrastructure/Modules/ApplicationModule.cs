namespace Tracking.Infrastructure.Modules
{
    using Autofac;
    using Tracking.Application;

    public class ApplicationModule : Autofac.Module
    {
        public string DownloadUrlBase { get; set; }
        public string TrackingUrl { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Tracking.Application
            //
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .WithParameter("downloadUrlBase", DownloadUrlBase)
                .InstancePerLifetimeScope();
        }
    }
}