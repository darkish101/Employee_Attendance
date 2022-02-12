using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Employee_Attendance.Data
{
    public class EmployeeAttendanceContext : IdentityDbContext
    {
        public EmployeeAttendanceContext(DbContextOptions<EmployeeAttendanceContext> options): base (options)
        {}
        public virtual DbSet<Employee> Employees { set; get; }
    }
}
