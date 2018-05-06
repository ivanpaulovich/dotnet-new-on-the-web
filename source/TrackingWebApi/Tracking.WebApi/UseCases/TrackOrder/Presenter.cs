namespace Tracking.WebApi.UseCases.TrackOrder
{
    using Microsoft.AspNetCore.Mvc;
    using Tracking.Application;
    using Tracking.Application.UseCases.TrackOrder;

    public class Presenter : IOutputBoundary<TrackingOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public TrackingOutput Output { get; private set; }

        public void Populate(TrackingOutput output)
        {
            Output = output;

            OrderModel model = new OrderModel(
                Output.OrderId,
                Output.CommandLines,
                Output.OrderReceivedUtcDate,
                Output.DotNetNewStartedUtcDate,
                Output.DotNetNewFinishedUtcDate,
                Output.DotNetNewOutput,
                Output.UploadFinished,
                Output.DownloadUrl
            );

            ViewModel = new CreatedAtRouteResult(
                "Tracking",
                new { orderId = output.OrderId },
                model);
        }
    }
}
