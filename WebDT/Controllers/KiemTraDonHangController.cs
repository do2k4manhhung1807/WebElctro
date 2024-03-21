using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebDT.Data;
using WebDT.Models;
using WebDT.ViewModel;

namespace WebDT.Controllers
{
    public class KiemTraDonHangController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public KiemTraDonHangController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public IActionResult Index(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                return NotFound();
            }
            return View();
        }

    }
}
