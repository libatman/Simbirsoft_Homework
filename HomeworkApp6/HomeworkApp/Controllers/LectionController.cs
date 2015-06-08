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
    public class LectionController : Controller
    {
        private MyDBContext db = new MyDBContext();

        //
        // GET: /Lection/

        public ActionResult Index()
        {
            return View(db.Lections.ToList());
        }

        //
        // GET: /Lection/Details/5

        public ActionResult Details(int id = 0)
        {
            LectionModels lectionmodels = db.Lections.Find(id);
            if (lectionmodels == null)
            {
                return HttpNotFound();
            }
            return View(lectionmodels);
        }

        //
        // GET: /Lection/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lection/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LectionModels lectionmodels)
        {
            if (ModelState.IsValid)
            {
                db.Lections.Add(lectionmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lectionmodels);
        }

        //
        // GET: /Lection/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LectionModels lectionmodels = db.Lections.Find(id);
            if (lectionmodels == null)
            {
                return HttpNotFound();
            }
            return View(lectionmodels);
        }

        //
        // POST: /Lection/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LectionModels lectionmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lectionmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lectionmodels);
        }

        //
        // GET: /Lection/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LectionModels lectionmodels = db.Lections.Find(id);
            if (lectionmodels == null)
            {
                return HttpNotFound();
            }
            return View(lectionmodels);
        }

        //
        // POST: /Lection/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LectionModels lectionmodels = db.Lections.Find(id);
            db.Lections.Remove(lectionmodels);
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