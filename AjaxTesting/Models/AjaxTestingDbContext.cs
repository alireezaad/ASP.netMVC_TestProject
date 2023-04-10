using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxTesting.Models
{
    public class AjaxTestingDbContext:DbContext
    {
        public DbSet<Student> students { get; set; }
    }
}