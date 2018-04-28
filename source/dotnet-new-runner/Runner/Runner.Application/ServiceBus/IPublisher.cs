namespace Runner.Application.ServiceBus
{
    using Runner.Domain;

    public interface IPublisher
    {
        void Publish(IEntity entity);
    }
}
