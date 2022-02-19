using Employee_Attendance.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        // LateCheckInReason, EarlyCheckOutReason


        [Display(Name = "الملاحظة", Prompt = "ملاحظة")]
        [StringLength(150)]
        public string Note { get; set; }

        public string LateCheckInReason { get; set; }
        public string EarlyCheckOutReason { get; set; }

        [DefaultValue(0)]
        public bool? EarlyCheckOutDayEnd { get; set; }

        public Employee Employee { get; set; }
        public string Employee_ID { get; set; }

        public string MethodCheckInOutType
        {
            get
            {
                return AttendanceDay == DateTime.MinValue ? "تسجيل الدخول" : "تسجيل الخروج";
            }
        }  
        public string MethodLunchBrakeType
        {
            get
            {
                return CheckOutLunchBrake == null ? "تسجيل الخروج لاجل استراحة الغداء" : "تسجيل الدخول لاجل أكمال العمل";
            }
        }
    }
}