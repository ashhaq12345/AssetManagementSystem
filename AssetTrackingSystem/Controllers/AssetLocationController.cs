using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS.Models;
using POS.Models.Database;

namespace AssetTrackingSystem.Controllers
{
    public class AssetLocationController : Controller
    {
        private POSDbContext db = new POSDbContext();

        // GET: AssetLocation
        public ActionResult Index()
        {
            var assetLocation = db.AssetLocation.Include(a => a.Branch);
            return View(assetLocation.ToList());
        }

        // GET: AssetLocation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = db.AssetLocation.Find(id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            return View(assetLocation);
        }

        // GET: AssetLocation/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branch, "Id", "Name");
            return View();
        }

        // POST: AssetLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,LocationCode,BranchId")] AssetLocation assetLocation)
        {
            if (ModelState.IsValid)
            {
                db.AssetLocation.Add(assetLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branch, "Id", "Name", assetLocation.BranchId);
            return View(assetLocation);
        }

        // GET: AssetLocation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = db.AssetLocation.Find(id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branch, "Id", "Name", assetLocation.BranchId);
            return View(assetLocation);
        }

        // POST: AssetLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,LocationCode,BranchId")] AssetLocation assetLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branch, "Id", "Name", assetLocation.BranchId);
            return View(assetLocation);
        }

        // GET: AssetLocation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = db.AssetLocation.Find(id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            return View(assetLocation);
        }

        // POST: AssetLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AssetLocation assetLocation = db.AssetLocation.Find(id);
            db.AssetLocation.Remove(assetLocation);
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
