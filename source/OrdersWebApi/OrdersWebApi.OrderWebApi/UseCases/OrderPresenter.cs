namespace OrdersWebApi.WebApi.UseCases
{
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application;
    using OrdersWebApi.Application.UseCases.Orders;

    public class OrderPresenter : IOutputBoundary<OrderOutput>
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
                "Tracking",
                new
                {
                    orderId = output.TemplateId,
                    controller = "Tracking"
                },
                model);
        }
    }
}
