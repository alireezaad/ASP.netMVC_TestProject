using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class StudentViewModel
    {
        [Display(Name = "آیدی")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Display(Name = "شماره تلفن")]
        public string Phonenumber { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}