namespace Runner.Application.Services
{
    using Runner.Domain.Templates;
    using System.Threading.Tasks;

    public interface ICajuService
    {
        Task Run(CleanTemplate template);
        Task Run(HexagonalTemplate template);
        Task Run(EventSourcingTemplate template);
    }
}
