namespace Runner.WebApi.UseCases.GetCleanTemplateOrder
{
    using Runner.Application;
    using Microsoft.AspNetCore.Mvc;
    using Runner.Application.UseCases.Orders.CleanTemplate;
    using System;

    [Route("api/[controller]")]
    public class OrderCleanTemplate : Controller
    {
        private readonly IInputBoundary<Input> orderCleanTemplateBoundary;
        private readonly Presenter registerPresenter;

        public OrderCleanTemplate(
            IInputBoundary<Input> orderCleanTemplateBoundary,
            Presenter registerPresenter)
        {
            this.orderCleanTemplateBoundary = orderCleanTemplateBoundary;
            this.registerPresenter = registerPresenter;
        }

        [HttpGet("CleanTemplate/{orderid}", Name = "CleanTemplate")]
        public IActionResult Get([FromBody]Guid orderId)
        {
            return registerPresenter.ViewModel;
        }
    }
}
