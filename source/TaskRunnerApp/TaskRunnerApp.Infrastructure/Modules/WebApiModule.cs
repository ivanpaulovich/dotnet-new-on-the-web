namespace TaskRunnerApp.Infrastructure.Modules
{
    using Autofac;
    using TaskRunnerApp.Application;
	using System.Reflection;

    public class WebApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in TaskRunnerApp.WebApi
            //
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsClosedTypesOf(typeof(IOutputBoundary<>))
                .InstancePerLifetimeScope();
        }
    }
}
