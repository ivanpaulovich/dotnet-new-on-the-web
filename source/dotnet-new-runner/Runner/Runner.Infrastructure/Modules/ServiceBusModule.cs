namespace Runner.Infrastructure.Modules
{
    using Autofac;
    using Runner.Application.ServiceBus;
    using Runner.Infrastructure.ServiceBus;

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
                .As<IPublisher>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
        }
    }
}
