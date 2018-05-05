namespace Web.Controllers.UseCases.EventSourcingTemplate
{
    public class EventSourcingRequest
    {
        public string Name { get; set; }
        public string UseCases { get; set; }
        public string DataAccess { get; set; }
        public bool IncludeWebApi { get; set; }
        public bool IncludeDocumentation { get; set; }
        public bool SkipRestore { get; set; }
        public bool IncludeServiceBus { get; set; }
    }
}
