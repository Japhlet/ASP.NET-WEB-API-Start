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
    public class StudentAddressController : Controller
    {
        private Db db = new Db();

        // GET: StudentAddress
        public ActionResult Index()
        {
            var studentAddress = db.StudentAddress.Include(s => s.City).Include(s => s.State).Include(s => s.Student);
            return View(studentAddress.ToList());
        }

        // GET: StudentAddress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            if (studentAddress == null)
            {
                return HttpNotFound();
            }
            return View(studentAddress);
        }

        // GET: StudentAddress/Create
        public ActionResult Create()
        {
            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName");
            ViewBag.stateId = new SelectList(db.State, "stateId", "stateName");
            ViewBag.studentId = new SelectList(db.Student, "studentId", "firstName");
            return View();
        }

        // POST: StudentAddress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,studentId,address1,address2,cityId,stateId")] StudentAddress studentAddress)
        {
            if (ModelState.IsValid)
            {
                db.StudentAddress.Add(studentAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName", studentAddress.cityId);
            ViewBag.stateId = new SelectList(db.State, "stateId", "stateName", studentAddress.stateId);
            ViewBag.studentId = new SelectList(db.Student, "studentId", "firstName", studentAddress.studentId);
            return View(studentAddress);
        }

        // GET: StudentAddress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            if (studentAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName", studentAddress.cityId);
            ViewBag.stateId = new SelectList(db.State, "stateId", "stateName", studentAddress.stateId);
            ViewBag.studentId = new SelectList(db.Student, "studentId", "firstName", studentAddress.studentId);
            return View(studentAddress);
        }

        // POST: StudentAddress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,studentId,address1,address2,cityId,stateId")] StudentAddress studentAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName", studentAddress.cityId);
            ViewBag.stateId = new SelectList(db.State, "stateId", "stateName", studentAddress.stateId);
            ViewBag.studentId = new SelectList(db.Student, "studentId", "firstName", studentAddress.studentId);
            return View(studentAddress);
        }

        // GET: StudentAddress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            if (studentAddress == null)
            {
                return HttpNotFound();
            }
            return View(studentAddress);
        }

        // POST: StudentAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAddress studentAddress = db.StudentAddress.Find(id);
            db.StudentAddress.Remove(studentAddress);
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
