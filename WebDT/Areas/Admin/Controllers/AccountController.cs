using Microsoft.AspNetCore.Mvc;
using WebDT.Models;
using WebDT.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebDT.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUserModel> _signInManager;

        public AccountController(SignInManager<AppUserModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            LoginViewModel login = new LoginViewModel();
            return View("~/Areas/Admin/Views/Account/Login.cshtml", login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                   //return RedirectToAction("Admmin", "Home", new {area = "Admin"});
                }
                ModelState.AddModelError("", "Invalid Login Attempt");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
