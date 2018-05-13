namespace Cart.Domain.Templates
{
    using Cart.Domain.ValueObjects;
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
        public virtual string CommandLines { get; protected set; }

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
            this.CommandLines = GetCommandlines();
        }

        public string GetCommandlines()
        {
            StringBuilder script = new StringBuilder();

            script.AppendLine("dotnet new hexagonal \\");
            script.AppendLine($"\t--use-cases { UseCases.ToString() } \\");
            script.AppendLine($"\t--data-access { DataAccess.ToString() } \\");
            script.AppendLine($"\t--user-interface { UserInterface.ToString() } \\");
            script.AppendLine($"\t--tips { Tips.ToString() } \\");
            script.AppendLine($"\t--skip-restore { SkipRestore.ToString() } \\");
            script.AppendLine($"\t--name '{ Name.ToString()}'");

            string output = script.ToString();
            return output;
        }
    }
}
