using E02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.Entity;

namespace E02.Controllers
{
    public class StudentsController : Controller
    {
        KaarishoEntities db = new KaarishoEntities();
        public ActionResult Index()
        {
            var students = db.Students;
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Family,Email,Phone")] Students student, HttpPostedFileBase newImage)
        {
            if (ModelState.IsValid)
            {
                string imageName = "user.jpg";
                if (newImage != null)
                {
                    if (newImage.ContentType != "image/jpeg" && newImage.ContentType != "image/png")
                    {
                        ModelState.AddModelError("newImage", "فرمت عکس شما باید jpeg یا png باشد!");
                        return View();
                    }
                    if (newImage.ContentLength > 400000)
                    {
                        ModelState.AddModelError("newImage", "حجم عکس شما باید کمتر از 400 کیوبایت باشد");
                        return View();
                    }

                    imageName = Guid.NewGuid().ToString().Replace("-","")+Path.GetExtension(newImage.FileName);
                    newImage.SaveAs(Server.MapPath("/images/profile/" + imageName));

                }
                student.IsActive = true;
                student.RegisterDate = DateTime.Now;
                student.ImageName = imageName;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var student = db.Students.Find(id);
            if (student is null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var student = db.Students.Find(id);
            if (student is null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Family,Email,Phone,ImageName,RegisterDate,IsActive")] Students student, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {

                if (imageUpload != null)
                {
                    if (imageUpload.ContentType != "image/jpeg" && imageUpload.ContentType != "image/png")
                    {
                        ModelState.AddModelError("newImage", "فرمت عکس شما باید jpeg یا png باشد!");
                        return View(student);
                    }
                    if (imageUpload.ContentLength > 400000)
                    {
                        ModelState.AddModelError("newImage", "حجم عکس شما باید کمتر از 400 کیوبایت باشد");
                        return View(student);
                    }

                    string newnewImage = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imageUpload.FileName);
                    imageUpload.SaveAs(Server.MapPath("/images/profile/" + newnewImage));
                    student.ImageName = newnewImage;
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var student = db.Students.Find(id);
            if (student is null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var student = db.Students.Find(id);
            if (student is null)
            {
                return HttpNotFound();
            }
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                if (student.ImageName != "user.jpg")
                {
                    if (System.IO.File.Exists(Server.MapPath("/images/profile/") + student.ImageName))
                    {
                        System.IO.File.Delete(Server.MapPath("/images/profile/") + student.ImageName);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(student);
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