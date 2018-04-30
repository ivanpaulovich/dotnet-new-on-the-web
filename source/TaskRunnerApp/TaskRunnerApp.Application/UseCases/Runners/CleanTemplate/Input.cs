namespace TaskRunnerApp.Application.UseCases.Runners.CleanTemplate
{
    using TaskRunnerApp.Domain.ValueObjects;
    using System;

    public class Input
    {
        public Guid OrderId { get; private set; }
        public Name Name { get; private set; }
        public UseCases UseCases { get; private set; }
        public UserInterface UserInterface { get; private set; }
        public DataAccess DataAccess { get; private set; }
        public Tips Tips { get; private set; }
        public SkipRestore SkipRestore { get; private set; }

        public Input(
            Guid orderId,
            Name name,
            UseCases useCases,
            UserInterface userInterface,
            DataAccess dataAccess,
            Tips tips,
            SkipRestore skipRestore)
        {
            this.OrderId = orderId;
            this.Name = name;
            this.UseCases = useCases;
            this.UserInterface = userInterface;
            this.DataAccess = dataAccess;
            this.Tips = tips;
            this.SkipRestore = skipRestore;
        }
    }
}
