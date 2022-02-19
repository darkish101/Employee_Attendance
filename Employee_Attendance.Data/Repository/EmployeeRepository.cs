using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Data
{
    public class EmployeeRepository
    {
        private readonly EmployeeAttendanceContext _context;
        public EmployeeRepository(EmployeeAttendanceContext dbContext)
        {
            _context = dbContext;
        }

        public virtual async Task<IList<Employee>> GetAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        public virtual async Task<Employee> GetEmployeeById(string id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}
