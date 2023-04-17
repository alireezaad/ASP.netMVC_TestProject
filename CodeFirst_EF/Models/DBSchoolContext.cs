using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace CodeFirst_EF.Models
{
    public class DBSchoolContext : DbContext
    {
        public DbSet<Student> students { get; set; }

        public DbSet<Admins> admins { get; set; }

        public DBSchoolContext() : base("DBSchoolContext") { }

    }


}