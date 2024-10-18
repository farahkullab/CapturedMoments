using CapturedMoments.Data;
using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Models.ViewComponents
{
    public class PhotographerSectionViewComponent : ViewComponent
    {
        private AppDbContext db;
        public PhotographerSectionViewComponent(AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            return View(db.Photographers.ToList());
        }
    }
}

