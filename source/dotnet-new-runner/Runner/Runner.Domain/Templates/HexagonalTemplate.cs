namespace Runner.Domain.Templates
{
    using System;

    public class HexagonalTemplate : Entity, IAggregateRoot
    {
        public virtual string UseCases { get; protected set; }
        public virtual string UserInterface { get; protected set; }
        public virtual string DataAccess { get; protected set; }
        public virtual string Tips { get; protected set; }
        public virtual string SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }
        public virtual int Version { get; protected set; }

        public HexagonalTemplate(
            string useCases,
            string userInterface,
            string dataAccess,
            string tips,
            string skipRestore)
        {
            this.UseCases = useCases;
            this.UserInterface = userInterface;
            this.DataAccess = dataAccess;
            this.Tips = tips;
            this.SkipRestore = skipRestore;
            this.OrderUtcDate = DateTime.UtcNow;
        }
    }
}
