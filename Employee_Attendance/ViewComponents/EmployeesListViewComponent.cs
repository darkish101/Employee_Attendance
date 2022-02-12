using Employee_Attendance.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Attendance
{
    public class EmployeesListViewComponent : ViewComponent
    {
        private readonly EmployeeDomain _Domain;

        public EmployeesListViewComponent(EmployeeDomain Domain)
        {
            _Domain = Domain;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            return View(await _Domain.GetAllEmployee());
        }
    }
}
