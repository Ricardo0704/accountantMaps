using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using invoice.Models;

namespace invoice.Controllers
{
    public class VatsController : Controller
    {
        private invoiceContext db = new invoiceContext();

        // GET: Vats
        public ActionResult Index()
        {
            return View(db.vats.ToList());
        }

        // GET: Vats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vat vat = db.vats.Find(id);
            if (vat == null)
            {
                return HttpNotFound();
            }
            return View(vat);
        }

        // GET: Vats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,vat,exempt,standardRated,zeroRated")] Vat vat)
        {
            if (ModelState.IsValid)
            {
                db.vats.Add(vat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vat);
        }

        // GET: Vats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vat vat = db.vats.Find(id);
            if (vat == null)
            {
                return HttpNotFound();
            }
            return View(vat);
        }

        // POST: Vats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,vat,exempt,standardRated,zeroRated")] Vat vat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vat);
        }

        // GET: Vats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vat vat = db.vats.Find(id);
            if (vat == null)
            {
                return HttpNotFound();
            }
            return View(vat);
        }

        // POST: Vats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vat vat = db.vats.Find(id);
            db.vats.Remove(vat);
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
