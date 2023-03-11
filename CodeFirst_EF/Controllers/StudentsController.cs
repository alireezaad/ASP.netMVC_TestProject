using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst_EF.Models;

namespace CodeFirst_EF.Controllers
{
    public class StudentsController : Controller
    {
        private DBSchoolContext db = new DBSchoolContext();

        // GET: Students
        public async Task<ActionResult> Index()
        {
            return View(await db.students.ToListAsync());
        }

        public async Task<ActionResult> StudentList()
        {
            var list = db.students.Select(t => new
            {
                t.Name,
                t.Family,
                t.Email,
                t.Phonenumber
            }).ToListAsync();

            List<StudentViewModel> studentList = new List<StudentViewModel>();
            foreach (var item in await list)
            {
                studentList.Add(new StudentViewModel()
                {
                    Name = item.Name,
                    Family = item.Family,
                    Email = item.Email,
                    Phonenumber = item.Phonenumber
                });
            }
            return View(studentList);
        }
        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Family,Phonenumber,Email,Password,PasswordConfirm")] StudentCreateViewModel newStudent)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(new Student() 
                {
                    Name = newStudent.Name,
                    Family = newStudent.Family,
                    Phonenumber = newStudent.Phonenumber,
                    Email = newStudent.Email,
                    Password = newStudent.Password,
                    IsActive = true,
                    RegisterDate = DateTime.Now,
                });
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(newStudent);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Family,Phonenumber,Email,Password,RegisterDate,IsActive")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.students.FindAsync(id);
            db.students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
