using AjaxTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxTesting.Controllers
{
    public class StudentController : Controller
    {
        AjaxTestingDbContext db = new AjaxTestingDbContext();
        // GET: Student
        public ActionResult GetAllStudents()
        {   
            return View(db.students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(string firstName, string lastName, string mobile, int age)
        {
            try
            {
                Student student = new Student()
                {
                    Name = firstName,
                    Family = lastName,
                    Phonenumber = mobile,
                    Age = age,
                };
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("GetAllStudents");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult RemoveStudent(int id)
        {
            try
            {
                var student = db.students.Find(id);
                if (student != null)
                {
                    db.students.Remove(student);
                    db.SaveChanges();
                }
                return RedirectToAction("GetAllStudents");
            }
            catch
            {
                return View();
            }
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
