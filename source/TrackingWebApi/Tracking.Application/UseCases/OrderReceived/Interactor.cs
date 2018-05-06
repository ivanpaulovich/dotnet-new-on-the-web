namespace Tracking.Application.UseCases.OrderReceived
{
    using Tracking.Application.Repositories;
    using Tracking.Domain.Tracking;
    using System.Threading.Tasks;

    public class Interactor : IInputBoundaryAsync<Input>
    {
        private readonly IOrderWriteOnlyRepository orderWriteOnlyRepository;
        private readonly string downloadUrlBase;

        public Interactor(
            IOrderWriteOnlyRepository orderWriteOnlyRepository,
            string downloadUrlBase)
        {
            this.orderWriteOnlyRepository = orderWriteOnlyRepository;
            this.downloadUrlBase = downloadUrlBase;
        }

        public async Task Process(Input input)
        {
            Order order = new Order(input.OrderId, input.CommandLines, downloadUrlBase);
            await orderWriteOnlyRepository.Add(order);
        }
    }
}
