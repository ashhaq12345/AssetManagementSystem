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
    public class BranchController : Controller
    {
        private IBranchManager _branchManager;

        public BranchController()
        {
            _branchManager = new BranchManager();
        }

        // GET: Branch
        public ActionResult Index()
        {
            var branches = _branchManager.GetAll();
            return View(branches.ToList());
        }

        // GET: Branch/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = _branchManager.GetById((long)id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(_branchManager.GetOrganizationCategories(), "Id", "Name");
            return View();
        }

        // POST: Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Code,Description,BranchCode,OrganizationId")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchManager.Add(branch);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(_branchManager.GetOrganizationCategories(), "Id", "Name");
            return View(branch);
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = _branchManager.GetById((long)id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(_branchManager.GetOrganizationCategories(), "Id", "Name");
            return View(branch);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Code,Description,BranchCode,OrganizationId")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchManager.Update(branch);
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(_branchManager.GetOrganizationCategories(), "Id", "Name");
            return View(branch);
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = _branchManager.GetById((long)id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _branchManager.Remove(id);
            return RedirectToAction("Index");
        }
        

        
    }
}
