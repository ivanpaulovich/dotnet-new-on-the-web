namespace Runner.WebApi.UseCases.OrderEventSourcingTemplate
{
    public class OrderEventSourcingRequest
    {
        public string Name { get; private set; }
        public string UseCases { get; private set; }
        public string UserInterface { get; private set; }
        public string DataAccess { get; private set; }
        public string ServiceBus { get; private set; }
        public string Tips { get; private set; }
        public string SkipRestore { get; private set; }

        public OrderEventSourcingRequest(
            string name,
            string useCases,
            string userInterface,
            string dataAccess,
            string serviceBus,
            string tips,
            string skipRestore)
        {
            this.Name = name;
            this.UseCases = useCases;
            this.UserInterface = userInterface;
            this.DataAccess = dataAccess;
            this.ServiceBus = serviceBus;
            this.Tips = tips;
            this.SkipRestore = skipRestore;
        }
    }
}
