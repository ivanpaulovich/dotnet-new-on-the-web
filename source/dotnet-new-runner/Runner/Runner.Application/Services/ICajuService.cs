namespace Runner.Application.Services
{
    using Runner.Domain.Templates;
    using System.Threading.Tasks;

    public interface ICajuService
    {
        void Run(CleanTemplateOrder template);
        void Run(HexagonalTemplateOrder template);
        void Run(EventSourcingTemplateOrder template);
    }
}
