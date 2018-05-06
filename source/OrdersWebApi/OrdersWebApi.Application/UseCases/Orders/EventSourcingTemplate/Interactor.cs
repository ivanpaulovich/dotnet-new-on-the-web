namespace OrdersWebApi.Application.UseCases.Orders.EventSourcingTemplate
{
    using OrdersWebApi.Application.ServiceBus;
    using OrdersWebApi.Application.Services;
    using OrdersWebApi.Domain.Templates;

    public class Interactor : IInputBoundary<Input>
    {
        private readonly IPublisher bus;
        private readonly IOutputBoundary<OrderOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;
        private readonly ITrackingService trackingService;
        
        public Interactor(
            IPublisher bus,
            IOutputBoundary<OrderOutput> outputBoundary,
            IOutputConverter outputConverter,
            ITrackingService trackingService)
        {
            this.bus = bus;
            this.outputBoundary = outputBoundary;
            this.outputConverter = outputConverter;
            this.trackingService = trackingService;
        }

        public void Process(Input input)
        {
            EventSourcingTemplate order = new EventSourcingTemplate(
                input.Name,
                input.UseCases,
                input.UserInterface,
                input.DataAccess,
                input.ServiceBus,
                input.Tips,
                input.SkipRestore);

            bus.Publish(order);

            trackingService.OrderReceived(
                order.Id,
                order.Name.Text,
                order.CommandLines);

            OrderOutput generateOutput = outputConverter.Map<OrderOutput>(order);
            outputBoundary.Populate(generateOutput);
        }
    }
}
