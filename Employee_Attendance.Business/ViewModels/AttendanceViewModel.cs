using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Attendance.Business
{
    public class AttendanceViewModel
    {
        public Attendance Attendance { get; set; }
        public Employee Employee { get; set; }
    }
}