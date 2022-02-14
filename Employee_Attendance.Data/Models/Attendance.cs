using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee_Attendance.Data
{
    public class Attendance : BaseEntity<int>
    {
        [Column(TypeName = "Date", Order = 2)]
        [DefaultValue("CONVERT(DATE ,GETDATE())")]
        public DateTime AttendanceDay { get; set; }

        [Column(TypeName = "time(7)", Order = 3)]
        public TimeSpan CheckInDayStart { get; set; }
        
        [Column(TypeName = "time(7)", Order = 4)]
        public TimeSpan CheckOutLunchBrake { get; set; }
        
        [Column(TypeName = "time(7)", Order = 5)]
        public TimeSpan CheckInLunchBrake { get; set; }
        
        [Column(TypeName = "time(7)", Order = 6)]
        public TimeSpan CheckOutDayEnd { get; set; }

        [Column(TypeName = "bit", Order = 7)]
        [DefaultValue(0)]
        public bool LateCheckIn { get; set; }
        
        [Column(TypeName = "nvarchar(150)", Order = 8)]
        public string LateCheckInReason { get; set; }
        
        [Column(TypeName = "bit", Order = 9)]
        [DefaultValue(0)]
        public bool EarlyCheckOutDayEnd { get; set; }

         [Column(TypeName = "nvarchar(150)", Order = 10)]
        public string EarlyCheckOutReason { get; set; }
        

         [Column(TypeName = "nvarchar(450)", Order = 11)]
        public Employee Employee { get; set; }
    }
}