using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E02.Models
{
    public class StudentsModel
    {
        [Display(Name = "آیدی")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "تعداد کاراکترها باید بین 2 و 15 حرف باشند")]
        [RegularExpression("^[آ-ی ]+$", ErrorMessage = "فقط کاراکترهای فارسی مورد تایید است!")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا فیلد {0} را پر کنید")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "تعداد کاراکترها باید بین 2 و 15 حرف باشند")]
        [RegularExpression("^[آ-ی ]+$", ErrorMessage = "فقط کاراکترهای فارسی مورد تایید است!")]

        public string Family { get; set; }

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل صحیح وارد نمایید")]
        public string Email { get; set; }

        [Display(Name = "شماره همراه")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "لطفا شماره تلفن صحیح وارد نمایید")]
        public string Phone { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [DisplayFormat(DataFormatString = "{0: dddd, dd MMMM yyyy}")]
        public System.DateTime RegisterDate { get; set; }


        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public StudentsModel()
        {

        }
        public StudentsModel(int id, string name, string family, string email, string phone, DateTime registerDate, bool isActive)
        {
            Id = id;
            Name = name;
            Family = family;
            Email = email;
            Phone = phone;
            RegisterDate = registerDate;
            IsActive = isActive;
        }
    }

    [MetadataType(typeof(StudentsModel))]
    public partial class Students
    {
        
    }
}