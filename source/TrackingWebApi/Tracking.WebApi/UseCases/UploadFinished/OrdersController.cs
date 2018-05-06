namespace Tracking.WebApi.UseCases.UploadFinished
{
    using Tracking.Application;
    using Microsoft.AspNetCore.Mvc;
    using Tracking.Application.UseCases.UploadFinished;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class Orders : Controller
    {
        private readonly IInputBoundaryAsync<Input> trackingBoundary;

        public Orders(
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
