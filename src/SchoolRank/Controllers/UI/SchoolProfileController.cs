using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentVN.Infrastructure.Data;

namespace TalentVN.SchoolRank.Controllers.UI
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
                .Include(x => x.EducationPrograms)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolProfile == null)
            {
                return NotFound();
            }

            return View(schoolProfile);
        }
    }
}