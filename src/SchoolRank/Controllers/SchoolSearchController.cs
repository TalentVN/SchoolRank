﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TalentVN.SchoolRank.Controllers
{
    public class SchoolSearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}