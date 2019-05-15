using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TalentVN.ApplicationCore.Entities;
using TalentVN.Infrastructure.Data;

namespace SchoolRank.Controllers
{
    public class SchoolProfileController : Controller
    {
        private readonly AppDbContext _context;

        public SchoolProfileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SchoolProfile
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchoolProfiles.ToListAsync());
        }

        // GET: SchoolProfile/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolProfile = await _context.SchoolProfiles
                .Include(x => x.Specializeds)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolProfile == null)
            {
                return NotFound();
            }

            return View(schoolProfile);
        }

        // GET: SchoolProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Detail,Localtion,Email,PhoneNumber,WebSite")] SchoolProfile schoolProfile)
        {
            if (ModelState.IsValid)
            {

                await _context.Specializeds.ForEachAsync(spec =>
                {
                    schoolProfile.Specializeds.Add(spec);
                });

                _context.Add(schoolProfile);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolProfile);
        }

        // GET: SchoolProfile/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolProfile = await _context.SchoolProfiles.FindAsync(id);
            if (schoolProfile == null)
            {
                return NotFound();
            }
            return View(schoolProfile);
        }

        // POST: SchoolProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Detail,Localtion,Email,PhoneNumber,WebSite")] SchoolProfile schoolProfile)
        {
            if (id != schoolProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolProfileExists(schoolProfile.Id))
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
            return View(schoolProfile);
        }

        // GET: SchoolProfile/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolProfile = await _context.SchoolProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolProfile == null)
            {
                return NotFound();
            }

            return View(schoolProfile);
        }

        // POST: SchoolProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schoolProfile = await _context.SchoolProfiles.FindAsync(id);
            _context.SchoolProfiles.Remove(schoolProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolProfileExists(string id)
        {
            return _context.SchoolProfiles.Any(e => e.Id == id);
        }
    }
}
