namespace Web.Controllers.UseCases.HexagonalTemplate
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        //[HttpPost("Hexagonal")]
        //public IActionResult Post([FromBody]HexagonalRequest request)
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Hexagonal([FromBody]HexagonalRequest request)
        {
            return View();
        }
    }
}
