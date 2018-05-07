namespace Cart.WebApi.UseCases
{
    using Microsoft.AspNetCore.Mvc;
    using Cart.Application;
    using Cart.Application.UseCases.Orders;

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

            ViewModel = new ObjectResult(model);
        }
    }
}
