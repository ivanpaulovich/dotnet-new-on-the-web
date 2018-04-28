namespace Runner.WorkerConsole.UseCases.GenerateClean
{
    public class CleanRequest
    {
        public string Name { get; private set; }
        public string UseCases { get; private set; }
        public string UserInterface { get; private set; }
        public string DataAccess { get; private set; }
        public string Tips { get; private set; }
        public string SkipRestore { get; private set; }

        public CleanRequest(
            string name,
            string useCases,
            string userInterface,
            string dataAccess,
            string tips,
            string skipRestore)
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
