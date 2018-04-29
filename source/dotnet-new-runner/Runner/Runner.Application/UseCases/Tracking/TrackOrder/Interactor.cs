namespace Runner.Application.UseCases.Tracking.TrackOrder
{
    using Runner.Application.UseCases.Runners;
    using System;

    public class Interactor : IInputBoundary<Input>
    {
        private readonly ICajuService cajuService;
        private readonly IOutputBoundary<TrackingOutput> outputBoundary;

        public Interactor(
            ICajuService cajuService,
            IOutputBoundary<TrackingOutput> outputBoundary)
        {
            this.cajuService = cajuService;
            this.outputBoundary = outputBoundary;
        }

        public void Process(Input input)
        {
            TrackingOutput output = new TrackingOutput(
                    input.OrderId,
                    "https://orders2caju.blob.core.windows.net/templates/065847a7-461c-467f-a597-518577854625.zip",
                    DateTime.UtcNow
                );

            outputBoundary.Populate(output);
        }
    }
}
