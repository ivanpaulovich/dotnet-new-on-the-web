namespace Web.Controllers.UseCases.HexagonalTemplate
{
    public class HexagonalRequest
    {
        public string Name { get; set; }
        public string UseCases { get; set; }
        public string DataAccess { get; set; }
        public string IncludeWebApi { get; set; }
        public string IncludeDocumentation { get; set; }
        public string SkipRestore { get; set; }
    }
}
