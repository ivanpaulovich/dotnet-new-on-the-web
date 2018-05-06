namespace OrdersWebApi.Application.UseCases.Orders.HexagonalTemplate
{
    using OrdersWebApi.Application.ServiceBus;
    using OrdersWebApi.Domain.Templates;

    public class Interactor : IInputBoundary<Input>
    {
        private readonly IPublisher bus;
        private readonly IOutputBoundary<OrderOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;

        public Interactor(
            IPublisher bus,
            IOutputBoundary<OrderOutput> outputBoundary,
            IOutputConverter outputConverter)
        {
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
        }

        public void Process(Input input)
        {
            HexagonalTemplate order = new HexagonalTemplate(
                input.Name,
                input.UseCases,
                input.UserInterface,
                input.DataAccess,
                input.Tips,
                input.SkipRestore);

            bus.Publish(order);

            OrderOutput generateOutput = outputConverter.Map<OrderOutput>(order);
            outputBoundary.Populate(generateOutput);
        }
    }
}
