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
    public class GeneralCategoryController : Controller
    {
        private IGeneralCategoryManager _generalCategoryManager;

        public GeneralCategoryController()
        {
            _generalCategoryManager = new GeneralCategoryManager();
        }

        // GET: GeneralCategory
        public ActionResult Index()
        {
            return View(_generalCategoryManager.GetAll());
        }

        // GET: GeneralCategory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = _generalCategoryManager.GetById((long)id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }

        // GET: GeneralCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Description")] GeneralCategory generalCategory)
        {
            if (ModelState.IsValid)
            {
               
                if(_generalCategoryManager.IsShortNameUnique(generalCategory.ShortName))
                {
                    _generalCategoryManager.Add(generalCategory);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("ShortName", "ShortName Is Not Unique!");
            }

            return View(generalCategory);
        }

        // GET: GeneralCategory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = _generalCategoryManager.GetById((long)id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }

        // POST: GeneralCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Description")] GeneralCategory generalCategory)
        {
            if (ModelState.IsValid)
            {
                if (_generalCategoryManager.IsShortNameUnique(generalCategory.ShortName))
                {
                    _generalCategoryManager.Update(generalCategory);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("ShortName", "ShortName Is Not Unique!");
            }
            return View(generalCategory);
        }

        // GET: GeneralCategory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = _generalCategoryManager.GetById((long)id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }

        // POST: GeneralCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _generalCategoryManager.Remove(id);
            return RedirectToAction("Index");
        }

        
    }
}
