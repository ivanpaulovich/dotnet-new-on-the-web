namespace Web.Controllers.UseCases.CleanTemplate
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        [HttpPost("Clean")]
        public IActionResult Post([FromBody]CleanTemplateRequest request)
        {
            return View();
        }
    }
}
