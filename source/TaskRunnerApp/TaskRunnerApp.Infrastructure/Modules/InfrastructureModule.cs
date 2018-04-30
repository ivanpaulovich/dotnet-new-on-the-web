namespace TaskRunnerApp.Infrastructure.Modules
{
    using Autofac;
    using TaskRunnerApp.Application.UseCases.Runners;
    using TaskRunnerApp.Infrastructure.Mappings;
    using TaskRunnerApp.Infrastructure.Services;
    using TaskRunnerApp.Infrastructure.Storage;

    public class InfrastructureModule : Autofac.Module
    {
        public string OutputPath { get; set; }
        public string ZipDeliveryPath { get; set; }
        public string StorageAccountName { get; set; }
        public string AccessKey { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in TaskRunnerApp.Infrastructure
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
