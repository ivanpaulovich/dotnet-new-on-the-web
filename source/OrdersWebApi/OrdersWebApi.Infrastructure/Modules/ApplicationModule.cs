namespace OrdersWebApi.Infrastructure.Modules
{
    using Autofac;
    using OrdersWebApi.Application;

    public class ApplicationModule : Autofac.Module
    {
        public string DownloadUrlBase { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in OrdersWebApi.Application
            //
            builder.RegisterAssemblyTypes(typeof(IOutputConverter).Assembly)
                .AsImplementedInterfaces()
                .WithParameter("downloadUrlBase", DownloadUrlBase)
                .InstancePerLifetimeScope();
        }
    }
}