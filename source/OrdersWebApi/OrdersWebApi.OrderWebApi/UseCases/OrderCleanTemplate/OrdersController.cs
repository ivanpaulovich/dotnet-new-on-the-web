namespace OrdersWebApi.WebApi.UseCases.OrderCleanTemplate
{
    using OrdersWebApi.Application;
    using Microsoft.AspNetCore.Mvc;
    using OrdersWebApi.Application.UseCases.Orders.CleanTemplate;

    [Route("api/[controller]")]
    public class Orders : Controller
    {
        private readonly IInputBoundary<Input> orderCleanTemplateBoundary;
        private readonly OrderPresenter orderCleanTemplatePresenter;

        public Orders(
            IInputBoundary<Input> orderCleanTemplateBoundary,
            OrderPresenter orderCleanTemplatePresenter)
        {
            this.orderCleanTemplateBoundary = orderCleanTemplateBoundary;
            this.orderCleanTemplatePresenter = orderCleanTemplatePresenter;
        }

        [HttpPost("Clean")]
        public IActionResult Post([FromBody]OrderCleanTemplateRequest request)
        {
            Input input = new Input(
                request.Name,
                request.UseCases,
                request.UserInterface,
                request.DataAccess,
                request.Tips,
                request.SkipRestore);

            orderCleanTemplateBoundary.Process(input);

            return orderCleanTemplatePresenter.ViewModel;
        }
    }
}
