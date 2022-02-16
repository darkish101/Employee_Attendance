using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_Attendance.Data
{
    public class Employee : IdentityUser//, BaseEntity<int>
    {
        public string Employment_Id { get; set; }
        
        public string Employee_Name { get; set; } 
        
        [StringLength(450)]
        public string Added_By { get; set; }
        
        [DefaultValue("GETDATE()")]
        public DateTime? Created_On { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
