namespace Runner.Application.UseCases.GenerateClean
{
    public class GenerateCleanInput
    {
        public string UseCases { get; private set; }
        public string UserInterface { get; private set; }
        public string DataAccess { get; private set; }
        public string Tips { get; private set; }
        public string SkipRestore { get; private set; }

        public GenerateCleanInput(
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
        }
    }
}
