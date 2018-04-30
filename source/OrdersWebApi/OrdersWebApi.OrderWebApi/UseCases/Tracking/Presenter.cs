﻿namespace OrdersWebApi.WebApi.UseCases.Tracking
{
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application;
    using OrdersWebApi.Application.UseCases.Tracking;

    public class Presenter : IOutputBoundary<TrackingOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public TrackingOutput Output { get; private set; }

        public void Populate(TrackingOutput output)
        {
            Output = output;

            ViewModel = new CreatedAtRouteResult(
                "Tracking",
                new { orderId = output.OrderId },
                output);
        }
    }
}
