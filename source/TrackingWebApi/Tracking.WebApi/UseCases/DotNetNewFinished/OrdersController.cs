namespace Tracking.WebApi.UseCases.DotNetNewFinished
{
    using Tracking.Application;
    using Microsoft.AspNetCore.Mvc;
    using Tracking.Application.UseCases.DotNetNewFinished;
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

        [HttpPatch("DotNetNewFinished")]
        public async Task Get([FromBody]DotNetNewFinishedRequest request)
        {
            Input input = new Input(request.OrderId, request.Output);
            await trackingBoundary.Process(input);
        }
    }
}
