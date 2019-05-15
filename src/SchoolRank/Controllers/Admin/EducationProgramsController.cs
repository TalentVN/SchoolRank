using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentVN.ApplicationCore.Entities;
using TalentVN.Infrastructure.Data;

namespace TalentVN.SchoolRank.Controllers.Admin
{
    [Route("admin/[controller]/[Action]")]
    public class EducationProgramsController : Controller
    {
        private readonly AppDbContext _context;

        public EducationProgramsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EducationPrograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationPrograms.ToListAsync());
        }

        // GET: EducationPrograms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationProgram = await _context.EducationPrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationProgram == null)
            {
                return NotFound();
            }

            return View(educationProgram);
        }

        // GET: EducationPrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive")] EducationProgram educationProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationProgram);
        }

        // GET: EducationPrograms/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationProgram = await _context.EducationPrograms.FindAsync(id);
            if (educationProgram == null)
            {
                return NotFound();
            }
            return View(educationProgram);
        }

        // POST: EducationPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description,IsActive")] EducationProgram educationProgram)
        {
            if (id != educationProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationProgramExists(educationProgram.Id))
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
            return View(educationProgram);
        }

        // GET: EducationPrograms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationProgram = await _context.EducationPrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationProgram == null)
            {
                return NotFound();
            }

            return View(educationProgram);
        }

        // POST: EducationPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var educationProgram = await _context.EducationPrograms.FindAsync(id);
            _context.EducationPrograms.Remove(educationProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationProgramExists(string id)
        {
            return _context.EducationPrograms.Any(e => e.Id == id);
        }
    }
}
