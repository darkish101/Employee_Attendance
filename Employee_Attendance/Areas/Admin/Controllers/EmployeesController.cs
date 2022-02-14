using Employee_Attendance.Business;
using Employee_Attendance.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Employee_Attendance.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly EmployeeDomain _domain;
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;

        public EmployeesController(EmployeeDomain Domain, SignInManager<Employee> signInManager, UserManager<Employee> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _domain = Domain;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Show(string id)
        {
            var modal = await _domain.EmployeeById(id);
            return View(modal);
        }

        public ActionResult Employee()
        {
            return View("Employee", new EmployeeViewModel());
        }

        public async Task<ActionResult> DeleteEmployee(string id)
        {
            await _domain.DeleteEmployee(id);

            return RedirectToAction("Index", "Employees");
        }

        public async Task<ActionResult> EditEmployee(string id)
        {
            var modal = await _domain.EmployeeById(id);
            return View("Employee", modal);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(EmployeeViewModel modal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    modal.Added_By = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var result = await _domain.InsertEmployee(modal);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Employees");
                }
                catch
                { }
            }
            ModelState.AddModelError("save modal error", "الرجاء إكمال تعبة النموذج.");
            return View("Employee", modal);
        }

       

        //public async Task<IActionResult> RegisterNewEmployee(EmployeeViewModel modal)
        //{

        //    //if (ModelState.IsValid)
        //    //{
        //    var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var user = new Employee { 
        //          UserName = modal.UserName
        //        , NormalizedUserName = modal.UserName
        //        , Email = modal.Email
        //        , NormalizedEmail = modal.Email
        //        , Employee_Name = modal.Employee_Name
        //        , Employment_Id = modal.Employment_Id
        //        , PhoneNumber = modal.PhoneNumber
        //        , Added_By = currentUserId
        //    };


        //    var result = await _userManager.CreateAsync(user, modal.Passowrd);


        //    await _Domain.InsertEmployee(modal);
        //    //}
        //    //else
        //    //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    //return View();

        //    return RedirectToAction("Index", "Admin");
        //    //return View();
        //}
    }
}
