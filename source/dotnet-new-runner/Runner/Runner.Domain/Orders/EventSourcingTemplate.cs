namespace Runner.Domain.Templates
{
    using System;

    public class EventSourcingTemplate : Entity, IAggregateRoot
    {
        public virtual string Name { get; protected set; }
        public virtual string UseCases { get; protected set; }
        public virtual string UserInterface { get; protected set; }
        public virtual string DataAccess { get; protected set; }
        public virtual string Tips { get; protected set; }
        public virtual string ServiceBus { get; protected set; }
        public virtual string SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }
        public virtual string CommandlinesHint { get; protected set; }

        public EventSourcingTemplate(
            string name,
            string useCases,
            string userInterface,
            string dataAccess,
            string tips,
            string serviceBus,
            string skipRestore)
        {
            this.Name = name;
            this.UseCases = useCases;
            this.UserInterface = userInterface;
            this.DataAccess = dataAccess;
            this.Tips = tips;
            this.ServiceBus = serviceBus;
            this.SkipRestore = skipRestore;
            this.OrderUtcDate = DateTime.UtcNow;
        }
    }
}
