namespace Cart.Infrastructure.Modules
{
    using Autofac;
    using Cart.Infrastructure.Mappings;

    public class InfrastructureModule : Autofac.Module
    {
        public string TrackingUrl { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Cart.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(OutputConverter).Assembly)
                .AsImplementedInterfaces()
                .WithParameter("trackingUrl", TrackingUrl)
                .InstancePerLifetimeScope();
        }
    }
}
