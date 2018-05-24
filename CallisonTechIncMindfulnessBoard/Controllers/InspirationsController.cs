using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CallisonTechIncMindfulnessBoard.Models;

namespace CallisonTechIncMindfulnessBoard.Controllers
{
    public class InspirationsController : Controller
    {
        private CallisonTechMindfulStaffEntities db = new CallisonTechMindfulStaffEntities();

        // GET: Inspirations
        public ActionResult Index()
        {
            return View(db.Inspirations.ToList());
        }

        // GET: Inspirations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspiration inspiration = db.Inspirations.Find(id);
            if (inspiration == null)
            {
                return HttpNotFound();
            }
            return View(inspiration);
        }

        // GET: Inspirations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inspirations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Postion,Quote,EmployeeId")] Inspiration inspiration)
        {
            if (ModelState.IsValid)
            {
                db.Inspirations.Add(inspiration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inspiration);
        }

        // GET: Inspirations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspiration inspiration = db.Inspirations.Find(id);
            if (inspiration == null)
            {
                return HttpNotFound();
            }
            return View(inspiration);
        }

        // POST: Inspirations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Postion,Quote,EmployeeId")] Inspiration inspiration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspiration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inspiration);
        }

        // GET: Inspirations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspiration inspiration = db.Inspirations.Find(id);
            if (inspiration == null)
            {
                return HttpNotFound();
            }
            return View(inspiration);
        }

        // POST: Inspirations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inspiration inspiration = db.Inspirations.Find(id);
            db.Inspirations.Remove(inspiration);
            db.SaveChanges();
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
