using Microsoft.AspNetCore.Mvc;

namespace LMSArtiKeys.Area.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
