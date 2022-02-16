using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Data.Repository
{
   public class RoleRepository
    {
        private readonly EmployeeAttendanceContext _context;
        public RoleRepository(EmployeeAttendanceContext dbContext)//: base(dbContext)
        {
            _context = dbContext;
        }

        public virtual async Task<IList<IdentityRole>> GetAllEmployee()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
