using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Business
{
  public  class AttendanceDomain : BaseDomain<Attendance, AttendanceRepository>
    {
        private readonly AttendanceRepository _repostory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AttendanceDomain(AttendanceRepository repository
            , IUnitOfWork unitOfWork
            , IMapper mapper) : base(repository, unitOfWork)
        {
            _repostory = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task InsertAttendance(AttendanceViewModel viewModel)
        {
            try
            {
                var modal = _mapper.Map<Attendance>(viewModel);
                
                await base.InsertAsync(modal);
            }
            catch
            {
                throw;
            }
        }
        public async Task UpdateAttendance(AttendanceViewModel viewModel)
        {
            try
            {
                var modal = _mapper.Map<Attendance>(viewModel);

                await base.UpdateAsync(modal);
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteAttendance(int Id)
        {
            try
            {
                await base.DeleteAsync(Id);
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
                var modal = _mapper.Map<List<AttendanceViewModel>>(attendances);

                return modal;
                //    categories.Select(x => new TemplateViewModel
                //{
                //    Id = x.Id,
                //    Name = x.Name,
                //    PhotoString = x.Photo,
                //}).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<AttendanceViewModel> GetTodayAttendance(string today, string Employee_ID)
        {
            try
            {
                var data = await _repostory.GetAllAttendance();
                var attendance = data.Where(x => x.AttendanceDay == DateTime.Parse(today)).Where(x => x.Employee.Id == Employee_ID).FirstOrDefault();
                return _mapper.Map<AttendanceViewModel>(attendance);
                //    new TemplateViewModel
                //{
                //    Id = template.Id,
                //    Name = template.Name,
                //    PhotoString = template.Photo,
                //};
            }
            catch
            {
                throw;
            }
        } 
        public async Task<AttendanceViewModel> AttendanceById(int Id)
        {
            try
            {
               // var result = _repository.FromSql($"call storedProcedureName()").ToList();
                var data = await _repostory.GetAllAttendance();
                var attendance = data.First(x => x.Id == Id);
                return _mapper.Map<AttendanceViewModel>(attendance);
                //    new TemplateViewModel
                //{
                //    Id = template.Id,
                //    Name = template.Name,
                //    PhotoString = template.Photo,
                //};
            }
            catch
            {
                throw;
            }
        }
    }
}
