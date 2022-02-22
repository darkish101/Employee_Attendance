using AutoMapper;
using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Attendance.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Source, Destination
            CreateMap<Attendance, AttendanceViewModel>();
            CreateMap<AttendanceViewModel, Attendance>();

            CreateMap<Employee, EmployeeViewModel>()
                //.ForMember(e => e.Passowrd, m => m.MapFrom(m => m.PasswordHash))
                .ForSourceMember(e => e.PasswordHash, opt => opt.DoNotValidate())
                .ForSourceMember(e => e.Id, opt => opt.DoNotValidate());
            CreateMap<EmployeeViewModel, Employee>()
                .ForSourceMember(e => e.Passowrd, opt => opt.DoNotValidate())
                //.ForMember(e => e.PasswordHash, m => m.MapFrom(m => m.Passowrd))
                .ForSourceMember(e => e.Id, opt => opt.DoNotValidate());
        }
    }
}
