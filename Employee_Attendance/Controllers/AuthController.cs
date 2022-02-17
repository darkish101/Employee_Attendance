using Employee_Attendance.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Attendance.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly EmployeeDomain _domain;

        public AuthController(EmployeeDomain domain)
        {
            _domain = domain;
        }

        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel modal)
        {
            if (ModelState.IsValid)
            {
                var result = await _domain.LoginAsync(modal);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View();
        }

        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(EmployeeViewModel modal)
        {
            if (ModelState.IsValid)
            {
                var result = await _domain.RegisterAsync(modal);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(string.Empty, result.Errors.ToString());
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _domain.LogoutAsync();
            return RedirectToAction("Login", "Auth");
        }

          public async Task<IActionResult> AccessDenied()
        {
            await _domain.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}