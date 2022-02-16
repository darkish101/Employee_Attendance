using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Employee_Attendance.Business
{
    public class AttendanceViewModel
    {
        [DefaultValue("CONVERT(DATE ,GETDATE())")]
        public DateTime AttendanceDay { get; set; }

        public TimeSpan CheckInDayStart { get; set; }

        public TimeSpan? CheckOutLunchBrake { get; set; }

        public TimeSpan? CheckInLunchBrake { get; set; }

        public TimeSpan? CheckOutDayEnd { get; set; }

        [DefaultValue(0)]
        public bool? LateCheckIn { get; set; }

        public string LateCheckInReason { get; set; }

        [DefaultValue(0)]
        public bool? EarlyCheckOutDayEnd { get; set; }

        public string EarlyCheckOutReason { get; set; }

        public Employee Employee { get; set; }
        public string Employee_ID { get; set; }

    }
}