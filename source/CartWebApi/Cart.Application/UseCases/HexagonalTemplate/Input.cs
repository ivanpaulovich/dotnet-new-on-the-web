namespace Cart.Application.UseCases.HexagonalTemplate
{
    using Cart.Domain.ValueObjects;

    public class Input
    {
        public Name Name { get; private set; }
        public UseCases UseCases { get; private set; }
        public UserInterface UserInterface { get; private set; }
        public DataAccess DataAccess { get; private set; }
        public Tips Tips { get; private set; }
        public SkipRestore SkipRestore { get; private set; }

        public Input(
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
        }
    }
}
