using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class Admins
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [StringLength(20,MinimumLength = 2, ErrorMessage ="{0} باید حداقل 2 و حداکثر 20 کاراکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نام خانوداگی")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} باید حداقل 2 و حداکثر 20 کاراکتر باشد")]
        public string Family { get; set; }
        [Display(Name = "موبایل")]
        [MaxLength(11)]
        public string Phonenumber { get; set; }
        [Display(Name = "رمز")]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }
        public string ReturnURL { get; set; }
        [Display(Name="مرا به خاطر بسپار")]
        public bool SaveInfo { get; set; }
    }
}