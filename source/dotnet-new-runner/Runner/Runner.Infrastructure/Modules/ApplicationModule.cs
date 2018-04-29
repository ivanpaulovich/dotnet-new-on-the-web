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
                .InstancePerLifetimeScope();

            builder.RegisterType<Application.UseCases.Tracking.TrackOrder.Interactor>()
                .As<IInputBoundary<Application.UseCases.Tracking.TrackOrder.Input>>()
                .WithParameter("downloadUrlBase", DownloadUrlBase)
                .SingleInstance();
        }
    }
}