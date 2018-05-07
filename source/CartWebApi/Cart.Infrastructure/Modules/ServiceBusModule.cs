namespace Cart.Infrastructure.Modules
{
    using Autofac;
    using Cart.Application.ServiceBus;
    using Cart.Infrastructure.ServiceBus;

    public class ServiceBusModule : Autofac.Module
    {
        public string BrokerList { get; set; }
        public string Topic { get; set; }
        public int NumberOfPartitions { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register the ISubscriber
            //
            builder.RegisterType<Bus>()
                .As<IPublisher>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .WithParameter("numberOfPartitions", NumberOfPartitions)
                .SingleInstance();
        }
    }
}
