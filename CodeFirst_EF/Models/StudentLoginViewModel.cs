using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class StudentLoginViewModel
    {
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [RegularExpression("(09)[0-9]{9}", ErrorMessage = "فرمت شماره تلفن اشتباه است!")]
        public string Phonenumber { get; set; }

        [Display(Name = "رمز")]
        [Required(ErrorMessage = "فیلد {0} ضروری است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}