namespace OrdersWebApi.Infrastructure.Modules
{
    using Autofac;
    using OrdersWebApi.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in OrdersWebApi.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
