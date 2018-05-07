namespace Cart.Application.ServiceBus
{
    using Cart.Domain;

    public interface IPublisher
    {
        void Publish(IEntity entity);
    }
}
