using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeworkApp.Models;

namespace HomeworkApp.Controllers
{
    public class StudentController : Controller
    {
        private MyDBContext db = new MyDBContext();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentModels studentmodels = db.Students.Find(id);
            if (studentmodels == null)
            {
                return HttpNotFound();
            }
            return View(studentmodels);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModels studentmodels)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(studentmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentmodels);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentModels studentmodels = db.Students.Find(id);
            if (studentmodels == null)
            {
                return HttpNotFound();
            }
            return View(studentmodels);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModels studentmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentmodels);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentModels studentmodels = db.Students.Find(id);
            if (studentmodels == null)
            {
                return HttpNotFound();
            }
            return View(studentmodels);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModels studentmodels = db.Students.Find(id);
            db.Students.Remove(studentmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}