using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Areas.PhotographerDashboard.Controllers
{
    [Area("PhotographerDashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
