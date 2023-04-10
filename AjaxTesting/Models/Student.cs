using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AjaxTesting.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required]
        [StringLength(20,MinimumLength = 2, ErrorMessage ="حداقل 2 و حداکثر 20 کاراکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "حداقل 3 و حداکثر 20 کاراکتر باشد")]
        public string Family { get; set; }
        [Display(Name = "موبایل")]
        [Required]
        [Phone]
        [MaxLength(15)]
        public string  Phonenumber { get; set; }
        [Display(Name ="سن")]
        [Required]
        public int Age { get; set; }
    }
}