﻿using Microsoft.AspNetCore.Mvc;

namespace WebDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Admmin()
        {
            return View();
        }
    }
}
