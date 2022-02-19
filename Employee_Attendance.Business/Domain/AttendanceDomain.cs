using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Attendance.Business
{
    public class AttendanceDomain : BaseDomain<Attendance, AttendanceRepository>
    {
        private readonly AttendanceRepository _repostory;
        private readonly IMapper _mapper;
        public AttendanceDomain(AttendanceRepository repository
            , IUnitOfWork unitOfWork
            , IMapper mapper) : base(repository, unitOfWork)
        {
            _repostory = repository;
            _mapper = mapper;
        }
        public async Task AttendanceHandlerAsync(string Employee_ID, string TypeOfOpration, string Note)
        {
            try
            {
                await _repository.ExceSPAsync(Employee_ID, TypeOfOpration, Note);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AttendanceViewModel>> GetAllAttendance()
        {
            try
            {
                var attendances = await _repostory.GetAllAttendance();

                return _mapper.Map<List<AttendanceViewModel>>(attendances);
            }
            catch
            {
                throw;
            }
        }
        public async Task<AttendanceViewModel> GetDayAttendanceAsync(string day, string Employee_ID)
        {
            try
            {
                Func<Attendance, bool> expression = e => e.Employee_ID == Employee_ID && e.AttendanceDay == DateTime.Parse(day);
                var data = await _repository.GetAttendance();

                var modal = data.Where(expression).FirstOrDefault();

                if (modal == null)
                    modal = new Attendance();

                return _mapper.Map<AttendanceViewModel>(modal);
            }
            catch
            {
                throw;
            }
        }

        public async Task<HoursWorkedViewModel> HoursWorked(string Employee_ID)
        {
            var sunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);// begin of week
            var thursday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday); // end of week
            Func<Attendance, bool> expression = e => e.Employee_ID == Employee_ID && (e.AttendanceDay >= sunday && e.AttendanceDay <= thursday);

            var data = await _repository.GetAttendance();
            double HoursWorked = 0;

            foreach (var aDay in data.Where(expression).ToList())
            {
                HoursWorked += aDay.CheckOutDayEnd.HasValue ? (aDay.CheckOutDayEnd.Value - aDay.CheckInDayStart).TotalHours : 0;
            }
            return new HoursWorkedViewModel { Hours = HoursWorked.ToString("0.0#"), HoursRemaing = (40 - HoursWorked <= 0 ? 0 : 40 - HoursWorked).ToString("0.0#") };
        }

        public async Task DeleteEmployeeAttendance(string employee_ID)
        {
            await _repository.DeleteAttendance(employee_ID);
        }
    }
}