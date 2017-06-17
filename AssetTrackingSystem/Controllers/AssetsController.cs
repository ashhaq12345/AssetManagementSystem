using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS.BLL;
using POS.Models;
using POS.Models.Database;
using POS.Models.Interfaces;

namespace AssetTrackingSystem.Controllers
{
    public class AssetsController : Controller
    {
        private IAssetManager _assetManager;
        private IModelManager _modelManager;

        public AssetsController()
        {
            _assetManager = new AssetManager();
            _modelManager = new ModelManager();
        }

        // GET: Assets
        public ActionResult Index()
        {
            var asset = _assetManager.GetAll();
            return View(asset.ToList());
        }

        // GET: Assets/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = _assetManager.GetById((long)id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            ViewBag.ModelId = new SelectList(_modelManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,GeneralCateforyId,CateforyId,ModelId,Price,Qty,SerialCode")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _assetManager.Add(asset);
                return RedirectToAction("Index");
            }

            ViewBag.ModelId = new SelectList(_modelManager.GetAll(), "Id", "Name", asset.ModelId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = _assetManager.GetById((long)id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelId = new SelectList(_modelManager.GetAll(), "Id", "Name", asset.ModelId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,GeneralCateforyId,CateforyId,ModelId,Price,Qty,SerialCode")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                _assetManager.Update(asset);
                return RedirectToAction("Index");
            }
            ViewBag.ModelId = new SelectList(_modelManager.GetAll(), "Id", "Name", asset.ModelId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = _assetManager.GetById((long)id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _assetManager.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
