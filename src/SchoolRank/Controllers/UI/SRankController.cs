using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentVN.Infrastructure.Data;

namespace TalentVN.SchoolRank.Controllers.UI
{
    public class SRankController : Controller
    {

        private readonly AppDbContext _context;

        public SRankController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SRanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.SRanks.ToListAsync());
        }
    }
}