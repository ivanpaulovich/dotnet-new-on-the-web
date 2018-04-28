namespace Runner.Domain.Templates
{
    using Runner.Domain.ValueObjects;
    using System;

    public class CleanTemplate : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual UseCases UseCases { get; protected set; }
        public virtual UserInterface UserInterface { get; protected set; }
        public virtual DataAccess DataAccess { get; protected set; }
        public virtual Tips Tips { get; protected set; }
        public virtual SkipRestore SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }

        public CleanTemplate(
            Name name,
            UseCases useCases,
            UserInterface userInterface,
            DataAccess dataAccess,
            Tips tips,
            SkipRestore skipRestore)
        {
            this.Name = name;
            this.UseCases = useCases;
            this.UserInterface = userInterface;
            this.DataAccess = dataAccess;
            this.Tips = tips;
            this.SkipRestore = skipRestore;
            this.OrderUtcDate = DateTime.UtcNow;
        }
    }
}
