using Employee_Attendance.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Employee_Attendance.Controllers
{
    [Authorize(Roles = "Employee,Admin")]
    public class EmployeeController : Controller
    {
        private readonly AttendanceDomain _domain;
        public EmployeeController(AttendanceDomain domain)
        {
            _domain = domain;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _domain.GetDayAttendanceAsync(DateTime.Today.ToShortDateString(), User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

         public async Task<ActionResult> GetHours()
        {
            var modal = await _domain.HoursWorked(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return PartialView("_HoursWorked", await _domain.HoursWorked(User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [HttpPost]
        public async Task<ActionResult> CheckInOutAsync(AttendanceViewModel model)
        {
            var Employee_ID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
          await  _domain.AttendanceHandlerAsync(Employee_ID, string.Empty, model.Note);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> LunchBrakeAsync(AttendanceViewModel model)
        {
            var Employee_ID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string methodType = "LunchBrakeIN";
            if ( model.CheckOutLunchBrake == null)
                methodType = "LunchBrakeOUT";
           await _domain.AttendanceHandlerAsync(Employee_ID, methodType, string.Empty);
            return RedirectToAction("Index");
        }
    }
}