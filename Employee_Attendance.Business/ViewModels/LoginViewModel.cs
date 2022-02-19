using System.ComponentModel.DataAnnotations;

namespace Employee_Attendance.Business
{
   public class LoginViewModel
    {
        [Display(Name = "اسم المستخدم/ة", Prompt = "اسم المستخدم/ة")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Display(Prompt = "كلمة المرور")]
        [Required(ErrorMessage = "هذا الحقل إجباري")]
        [StringLength(264, ErrorMessage = "كلمة المرور يجب بأن تكون اكثر من 6 خانات", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z]{1,})(?=.*[A-Z]{1,})(?=.*\d{1,})(?=.*[@$!%*?#&.]{1,})[A-Za-z\d@$!%*#?&\.]{6,}$"
        , ErrorMessage = " الرجاء كتابة كلمة المرور تتكون من حروف إنجليزية حرف واحد كبير او اكثر وحرف واحد صغير او اكثر ورقم واحد او اكثر و رمز واحد من '., ?, @, $, !'")]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }
    }
}
