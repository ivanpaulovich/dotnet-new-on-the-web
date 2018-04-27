namespace Runner.Domain.Templates
{
    using System;

    public class CleanTemplate : Entity, IAggregateRoot
    {
        public virtual int Version { get; protected set; }
        public string UseCases { get; protected set; }
        public string UserInterface { get; protected set; }
        public string DataAccess { get; protected set; }
        public string Tips { get; protected set; }
        public string SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }
        public object CommandLines { get; set; }

        public CleanTemplate(
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
