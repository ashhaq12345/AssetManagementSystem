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
    public class ModelController : Controller
    {
        private IModelManager _modelManager;

        public ModelController()
        {
            _modelManager = new ModelManager();
        }

        // GET: Model
        public ActionResult Index()
        {
            var models = _modelManager.GetAll();
            return View(models.ToList());
        }

        // GET: Model/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = _modelManager.GetById((long)id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Model/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_modelManager.GetCategories(), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(_modelManager.GetManufacturer(), "Id", "Name");
            return View();
        }

        // POST: Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,ManufacturerId")] Model model)
        {
            if (ModelState.IsValid)
            {
                _modelManager.Add(model);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_modelManager.GetCategories(), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(_modelManager.GetManufacturer(), "Id", "Name");
            return View(model);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = _modelManager.GetById((long)id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_modelManager.GetCategories(), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(_modelManager.GetManufacturer(), "Id", "Name");
            return View(model);
        }

        // POST: Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,ManufacturerId")] Model model)
        {
            if (ModelState.IsValid)
            {
                _modelManager.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_modelManager.GetCategories(), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(_modelManager.GetManufacturer(), "Id", "Name");
            return View(model);
        }

        // GET: Model/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = _modelManager.GetById((long)id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _modelManager.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
