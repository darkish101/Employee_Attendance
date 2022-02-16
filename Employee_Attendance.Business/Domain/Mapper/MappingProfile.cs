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
                .ForSourceMember(e => e.Id, opt => opt.DoNotValidate()); ;
            CreateMap<EmployeeViewModel, Employee>()
                .ForMember(e => e.PasswordHash, m => m.MapFrom(m => m.Passowrd))
                .ForSourceMember(e => e.Id, opt => opt.DoNotValidate());
        }
    }
}
