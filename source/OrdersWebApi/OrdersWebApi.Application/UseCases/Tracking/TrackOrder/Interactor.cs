namespace OrdersWebApi.Application.UseCases.Tracking.TrackOrder
{
    using System;

    public class Interactor : IInputBoundary<Input>
    {
        private readonly IOutputBoundary<TrackingOutput> outputBoundary;
        private readonly string downloadUrlBase;

        public Interactor(
            IOutputBoundary<TrackingOutput> outputBoundary,
            string downloadUrlBase)
        {
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
