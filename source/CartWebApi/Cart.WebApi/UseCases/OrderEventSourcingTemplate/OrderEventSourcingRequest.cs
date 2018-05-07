namespace Cart.WebApi.UseCases.OrderEventSourcingTemplate
{
    public class OrderEventSourcingRequest
    {
        public string Name { get; set; }
        public string UseCases { get; set; }
        public string UserInterface { get; set; }
        public string DataAccess { get; set; }
        public string ServiceBus { get; set; }
        public string Tips { get; set; }
        public string SkipRestore { get; set; }
    }
}
