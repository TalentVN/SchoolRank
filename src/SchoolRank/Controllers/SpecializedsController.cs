using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentVN.ApplicationCore.Entities;
using TalentVN.Infrastructure.Data;

namespace SchoolRank.Controllers
{
    public class SpecializedsController : Controller
    {
        private readonly AppDbContext _context;

        public SpecializedsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Specializeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specializeds.ToListAsync());
        }

        // GET: Specializeds/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialized = await _context.Specializeds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialized == null)
            {
                return NotFound();
            }

            return View(specialized);
        }

        // GET: Specializeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specializeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive")] Specialized specialized)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialized);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialized);
        }

        // GET: Specializeds/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialized = await _context.Specializeds.FindAsync(id);
            if (specialized == null)
            {
                return NotFound();
            }
            return View(specialized);
        }

        // POST: Specializeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,IsActive")] Specialized specialized)
        {
            if (id != specialized.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialized);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializedExists(specialized.Id))
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
            return View(specialized);
        }

        // GET: Specializeds/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialized = await _context.Specializeds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialized == null)
            {
                return NotFound();
            }

            return View(specialized);
        }

        // POST: Specializeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var specialized = await _context.Specializeds.FindAsync(id);
            _context.Specializeds.Remove(specialized);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecializedExists(string id)
        {
            return _context.Specializeds.Any(e => e.Id == id);
        }
    }
}
