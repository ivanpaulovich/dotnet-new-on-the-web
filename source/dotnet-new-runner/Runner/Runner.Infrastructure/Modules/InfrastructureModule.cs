namespace Runner.Infrastructure.Modules
{
    using Autofac;
    using Runner.Application.UseCases.Runners;
    using Runner.Infrastructure.Mappings;
    using Runner.Infrastructure.Services;
    using Runner.Infrastructure.Storage;

    public class InfrastructureModule : Autofac.Module
    {
        public string OutputPath { get; set; }
        public string ZipDeliveryPath { get; set; }
        public string StorageAccountName { get; set; }
        public string AccessKey { get; set; }

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

            builder.RegisterType<StorageService>()
                .As<IStorageService>()
                .WithParameter("storageAccountName", StorageAccountName)
                .WithParameter("accessKey", AccessKey)
                .SingleInstance();
        }
    }
}
