namespace Tracking.WebApi.UseCases.OrderReceived
{
    using Tracking.Application;
    using Microsoft.AspNetCore.Mvc;
    using Tracking.Application.UseCases.OrderReceived;
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

        [HttpPost]
        public async Task Get([FromBody]OrderReceivedRequest request)
        {
            Input input = new Input(request.OrderId, request.Name, request.CommandLines);
            await trackingBoundary.Process(input);
        }
    }
}
