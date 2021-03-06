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
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeDomain _domain;

        public EmployeesController(EmployeeDomain Domain)
        {
            _domain = Domain;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EmployeeDetails(string id)
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
            var ms = ModelState;
            if (modal.Passowrd is null && modal.Confirmpwd is null && !string.IsNullOrEmpty(modal.Id)) 
            {
                ModelState.Remove("Passowrd");
                ModelState.Remove("Confirmpwd");
            }
            if (ModelState.IsValid)
            {
                if (modal.Employment_Id == null)
                {
                    try
                    {
                        modal.Added_By = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        var result = await _domain.InsertEmployee(modal);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Employees");
                        return RedirectToAction("Employee", modal);
                    }
                    catch
                    { }
                }
                else
                {
                    try
                    {
                        modal.Added_By = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                        await _domain.UpdateEmployee(modal);
                    }
                    catch
                    { }

                }
                return RedirectToAction("Index", "Employees");
            }
            ModelState.AddModelError("save modal error", "الرجاء إكمال تعبة النموذج.");
            return View("Employee", modal);
        }
    }
}