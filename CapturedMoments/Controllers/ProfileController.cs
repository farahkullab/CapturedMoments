using CapturedMoments.Data;
using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Controllers
{
    public class ProfileController : Controller
    {
        private AppDbContext db;
        public ProfileController(AppDbContext _db)
        {

            db = _db;
        }
        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = db.Photographers.FirstOrDefault(p => p.PhotographerId == id);

            if (profile == null)
            {
                return NotFound();
            }

            return View();
       }
    }
}
