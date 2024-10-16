using CapturedMoments.Data;
using Microsoft.AspNetCore.Mvc;

namespace CapturedMoments.Models.ViewComponents
{
    public class FeedbackViewComponent : ViewComponent
    {
        private AppDbContext db;
        public FeedbackViewComponent(AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            return View(db.feedbacks.ToList());
        }
    }
}
