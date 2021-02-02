using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    public class TeacherController : Controller
    {
        private Db db = new Db();

        // GET: Teacher
        public ActionResult Index()
        {
            var teacher = db.Teacher.Include(t => t.Standard);
            return View(teacher.ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacher.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            ViewBag.standardId = new SelectList(db.Standard, "standardId", "standardName");
            return View();
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teacherId,firstName,lastName,standardId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teacher.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.standardId = new SelectList(db.Standard, "standardId", "standardName", teacher.standardId);
            return View(teacher);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacher.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.standardId = new SelectList(db.Standard, "standardId", "standardName", teacher.standardId);
            return View(teacher);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teacherId,firstName,lastName,standardId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.standardId = new SelectList(db.Standard, "standardId", "standardName", teacher.standardId);
            return View(teacher);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacher.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teacher.Find(id);
            db.Teacher.Remove(teacher);
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
