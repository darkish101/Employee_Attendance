using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IList<Attendance>> GetAttendance()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Attendance> ExceSPAsync(string Employee_ID, string TypeOfOpration, string Note)
        {
            var data = await _dbSet.FromSqlRaw("EXECUTE sp_Attandence @p_Employee_ID = {0}, @p_TypeOfOpration = {1}, @p_Note = {2}", Employee_ID, TypeOfOpration, Note).ToListAsync();
            return data.FirstOrDefault();
        }
        public async Task DeleteAttendance(string Employee_ID)
        {
            Func<Attendance, bool> expression = e => e.Employee_ID == Employee_ID;
            var data = await GetAttendance();
            foreach (var record in data.Where(expression).ToList())
            {
                _dbSet.Remove(record);
            }
        }
    }
}