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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl">Store url which user input on browser</param>
        /// <returns></returns>
        public IActionResult Login(string returnUrl = null)
        {
            LoginViewModel login = new LoginViewModel();

            // If returnUrl has value - User input to url => Keep url of user to model
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                login.ReturnURL = returnUrl;
            }

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
                    // If url which input from browser is valid. Ex: /a/b => Redirect to user page
                    if (Url.IsLocalUrl(model.ReturnURL))
                    {
                        return Redirect(model.ReturnURL);
                    }
                    else // Default, user do not input the url => Redirect to home page
                    {
                        return RedirectToAction("Admmin", "Home", new { area = "Admin" });
                    }
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
