using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDT.Data;

namespace WebDT.Areas.Admin.Controllers
{
    [Authorize]
    public class IphoneController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public IphoneController(ApplicationDbContext context, IWebHostEnvironment webHost )
        {
            _context = context;
            _webHost = webHost;

        }
        public async Task<IActionResult> Index()
        {
            var iphone = await _context.IPHONE.ToListAsync();
            return View(iphone);
        }
    }
}
