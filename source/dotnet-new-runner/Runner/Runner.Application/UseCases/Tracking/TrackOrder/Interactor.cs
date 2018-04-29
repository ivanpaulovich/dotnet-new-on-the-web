namespace Runner.Application.UseCases.Tracking.TrackOrder
{
    using Runner.Application.UseCases.Runners;
    using System;

    public class Interactor : IInputBoundary<Input>
    {
        private readonly ICajuService cajuService;
        private readonly IOutputBoundary<TrackingOutput> outputBoundary;
        private readonly string downloadUrlBase;

        public Interactor(
            ICajuService cajuService,
            IOutputBoundary<TrackingOutput> outputBoundary,
            string downloadUrlBase)
        {
            this.cajuService = cajuService;
            this.outputBoundary = outputBoundary;
            this.downloadUrlBase = downloadUrlBase;
        }

        public void Process(Input input)
        {
            TrackingOutput output = new TrackingOutput(
                    input.OrderId,
                    downloadUrlBase + "/" + input.OrderId.ToString() + ".zip",
                    DateTime.UtcNow
                );

            outputBoundary.Populate(output);
        }
    }
}
