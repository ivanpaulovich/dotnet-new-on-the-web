namespace Runner.WorkerConsole.UseCases.RunHexagonalTemplate
{
    using System;

    public class Request
    {
        public Guid OrderId { get; private set; }
        public string Name { get; private set; }
        public string UseCases { get; private set; }
        public string UserInterface { get; private set; }
        public string DataAccess { get; private set; }
        public string Tips { get; private set; }
        public string SkipRestore { get; private set; }

        public Request(
            Guid orderId,
            string name,
            string useCases,
            string userInterface,
            string dataAccess,
            string tips,
            string skipRestore)
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
