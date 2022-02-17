using Employee_Attendance.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Employee_Attendance.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AttendanceDomain _domain;
        public EmployeeController(AttendanceDomain domain)
        {
            _domain = domain;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var result = await _domain.GetTodayAttendance(DateTime.Today.ToString(), User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (result == null)
                return PartialView("_CheckIn", new AttendanceViewModel());
            return View();
        }

        public async Task<ActionResult> CheckIn(AttendanceViewModel model)
        {
            model.AttendanceDay = DateTime.Now;
            model.Employee_ID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
           await _domain.InsertAttendance(model);
            return PartialView("_CheckIn", model);
        }

       
    }
}
