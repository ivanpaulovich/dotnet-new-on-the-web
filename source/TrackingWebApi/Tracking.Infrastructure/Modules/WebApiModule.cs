namespace Tracking.Infrastructure.Modules
{
    using Autofac;
    using Tracking.Application;
	using System.Reflection;

    public class WebApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Tracking.WebApi
            //
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}
