﻿namespace Cart.WebApi.UseCases.OrderHexagonalTemplate
{
    using Cart.Application;
    using Microsoft.AspNetCore.Mvc;
    using Cart.Application.UseCases.HexagonalTemplate;

    [Route("api/[controller]")]
    public class Orders : Controller
    {
        private readonly IInputBoundary<Input> orderHexagonalTemplateBoundary;
        private readonly OrderPresenter orderHexagonalTemplatePresenter;

        public Orders(
            IInputBoundary<Input> orderHexagonalTemplateBoundary,
            OrderPresenter orderHexagonalTemplatePresenter)
        {
            this.orderHexagonalTemplateBoundary = orderHexagonalTemplateBoundary;
            this.orderHexagonalTemplatePresenter = orderHexagonalTemplatePresenter;
        }

        [HttpPost("Hexagonal")]
        public IActionResult Post([FromBody]OrderHexagonalTemplateRequest request)
        {
            Input input = new Input(
                request.Name,
                request.UseCases,
                request.UserInterface,
                request.DataAccess,
                request.Tips,
                request.SkipRestore);

            orderHexagonalTemplateBoundary.Process(input);

            return orderHexagonalTemplatePresenter.ViewModel;
        }
    }
}
