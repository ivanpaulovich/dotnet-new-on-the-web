namespace Web.Controllers.UseCases.CleanTemplate
{
    public class CleanTemplateRequest
    {
        public string Name { get; private set; }
        public string UseCases { get; private set; }
        public string DataAccess { get; private set; }
        public bool IncludeWebApi { get; private set; }
        public bool IncludeDocumentation { get; private set; }
        public bool SkipRestore { get; private set; }

        public CleanTemplateRequest(
            string name,
            string useCases,
            bool includeWebApi,
            string dataAccess,
            bool includeDocumentation,
            bool skipRestore)
        {
            this.Name = name;
            this.UseCases = useCases;
            this.IncludeWebApi = includeWebApi;
            this.DataAccess = dataAccess;
            this.IncludeDocumentation = includeDocumentation;
            this.SkipRestore = skipRestore;
        }
    }
}
