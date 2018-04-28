namespace Runner.Infrastructure.Modules
{
    using Autofac;
    using Runner.Application.Services;
    using Runner.Infrastructure.Mappings;
    using Runner.Infrastructure.Services;

    public class InfrastructureModule : Autofac.Module
    {
        public string OutputPath { get; set; }
        public string ZipDeliveryPath { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Runner.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CajuService>()
                .As<ICajuService>()
                .WithParameter("outputPath", OutputPath)
                .WithParameter("zipDeliveryPath", ZipDeliveryPath)
                .SingleInstance();
        }
    }
}
