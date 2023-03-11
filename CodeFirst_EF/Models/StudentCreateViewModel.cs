using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class StudentCreateViewModel
    {

        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "تعداد کاراکترها باید بین 2 و 30 عدد باشد!")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="تعداد کاراکترها باید بین 3 و 30 عدد باشد!")]
        public string Family { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت شماره تلفن اشتباه است!")]
        public string Phonenumber { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است!")]
        public string Email { get; set; }

        [Display(Name = "رمز")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [Compare("Password",ErrorMessage ="تکرار رمز مطابقت ندارد!")]
        public string PasswordConfirm { get; set; }

    }
}