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
using POS.Models.Interfaces;
using POS.BLL;

namespace AssetTrackingSystem.Controllers
{
    public class AssetLocationController : Controller
    {
        private IAssetLocationManager _assetLocationManager;
        private IOrganizationManager _organizationManager;
        private IBranchManager _branchManager;

        public AssetLocationController()
        {
            _assetLocationManager = new AssetLocationManager();
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
        }

        // GET: AssetLocation
        public ActionResult Index()
        {
            var assetLocations = _assetLocationManager.GetAll();
            return View(assetLocations.ToList());
        }

        // GET: AssetLocation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = _assetLocationManager.GetById((long)id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            return View(assetLocation);
        }

        // GET: AssetLocation/Create
        public ActionResult Create()
        {
            ViewBag.Organization = new SelectList(_organizationManager.GetAll(), "Id", "Name");
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
                if(_assetLocationManager.IsShortNameUnique(assetLocation.ShortName))
                {
                    assetLocation.LocationCode = GetAssetLocationCode(assetLocation);
                    _assetLocationManager.Add(assetLocation);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("ShortName", "ShortName is not Unique!");
            }

            ViewBag.Organization = new SelectList(_organizationManager.GetAll(), "Id", "Name");
            return View(assetLocation);
        }

        // GET: AssetLocation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = _assetLocationManager.GetById((long)id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organization = new SelectList(_organizationManager.GetAll(), "Id", "Name");
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
                if (_assetLocationManager.IsShortNameUnique(assetLocation.ShortName))
                {
                    assetLocation.LocationCode = GetAssetLocationCode(assetLocation);
                    _assetLocationManager.Update(assetLocation);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("ShortName", "ShortName is not Unique!");
            }
            ViewBag.Organization = new SelectList(_organizationManager.GetAll(), "Id", "Name");
            return View(assetLocation);
        }

        // GET: AssetLocation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = _assetLocationManager.GetById((long)id);
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
            _assetLocationManager.Remove(id);
            return RedirectToAction("Index");
        }

        public string GetAssetLocationCode(AssetLocation assetLocation)
        {
            Branch branch= _branchManager.GetById((long)assetLocation.BranchId);
            return branch.BranchCode + "_" + assetLocation.ShortName;
        }


    }
}
