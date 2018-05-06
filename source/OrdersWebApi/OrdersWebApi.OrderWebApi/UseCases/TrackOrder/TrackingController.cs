namespace OrdersWebApi.WebApi.UseCases.TrackOrder
{
    using OrdersWebApi.Application;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using OrdersWebApi.Application.UseCases.Tracking.TrackOrder;

    [Route("api/[controller]")]
    public class Tracking : Controller
    {
        private readonly IInputBoundaryAsync<Input> trackOrderBoundary;
        private readonly Presenter trackOrderPresenter;

        public Tracking(
            IInputBoundaryAsync<Input> trackOrderBoundary,
            Presenter trackOrderPresenter)
        {
            this.trackOrderBoundary = trackOrderBoundary;
            this.trackOrderPresenter = trackOrderPresenter;
        }

        [HttpGet("{orderid}", Name = "Tracking")]
        public IActionResult Get(Guid orderId)
        {
            Input input = new Input(orderId);
            trackOrderBoundary.Process(input);
            return trackOrderPresenter.ViewModel;
        }
    }
}
