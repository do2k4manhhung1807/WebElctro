using Microsoft.AspNetCore.Mvc;

namespace WebDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
