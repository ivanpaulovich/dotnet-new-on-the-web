namespace OrdersWebApi.Application.UseCases.Tracking.OrderReceived
{
    using OrdersWebApi.Application.Repositories;
    using OrdersWebApi.Domain.Tracking;
    using System.Threading.Tasks;

    public class Interactor : IInputBoundaryAsync<Input>
    {
        private readonly IOrderReadOnlyRepository orderReadOnlyRepository;
        private readonly IOrderWriteOnlyRepository orderWriteOnlyRepository;
        private readonly string downloadUrlBase;

        public Interactor(
            IOrderReadOnlyRepository orderReadOnlyRepository,
            IOrderWriteOnlyRepository orderWriteOnlyRepository,
            string downloadUrlBase)
        {
            this.orderReadOnlyRepository = orderReadOnlyRepository;
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
