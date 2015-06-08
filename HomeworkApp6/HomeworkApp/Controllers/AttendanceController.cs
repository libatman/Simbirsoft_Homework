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
    public class AttendanceController : Controller
    {
        private MyDBContext db = new MyDBContext();

        //
        // GET: /Attendance/

        public ActionResult Index()
        {
            var attendances = (from p in db.Attendances
                            join f in db.Lections
                        on p.IdLection equals f.Id
                            select new
                            {
                                Id = p.Id,
                                NumberStudents = p.NumberStudents,
                                IdLection = p.IdLection,
                                ThemeLection = f.Theme
                            }).ToList()
                      .Select(x => new AttendanceModels()
                      {
                          Id = x.Id,
                          NumberStudents = x.NumberStudents,
                          IdLection = x.IdLection,
                          ThemeLection = x.ThemeLection
                      });
            return View(attendances.ToList());
        }

        //
        // GET: /Attendance/Details/5

        public ActionResult Details(int id = 0)
        {
            AttendanceModels attendancemodels = db.Attendances.Find(id);
            if (attendancemodels == null)
            {
                return HttpNotFound();
            }
            return View(attendancemodels);
        }

        //
        // GET: /Attendance/Create

        public ActionResult Create()
        {
            ViewBag.IdLection = new SelectList(db.Lections, "Id", "Subject");
            return View(); 
        }

        //
        // POST: /Attendance/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendanceModels attendancemodels)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendancemodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLection = new SelectList(db.Lections, "Id", "Subject", attendancemodels.IdLection);
            return View(attendancemodels);
        }

        //
        // GET: /Attendance/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AttendanceModels attendancemodels = db.Attendances.Find(id);
            if (attendancemodels == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLection = new SelectList(db.Lections, "Id", "Subject", attendancemodels.IdLection);
            return View(attendancemodels);
        }

        //
        // POST: /Attendance/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttendanceModels attendancemodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendancemodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLection = new SelectList(db.Lections, "Id", "Subject", attendancemodels.IdLection);
            return View(attendancemodels);
        }

        //
        // GET: /Attendance/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AttendanceModels attendancemodels = db.Attendances.Find(id);
            if (attendancemodels == null)
            {
                return HttpNotFound();
            }
            return View(attendancemodels);
        }

        //
        // POST: /Attendance/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendanceModels attendancemodels = db.Attendances.Find(id);
            db.Attendances.Remove(attendancemodels);
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