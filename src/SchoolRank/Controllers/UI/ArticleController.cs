using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TalentVN.ApplicationCore.Entities;
using TalentVN.Infrastructure.Data;

namespace SchoolRank.Controllers.UI
{
    public class ArticleController : Controller
    {
        private readonly AppDbContext _context;

        public ArticleController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            var article = _context.Articles.FirstOrDefault(x => true);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
    }
}