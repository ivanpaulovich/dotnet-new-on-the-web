namespace OrdersWebApi.WebApi.UseCases.UploadFinished
{
    using OrdersWebApi.Application;
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application.UseCases.Tracking.UploadFinished;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class Tracking : Controller
    {
        private readonly IInputBoundaryAsync<Input> trackingBoundary;

        public Tracking(
            IInputBoundaryAsync<Input> trackingBoundary)
        {
            this.trackingBoundary = trackingBoundary;
        }

        [HttpPatch("UploadFinished")]
        public async Task Get([FromBody]UploadFinishedRequest request)
        {
            Input input = new Input(request.OrderId);
            await trackingBoundary.Process(input);
        }
    }
}
