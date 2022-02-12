using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee_Attendance.Data
{
    public class Employee : IdentityUser//, BaseEntity<int>
    {
        public string Employment_Id { get; set; }

        //[Column(Order = 3)]
        //[StringLength(50)]
        //public string UserName { get; set; }

        public string Employee_Name { get; set; } 
        [StringLength(450)]
        public string Added_By { get; set; }

        //[Column(Order = 5)]
        //[StringLength(264)]
        //public string Password { get; set; }

        //[Column(Order = 6 )]
        //[StringLength(10)]
        //public string Role{ get; set; }

        //[Column(Order = 7)]
        //[StringLength(150)]
        //public string Email { get; set; }
    }
}
