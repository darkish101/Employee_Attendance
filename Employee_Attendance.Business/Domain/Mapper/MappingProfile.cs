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

            CreateMap<Attendance, AttendanceViewModel>();
            CreateMap<AttendanceViewModel, Attendance>();

            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
