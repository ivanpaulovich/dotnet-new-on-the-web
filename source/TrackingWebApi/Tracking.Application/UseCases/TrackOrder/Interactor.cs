namespace Tracking.Application.UseCases.TrackOrder
{
    using Tracking.Application.Repositories;
    using Tracking.Domain.Tracking;
    using System.Threading.Tasks;

    public class Interactor : IInputBoundaryAsync<Input>
    {
        private readonly IOrderReadOnlyRepository orderReadOnlyRepository;
        private readonly IOutputBoundary<TrackingOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;

        public Interactor(
            IOrderReadOnlyRepository orderReadOnlyRepository,
            IOutputBoundary<TrackingOutput> outputBoundary,
            IOutputConverter outputConverter)
        {
            this.orderReadOnlyRepository = orderReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }

        public async Task Process(Input input)
        {
            Order order = await orderReadOnlyRepository.Get(input.OrderId);
            TrackingOutput output = outputConverter.Map<TrackingOutput>(order);
            outputBoundary.Populate(output);
        }
    }
}
