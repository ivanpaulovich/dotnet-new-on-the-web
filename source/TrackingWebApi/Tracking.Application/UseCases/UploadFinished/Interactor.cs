namespace Tracking.Application.UseCases.UploadFinished
{
    using Tracking.Application.Repositories;
    using Tracking.Domain.Tracking;
    using System.Threading.Tasks;

    public class Interactor : IInputBoundaryAsync<Input>
    {
        private readonly IOrderReadOnlyRepository orderReadOnlyRepository;
        private readonly IOrderWriteOnlyRepository orderWriteOnlyRepository;

        public Interactor(
            IOrderReadOnlyRepository orderReadOnlyRepository,
            IOrderWriteOnlyRepository orderWriteOnlyRepository)
        {
            this.orderReadOnlyRepository = orderReadOnlyRepository;
            this.orderWriteOnlyRepository = orderWriteOnlyRepository;
        }

        public async Task Process(Input input)
        {
            Order order = await orderReadOnlyRepository.Get(input.OrderId);
            order.FinishUpload();
            await orderWriteOnlyRepository.Update(order);
        }
    }
}
