using CapturedMoments.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapturedMoments.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Gallery(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Images = await _context.Galleries.Where(m => m.CategoryId == id).ToListAsync();
            if (Images == null)
            {
                return NotFound();
            }

            return View(Images);
        }
    }
}
