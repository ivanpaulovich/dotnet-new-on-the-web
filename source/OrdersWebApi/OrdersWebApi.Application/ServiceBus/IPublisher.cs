namespace OrdersWebApi.Application.ServiceBus
{
    using OrdersWebApi.Domain;

    public interface IPublisher
    {
        void Publish(IEntity entity);
    }
}
