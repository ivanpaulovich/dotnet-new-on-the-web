namespace Web.Controllers.UseCases.Tracking
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class TrackingController : Controller
    {
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
