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
    public class StandardController : Controller
    {
        private Db db = new Db();

        // GET: Standard
        public ActionResult Index()
        {
            return View(db.Standard.ToList());
        }

        // GET: Standard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standard.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // GET: Standard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Standard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "standardId,standardName,description")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Standard.Add(standard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standard);
        }

        // GET: Standard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standard.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // POST: Standard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "standardId,standardName,description")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standard);
        }

        // GET: Standard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standard.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // POST: Standard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Standard standard = db.Standard.Find(id);
            db.Standard.Remove(standard);
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
