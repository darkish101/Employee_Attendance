using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Business
{
  public  class AttendanceDomain : BaseDomain<Attendance, AttendanceRepository>
    {
        private readonly AttendanceRepository _repostory;
        private readonly IMapper _mapper;
        public AttendanceDomain(AttendanceRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _repostory = repository;
            _mapper = mapper;
        }
        public async Task InsertTemplate(AttendanceViewModel viewModel)
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
        public async Task UpdateTemplate(AttendanceViewModel viewModel)
        {
            try
            {
                var template = await _repository.GetAllAttendance();
                var modal = _mapper.Map<Attendance>(viewModel);

                await base.UpdateAsync(template);
            }
            catch
            {
                throw;
            }
        }
        public async Task DeleteTemplate(int Id)
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
        public async Task<List<AttendanceViewModel>> GetAllTemplate()
        {
            try
            {
                var categories = await _TemplateRepository.GetAllTemplate();
                var modal = _mapper.Map<Attendance>(viewModel);

                return categories.Select(x => new TemplateViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhotoString = x.Photo,
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<AttendanceViewModel> TemplateById(int Id)
        {
            try
            {
                var Data = await _TemplateRepository.GetAllTemplate();
                var template = Data.First(x => x.Id == Id);
                return new TemplateViewModel
                {
                    Id = template.Id,
                    Name = template.Name,
                    PhotoString = template.Photo,
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
