namespace Runner.Domain.Templates
{
    using Runner.Domain.ValueObjects;
    using System;
    using System.Text;

    public class EventSourcingTemplate : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual UseCases UseCases { get; protected set; }
        public virtual UserInterface UserInterface { get; protected set; }
        public virtual DataAccess DataAccess { get; protected set; }
        public virtual ServiceBus ServiceBus { get; protected set; }
        public virtual Tips Tips { get; protected set; }
        public virtual SkipRestore SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }

        public EventSourcingTemplate(
            Name name,
            UseCases useCases,
            UserInterface userInterface,
            DataAccess dataAccess,
            ServiceBus serviceBus,
            Tips tips,
            SkipRestore skipRestore)
        {
            this.Name = name;
            this.UseCases = useCases;
            this.UserInterface = userInterface;
            this.DataAccess = dataAccess;
            this.ServiceBus = serviceBus;
            this.Tips = tips;
            this.SkipRestore = skipRestore;
            this.OrderUtcDate = DateTime.UtcNow;
        }

        public string GetCommandlines()
        {
            StringBuilder script = new StringBuilder();

            script.Append(@"dotnet new eventsourcing \");
            script.Append($@"--use-cases { UseCases.ToString() }\");
            script.Append($@"--data-access { DataAccess.ToString() }\");
            script.Append($@"--service-bus { ServiceBus.ToString() }\");
            script.Append($@"--user-interface { UserInterface.ToString() }\");
            script.Append($@"--tips { Tips.ToString() }\");
            script.Append($@"--skip-restore { SkipRestore.ToString() }\");

            string output = script.ToString();
            return output;
        }
    }
}
