namespace Runner.WebApi.UseCases.OrderCleanTemplate
{
    using Microsoft.AspNetCore.Mvc;
    using Runner.Application;
    using Runner.Application.UseCases.Orders;

    public class Presenter : IOutputBoundary<OrderOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public OrderOutput Output { get; private set; }

        public void Populate(OrderOutput response)
        {
            Output = response;

            ViewModel = new CreatedAtRouteResult(
                "GetCleanTemplateOrder",
                new { orderId = response.TemplateId },
                response);
        }
    }
}
