namespace Tracking.WebApi.UseCases.DotNetNewStarted
{
    using Tracking.Application;
    using Microsoft.AspNetCore.Mvc;
    using Tracking.Application.UseCases.DotNetNewStarted;
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

        [HttpPatch("DotNetNewStarted")]
        public async Task Get([FromBody]DotNetNewStartedRequest request)
        {
            Input input = new Input(request.OrderId);
            await trackingBoundary.Process(input);
        }
    }
}
