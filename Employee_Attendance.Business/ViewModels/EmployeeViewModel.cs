using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee_Attendance.Business
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [Display(Prompt = "الرقم الوظيفي")]
        [StringLength(20)]
        public string Employment_Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [Display(Name = "اسم المستخدم/ة", Prompt = "اسم المستخدم/ة")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [Display(Prompt = "اسم الموظف/ة")]
        [StringLength(150)]
        public string Employee_Name { get; set; }

        [Display(Prompt = "كلمة المرور")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(264)]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة تأكيد كلمة المرور")]
        [DataType(DataType.Password)]
        [Display(Prompt = "تأكيد كلمة المرور")]
        [Compare("Passowrd")]
        public string Confirmpwd { get; set; }

        [Required(ErrorMessage = "الرجاء كتابة البريد الاكتروني")]
        [Display(Prompt = "البريد الاكتروني")]
        public string Email { get; set; }



        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Discriminator { get; set; }
        public string Added_By { get; set; }


        public string MethodType
        {
            get
            {
                return string.IsNullOrEmpty(Id) ? "إضافة" : "تعديل";
            }
        }
    }
}
