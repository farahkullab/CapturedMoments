using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Controllers
{
    public class GalleriesController : Controller
    {
        public IActionResult Gallery()
        {
            return View();
        }
    }
}
