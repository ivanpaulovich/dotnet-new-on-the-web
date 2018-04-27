namespace Runner.Infrastructure.Services
{
    using System.Threading.Tasks;
    using Runner.Application.Services;
    using Runner.Domain.Templates;

    public class CajuService : ICajuService
    {
        public Task Run(CleanTemplate template)
        {
            throw new System.NotImplementedException();
        }

        public Task Run(HexagonalTemplate template)
        {
            throw new System.NotImplementedException();
        }

        public Task Run(EventSourcingTemplate template)
        {
            throw new System.NotImplementedException();
        }
    }
}
