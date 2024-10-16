using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
