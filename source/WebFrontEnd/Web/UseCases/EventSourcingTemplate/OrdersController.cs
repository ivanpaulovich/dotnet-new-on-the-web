namespace Web.Controllers.UseCases.EventSourcingTemplate
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        [HttpPost("Clean")]
        public IActionResult Post([FromBody]EventSourcingRequest request)
        {
            return View();
        }
    }
}
