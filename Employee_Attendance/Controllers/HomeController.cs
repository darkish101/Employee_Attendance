using AutoMapper;
using Employee_Attendance.Business;
using Employee_Attendance.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Attendance.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDomain _Domain;
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;

        public HomeController(EmployeeDomain Domain, SignInManager<Employee> signInManager, UserManager<Employee> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _Domain = Domain;
        }
        [Authorize]
        public IActionResult Index()
        {
            //ViewBag.GetAllTemplate = await _Domain.GetAllEmployee();
            //ViewBag.TemplateMsg = Value;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string modal)
        {
            //if (ModelState.IsValid)
            //{
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync("admin@admin4.com", "A@a1234565", true, lockoutOnFailure: false);
            ////todo add it in the domain
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
            //}

            // If we got this far, something failed, redisplay form
            //return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(EmployeeViewModel modal)
        {

            //if (ModelState.IsValid)
            //{
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var user = new Employee { UserName = "admin@admin4.com", Email = "admin@admin4.com" };


            var result = await _userManager.CreateAsync(user, "A@a1234565");
            ////todo add it in the domain

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
            //}

            // If we got this far, something failed, redisplay form
            //return View();
        }
    }
}
