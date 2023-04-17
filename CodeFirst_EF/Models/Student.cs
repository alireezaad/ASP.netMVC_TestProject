using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_EF.Models
{
    [Table("T_Students")]
    public class Student
    {
        [Key]
        [Display(Name="آیدی")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage ="فیلد {0} ضروری است")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [StringLength(30)]
        public string Family { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [RegularExpression("(09)[0-9]{9}",ErrorMessage ="فرمت شماره تلفن اشتباه است!")]
        [MaxLength(11)]
        public string Phonenumber { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [EmailAddress(ErrorMessage ="فرمت ایمیل اشتباه است!")]
        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Display(Name ="رمز")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        public bool IsActive { get; set; }
    }
}

//[Key]
//[Display(Name = "آیدی")]
//public int Id { get; set; }

//[Display(Name = "نام")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//[StringLength(30)]
//public string Name { get; set; }

//[Display(Name = "نام خانوادگی")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//[StringLength(30)]
//public string Family { get; set; }

//[Display(Name = "شماره تلفن")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//[RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت شماره تلفن اشتباه است!")]
//[MaxLength(11)]
//public string Phonenumber { get; set; }

//[Display(Name = "ایمیل")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//[EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است!")]
//[Column(TypeName = "varchar")]
//[MaxLength(50)]
//public string Email { get; set; }

//[Display(Name = "رمز")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//[DataType(DataType.Password)]
//public string Password { get; set; }

//[Display(Name = "تاریخ عضویت")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//public DateTime RegisterDate { get; set; }

//[Display(Name = "وضعیت")]
//[Required(ErrorMessage = "فیلد {0} ضروری است")]
//public bool IsActive { get; set; }