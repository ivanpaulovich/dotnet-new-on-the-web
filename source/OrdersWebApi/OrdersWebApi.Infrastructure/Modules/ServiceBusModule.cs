namespace OrdersWebApi.Infrastructure.Modules
{
    using Autofac;
    using OrdersWebApi.Application.ServiceBus;
    using OrdersWebApi.Infrastructure.ServiceBus;

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
