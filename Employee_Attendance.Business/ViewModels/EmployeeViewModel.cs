using System.ComponentModel.DataAnnotations;

namespace Employee_Attendance.Business
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        [Display(Prompt = "الرقم الوظيفي")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(20)]
        public string Employment_Id { get; set; }

        [Display(Name = "اسم المستخدم/ة", Prompt = "اسم المستخدم/ة")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Display(Prompt = "اسم الموظف/ة")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(150)]
        public string Employee_Name { get; set; }

        [Display(Prompt = "كلمة المرور")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(264, ErrorMessage = "كلمة المرور يجب بأن تكون اكثر من 6 خانات", MinimumLength = 6)]
        // At least one upper case English letter, (?=.*?[A - Z])
        // At least one lower case English letter, (?=.*?[a - z])
        // At least one digit, (?=.*?[0 - 9])
        // At least one special character, (?=.*?[#?!@$%^&*-])
        // Minimum six in length.{6,}
        [RegularExpression(@"^(?=.*[a-z]{1,})(?=.*[A-Z]{1,})(?=.*\d{1,})(?=.*[@$!%*?#&.]{1,})[A-Za-z\d@$!%*#?&\.]{6,}$", ErrorMessage = " الرجاء كتابة كلمة المرور تتكون من حروف إنجليزية حرف واحد كبير او اكثر وحرف واحد صغير او اكثر ورقم واحد او اكثر و رمز واحد من '., ?, @, $, !'")]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }

        [Display(Prompt = "تأكيد كلمة المرور")]
        [Required(ErrorMessage = "الرجاء كتابة تأكيد كلمة المرور")]
        [DataType(DataType.Password)]
        [Compare("Passowrd", ErrorMessage = "كلمة المرور وتأكيد كلمة الرور لا يتطابقان")]
        public string Confirmpwd { get; set; }

        [Display(Prompt = "البريد الاكتروني")]
        [Required(ErrorMessage = "الرجاء كتابة البريد الاكتروني")]
        public string Email { get; set; }

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