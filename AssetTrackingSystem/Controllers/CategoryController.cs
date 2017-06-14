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
    public class CategoryController : Controller
    {
        private ICategoryManager _categoryManager;

        public CategoryController()
        {
            _categoryManager = new CategoryManager();
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.GeneralCategoryId = new SelectList(_categoryManager.GetGeneralCategory(), "Id", "Name");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,CategoryCode,Description,GeneralCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction("Index");
            }

            ViewBag.GeneralCategoryId = new SelectList(_categoryManager.GetGeneralCategory(), "Id", "Name");
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneralCategoryId = new SelectList(_categoryManager.GetGeneralCategory(), "Id", "Name");
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,CategoryCode,Description,GeneralCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Update(category);
                return RedirectToAction("Index");
            }
            ViewBag.GeneralCategoryId = new SelectList(_categoryManager.GetGeneralCategory(), "Id", "Name");
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _categoryManager.GetById((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _categoryManager.Remove(id);
            return RedirectToAction("Index");
        }
        
    }
}
