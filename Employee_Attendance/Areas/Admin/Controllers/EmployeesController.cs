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
    [Authorize]
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
    }
}
