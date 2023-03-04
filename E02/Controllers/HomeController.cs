using E02.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E02.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {

            return View();
        }

        public ActionResult PersonalPage(string firstName, string lastName, string phoneNumber, string email, string nationalCode, HttpPostedFileBase profile)
        {
            string pic = Guid.NewGuid().ToString() + profile.FileName + Path.GetExtension(profile.FileName);
            profile.SaveAs(Server.MapPath("/images/profile/" + pic));
            ViewBag.Name = firstName;
            ViewBag.Family = lastName;
            ViewBag.Phone = phoneNumber;
            ViewBag.Email = email;
            ViewBag.NationalCode = nationalCode;
            ViewBag.Image = "/images/profile/" + pic;
            return View();
        }
        public ActionResult LogedIn(string name, string lastname)
        {
            ViewBag.Name = name;
            ViewBag.Lastname = lastname;
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}