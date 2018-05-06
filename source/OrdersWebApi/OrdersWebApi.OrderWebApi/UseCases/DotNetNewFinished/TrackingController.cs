namespace OrdersWebApi.WebApi.UseCases.DotNetNewFinished
{
    using OrdersWebApi.Application;
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application.UseCases.Tracking.DotNetNewFinished;
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

        [HttpPatch("DotNetNewFinished")]
        public async Task Get([FromBody]DotNetNewFinishedRequest request)
        {
            Input input = new Input(request.OrderId, request.Output);
            await trackingBoundary.Process(input);
        }
    }
}
