using CodeFirst_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_EF.Areas.Admin.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        DBSchoolContext db = new DBSchoolContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Panel(string phonenumber)
        {
            var admin = db.admins.FirstOrDefault(t => t.Phonenumber == phonenumber);
            return View(admin);
        }
    }
}