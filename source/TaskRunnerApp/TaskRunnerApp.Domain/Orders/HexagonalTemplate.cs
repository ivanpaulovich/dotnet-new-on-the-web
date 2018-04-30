namespace TaskRunnerApp.Domain.Templates
{
    using TaskRunnerApp.Domain.ValueObjects;
    using System;
    using System.Text;

    public class HexagonalTemplate : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual UseCases UseCases { get; protected set; }
        public virtual UserInterface UserInterface { get; protected set; }
        public virtual DataAccess DataAccess { get; protected set; }
        public virtual Tips Tips { get; protected set; }
        public virtual SkipRestore SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }

        public HexagonalTemplate(
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

        public string GetCommandlines()
        {
            StringBuilder script = new StringBuilder();

            script.Append(@"dotnet new hexagonal \");
            script.Append($@"--use-cases { UseCases.ToString() }\");
            script.Append($@"--data-access { DataAccess.ToString() }\");
            script.Append($@"--user-interface { UserInterface.ToString() }\");
            script.Append($@"--tips { Tips.ToString() }\");
            script.Append($@"--skip-restore { SkipRestore.ToString() }\");

            string output = script.ToString();
            return output;
        }
    }
}
