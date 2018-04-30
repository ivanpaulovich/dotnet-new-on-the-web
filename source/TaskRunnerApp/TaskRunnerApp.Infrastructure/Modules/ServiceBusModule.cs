namespace TaskRunnerApp.Infrastructure.Modules
{
    using Autofac;
    using TaskRunnerApp.Application.ServiceBus;
    using TaskRunnerApp.Infrastructure.ServiceBus;

    public class ServiceBusModule : Autofac.Module
    {
        public string BrokerList { get; set; }
        public string Topic { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register the ISubscriber
            //
            builder.RegisterType<Bus>()
                .As<ISubscriber>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
        }
    }
}
