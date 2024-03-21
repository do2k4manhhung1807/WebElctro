using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DonHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
