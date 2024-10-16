using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapturedMoments.Data;
using CapturedMoments.Models;

namespace CapturedMoments.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PhotographerSectionsController : Controller
    {
        private readonly AppDbContext _context;

        public PhotographerSectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/PhotographerSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sections.ToListAsync());
        }

        // GET: Dashboard/PhotographerSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographerSection = await _context.Sections
                .FirstOrDefaultAsync(m => m.photographersectionId == id);
            if (photographerSection == null)
            {
                return NotFound();
            }

            return View(photographerSection);
        }

        // GET: Dashboard/PhotographerSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/PhotographerSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( PhotographerSection photographerSection)
        {
            if (ModelState.IsValid)
            {
                if (photographerSection.ImageFile != null && photographerSection.ImageFile.Length > 0)
                {
                    // Define the path to save the image
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Path.GetFileName(photographerSection.ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await photographerSection.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image path in the model (you may want to adjust this based on your requirements)
                    photographerSection.Image = $"/images/{fileName}";

                    _context.Add(photographerSection);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

               
            }
            return View(photographerSection);
        }

        // GET: Dashboard/PhotographerSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographerSection = await _context.Sections.FindAsync(id);
            if (photographerSection == null)
            {
                return NotFound();
            }
            return View(photographerSection);
        }

        // POST: Dashboard/PhotographerSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PhotographerSection photographerSection)
        {
            if (id != photographerSection.photographersectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (photographerSection.ImageFile != null && photographerSection.ImageFile.Length > 0)
                    {
                        // Define the path to save the image
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        var fileName = Path.GetFileName(photographerSection.ImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Ensure the uploads folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Save the file to the server
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await photographerSection.ImageFile.CopyToAsync(fileStream);
                        }

                        // Update the image path in the model
                        photographerSection.Image = $"/images/{fileName}";
                    }
                    else
                    {
                        // If no new file is uploaded, retain the existing image path
                        var existingphotographerSection = await _context.Categories.FindAsync(id);
                        photographerSection.Image = existingphotographerSection.Image;
                    }
                    _context.Update(photographerSection);
                    await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotographerSectionExists(photographerSection.photographersectionId))
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
            return View(photographerSection);
        }

        // GET: Dashboard/PhotographerSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photographerSection = await _context.Sections
                .FirstOrDefaultAsync(m => m.photographersectionId == id);
            if (photographerSection == null)
            {
                return NotFound();
            }

            return View(photographerSection);
        }

        // POST: Dashboard/PhotographerSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photographerSection = await _context.Sections.FindAsync(id);
            if (photographerSection != null)
            {
                _context.Sections.Remove(photographerSection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotographerSectionExists(int id)
        {
            return _context.Sections.Any(e => e.photographersectionId == id);
        }
    }
}
