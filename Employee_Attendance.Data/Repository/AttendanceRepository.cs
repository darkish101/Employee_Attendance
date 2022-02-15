using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Attendance.Data
{
    public class AttendanceRepository : BaseRepository<Attendance, EmployeeAttendanceContext>
    {
        public AttendanceRepository(EmployeeAttendanceContext context) : base(context)
        { }
        public virtual async Task<List<Attendance>> GetAllAttendance()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<List<Attendance>> GetAllEmployeeAttendance(dynamic employee_obj)
        {
            return await _dbSet.FindAsync(employee_obj);
        }
    }
}