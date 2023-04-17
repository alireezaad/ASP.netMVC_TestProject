using CodeFirst_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace CodeFirst_EF.Controllers
{
    public class HomeController : Controller
    {
        DBSchoolContext db = new DBSchoolContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(string returnURl = "/")
        {
            Admins admin = new Admins()
            {
                ReturnURL = returnURl
            };
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "Phonenumber,Password,ReturnURL,SaveInfo")]Admins admin)
        {
            if (ModelState.IsValid)
            {
                if (db.admins.FirstOrDefault(t => t.Phonenumber == admin.Phonenumber && t.Password == t.Password) != null)
                {
                    FormsAuthentication.SetAuthCookie(admin.Phonenumber, admin.SaveInfo);
                    return Redirect(admin.ReturnURL);
                }
                else
                {
                    ModelState.AddModelError("Phonenumber", "شماره موبایل یا رمز عبور اشتباه است");
                }
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}