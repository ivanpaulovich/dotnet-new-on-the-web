namespace Cart.Domain.Templates
{
    using Cart.Domain.ValueObjects;
    using System;
    using System.Text;

    public class CleanTemplate : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual UseCases UseCases { get; protected set; }
        public virtual UserInterface UserInterface { get; protected set; }
        public virtual DataAccess DataAccess { get; protected set; }
        public virtual Tips Tips { get; protected set; }
        public virtual SkipRestore SkipRestore { get; protected set; }
        public virtual DateTime OrderUtcDate { get; protected set; }
        public virtual string CommandLines { get; protected set; }

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
            this.CommandLines = GetCommandlines();
        }

        private string GetCommandlines()
        {
            StringBuilder script = new StringBuilder();

            script.AppendLine("dotnet new clean \\");
            script.AppendLine($"--use-cases { UseCases.ToString() } \\");
            script.AppendLine($"--data-access { DataAccess.ToString() } \\");
            script.AppendLine($"--user-interface { UserInterface.ToString() } \\");
            script.AppendLine($"--tips { Tips.ToString() } \\");
            script.AppendLine($"--skip-restore { SkipRestore.ToString() } \\");
            script.AppendLine($"--name '{ Name.ToString()}'");

            string output = script.ToString();
            return output;
        }
    }
}
