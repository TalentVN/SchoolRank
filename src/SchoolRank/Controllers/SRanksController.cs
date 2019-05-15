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
    public class SRanksController : Controller
    {
        private readonly AppDbContext _context;

        public SRanksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SRanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SRanks.ToListAsync());
        }

        // GET: SRanks
        public async Task<IActionResult> Ranks()
        {
            return View(await _context.SRanks.ToListAsync());
        }

        // GET: SRanks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sRank = await _context.SRanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sRank == null)
            {
                return NotFound();
            }

            return View(sRank);
        }

        // GET: SRanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SRanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl")] SRank sRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sRank);
        }

        // GET: SRanks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sRank = await _context.SRanks.FindAsync(id);
            if (sRank == null)
            {
                return NotFound();
            }
            return View(sRank);
        }

        // POST: SRanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Description")] SRank sRank)
        {
            if (id != sRank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SRankExists(sRank.Id))
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
            return View(sRank);
        }

        // GET: SRanks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sRank = await _context.SRanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sRank == null)
            {
                return NotFound();
            }

            return View(sRank);
        }

        // POST: SRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sRank = await _context.SRanks.FindAsync(id);
            _context.SRanks.Remove(sRank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SRankExists(string id)
        {
            return _context.SRanks.Any(e => e.Id == id);
        }
    }
}
