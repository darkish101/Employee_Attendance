using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Attendance.Data
{
    public class AttendanceRepository : BaseRepository<Attendance, EmployeeAttendanceContext>
    {
        public AttendanceRepository(EmployeeAttendanceContext dbcontext) : base(dbcontext)
        { }
        public virtual async Task<IList<Attendance>> GetAllAttendance()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<IList<Attendance>> GetAllEmployeeAttendance(dynamic attendance_obj)
        {
            return await _dbSet.FindAsync(attendance_obj);
        } 
        public virtual async Task<IList<Attendance>> GetAttendanceSP(dynamic attendance_obj)
        {
            return await _dbSet.FindAsync(attendance_obj);
        }
    }
}