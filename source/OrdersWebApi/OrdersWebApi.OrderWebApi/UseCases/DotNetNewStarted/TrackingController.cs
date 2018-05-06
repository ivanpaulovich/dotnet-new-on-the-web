namespace OrdersWebApi.WebApi.UseCases.DotNetNewStarted
{
    using OrdersWebApi.Application;
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application.UseCases.Tracking.DotNetNewStarted;
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

        [HttpPatch("DotNetNewStarted")]
        public async Task Get([FromBody]OrderReceivedRequest request)
        {
            Input input = new Input(request.OrderId);
            await trackingBoundary.Process(input);
        }
    }
}
