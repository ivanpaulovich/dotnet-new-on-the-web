namespace Tracking.WebApi.UseCases.TrackOrder
{
    using Tracking.Application;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using Tracking.Application.UseCases.TrackOrder;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class Orders : Controller
    {
        private readonly IInputBoundaryAsync<Input> trackOrderBoundary;
        private readonly Presenter trackOrderPresenter;

        public Orders(
            IInputBoundaryAsync<Input> trackOrderBoundary,
            Presenter trackOrderPresenter)
        {
            this.trackOrderBoundary = trackOrderBoundary;
            this.trackOrderPresenter = trackOrderPresenter;
        }

        [HttpGet("{orderid}", Name = "Tracking")]
        public async Task<IActionResult> Get(Guid orderId)
        {
            Input input = new Input(orderId);
            await trackOrderBoundary.Process(input);
            return trackOrderPresenter.ViewModel;
        }
    }
}
