namespace Runner.WebApi.UseCases.GetCleanTemplateOrder
{
    using Microsoft.AspNetCore.Mvc;
    using Runner.Application;
    using Runner.Application.UseCases.Track;

    public class Presenter : IOutputBoundary<TrackOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public TrackOutput Output { get; private set; }

        public void Populate(TrackOutput output)
        {
            Output = output;

            ViewModel = new CreatedAtRouteResult(
                "GetCleanTemplateOrder",
                new { orderId = output.TemplateId },
                output);
        }
    }
}
