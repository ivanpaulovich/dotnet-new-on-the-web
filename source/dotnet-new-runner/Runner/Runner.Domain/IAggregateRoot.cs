namespace Runner.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}