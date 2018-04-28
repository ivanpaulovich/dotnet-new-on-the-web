namespace Runner.WebApi.UseCases.OrderCleanTemplate
{
    using Microsoft.AspNetCore.Mvc;
    using Runner.Application;
    using Runner.Application.UseCases.Orders;

    public class Presenter : IOutputBoundary<OrderOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public OrderOutput Output { get; private set; }

        public void Populate(OrderOutput output)
        {
            Output = output;

            OrderModel model = new OrderModel(
                Output.TemplateId,
                Output.CommandLines,
                Output.OrderUtcDate
            );

            ViewModel = new CreatedAtRouteResult(
                "CleanTemplate",
                new { orderId = output.TemplateId },
                model);
        }
    }
}
