using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employee_Attendance.Data
{
    public class EmployeeAttendanceContext : IdentityDbContext
    {
        public EmployeeAttendanceContext(DbContextOptions<EmployeeAttendanceContext> options): base (options)
        {}
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<Attendance> Attendances { set; get; }
        public virtual DbSet<Role> Roles { set; get; }
    }
}
