using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Data
{
    public class EmployeeRepository //: BaseRepository<Employee, EmployeeAttendanceContext>
    {
        private readonly EmployeeAttendanceContext _context;
        public EmployeeRepository(EmployeeAttendanceContext dbContext)//: base(dbContext)
        {
            _context = dbContext;
        }

        public virtual async Task<IList<Employee>> GetAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }
        public virtual async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }


        public virtual async Task InsertAsync(Employee model)
        {
            await _context.Employees.AddAsync(model);
        }
        public virtual async Task DeleteAsync(int Id)
        {
            var entity = await _context.Employees.FindAsync(Id);
            _context.Employees.Remove(entity);
        }

    }
}
