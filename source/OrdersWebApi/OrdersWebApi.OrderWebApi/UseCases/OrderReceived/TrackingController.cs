namespace OrdersWebApi.WebApi.UseCases.OrderReceived
{
    using OrdersWebApi.Application;
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application.UseCases.Tracking.OrderReceived;
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

        [HttpPatch("OrderReceived")]
        public async Task Get([FromBody]OrderReceivedRequest request)
        {
            Input input = new Input(request.OrderId, request.Name, request.CommandLines);
            await trackingBoundary.Process(input);
        }
    }
}
