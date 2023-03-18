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
using E02.Third_partyClass;
using CodeFirst_EF.App_Start;

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
            List<Student> list = await db.students.ToListAsync();


            List<StudentViewModel> studentList = new List<StudentViewModel>();

            studentList = AutoMapperConfig.mapper.Map<List<Student>, List<StudentViewModel>>(list);

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
                //db.students.Add(new Student() 
                //{
                //    Name = newStudent.Name,
                //    Family = newStudent.Family,
                //    Phonenumber = newStudent.Phonenumber,
                //    Email = newStudent.Email,
                //    Password = HashPass.ComputeSha256Hash(newStudent.Password),
                //    IsActive = true,
                //    RegisterDate = DateTime.Now,
                //});

                Student student = AutoMapperConfig.mapper.Map<StudentCreateViewModel, Student>(newStudent);
                student.Password = HashPass.ComputeSha256Hash(newStudent.Password);
                student.IsActive = true;
                student.RegisterDate = DateTime.Now;
                db.students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("StudentList");
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include ="Phonenumber,Password")]StudentLoginViewModel student)
        {
            var pass = HashPass.ComputeSha256Hash(student.Password);
            if (ModelState.IsValid)
            {
                var log = await db.students.FirstOrDefaultAsync(t => t.Phonenumber == student.Phonenumber && t.Password == pass);
                if (log == null)
                {
                    ModelState.AddModelError("Phonenumber","شماره همراه یا رمز عبور صحیح نمی باشد!");
                    return View(student);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
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
