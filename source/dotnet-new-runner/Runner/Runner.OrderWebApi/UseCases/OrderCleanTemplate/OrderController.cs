namespace Runner.WebApi.UseCases.OrderCleanTemplate
{
    using Runner.Application;
    using Microsoft.AspNetCore.Mvc;
    using Runner.Application.UseCases.Orders.CleanTemplate;

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

        [HttpPost]
        public IActionResult Post([FromBody]OrderCleanTemplateRequest message)
        {
            Input input = new Input(
                message.Name,
                message.UseCases,
                message.UserInterface,
                message.DataAccess,
                message.Tips,
                message.SkipRestore);

            orderCleanTemplateBoundary.Process(input);

            return registerPresenter.ViewModel;
        }
    }
}
