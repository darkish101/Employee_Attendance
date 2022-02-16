using Microsoft.AspNetCore.Identity;
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

        //public virtual DbSet<IdentityRole> Roles { set; get; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
        //    //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        //    modelBuilder.Entity<Attendance>()
        //        .HasKey(c => new { c.Id, c.AttendanceDay });
        //}
    }
}
