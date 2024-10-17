using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapturedMoments.Data;
using CapturedMoments.Models;
using Microsoft.AspNetCore.Authorization;

namespace CapturedMoments.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class PhotographersController : Controller
    {
        private readonly AppDbContext _context;

        public PhotographersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Photographers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Photographers.ToListAsync());
        }

        // GET: Dashboard/Photographers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographer = await _context.Photographers
                .FirstOrDefaultAsync(m => m.PhotographerId == id);
            if (photographer == null)
            {
                return NotFound();
            }

            return View(photographer);
        }

        // GET: Dashboard/Photographers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Photographers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotographerId,PhotograperName,Bio,Image,SubsicriptionStatus,SocialMediaURL,SessionId,IsActive,IsDeleted,CreationDate")] Photographer photographer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photographer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photographer);
        }

        // GET: Dashboard/Photographers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographer = await _context.Photographers.FindAsync(id);
            if (photographer == null)
            {
                return NotFound();
            }
            return View(photographer);
        }

        // POST: Dashboard/Photographers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotographerId,PhotograperName,Bio,Image,SubsicriptionStatus,SocialMediaURL,SessionId,IsActive,IsDeleted,CreationDate")] Photographer photographer)
        {
            if (id != photographer.PhotographerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photographer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotographerExists(photographer.PhotographerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(photographer);
        }

        // GET: Dashboard/Photographers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographer = await _context.Photographers
                .FirstOrDefaultAsync(m => m.PhotographerId == id);
            if (photographer == null)
            {
                return NotFound();
            }

            return View(photographer);
        }

        // POST: Dashboard/Photographers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photographer = await _context.Photographers.FindAsync(id);
            if (photographer != null)
            {
                _context.Photographers.Remove(photographer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotographerExists(int id)
        {
            return _context.Photographers.Any(e => e.PhotographerId == id);
        }
    }
}
