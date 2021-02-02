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
    public class StateController : Controller
    {
        private Db db = new Db();

        // GET: State
        public ActionResult Index()
        {
            var state = db.State.Include(s => s.City);
            return View(state.ToList());
        }

        // GET: State/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName");
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stateId,stateName,cityId")] State state)
        {
            if (ModelState.IsValid)
            {
                db.State.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName", state.cityId);
            return View(state);
        }

        // GET: State/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName", state.cityId);
            return View(state);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stateId,stateName,cityId")] State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cityId = new SelectList(db.City, "cityId", "cityName", state.cityId);
            return View(state);
        }

        // GET: State/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            State state = db.State.Find(id);
            db.State.Remove(state);
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
