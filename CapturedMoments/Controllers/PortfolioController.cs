using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Portfolio()
        {
            return View();
        }
    }
}
