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
        private IOrganizationManager _organizationManager;

        public BranchController()
        {
            _branchManager = new BranchManager();
            _organizationManager = new OrganizationManager();
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
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Code,Description,BranchCode,OrganizationId,Organization.ShortName")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                ViewBag.OrganizationId = new SelectList(_branchManager.GetOrganizationCategories(), "Id", "Name");
                try
                {
                    branch.BranchCode = GetOrganizationShortName(branch);
                    _branchManager.Add(branch);
                } catch(Exception ex)
                {
                    ModelState.AddModelError("ShortName", ex.Message);
                    return View();
                }
                
                return RedirectToAction("Index");
            }

            
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
                ViewBag.OrganizationId = new SelectList(_branchManager.GetOrganizationCategories(), "Id", "Name");
                try
                {
                    branch.BranchCode = GetOrganizationShortName(branch);
                    _branchManager.Update(branch);
                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ShortName", ex.Message);
                }
                return RedirectToAction("Index");
            }
            
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
        
        public string GetOrganizationShortName(Branch branch)
        {
            Organization organization = _organizationManager.GetById((long)branch.OrganizationId);
            return organization.ShortName + "_" + branch.ShortName;
        }

        public JsonResult GetBranchByOrganization(long organizationId)
        {
            var Branches = _branchManager.GetBranchByOrganization(organizationId);
            var jsonProducts = Branches.Select(c => new { c.Id, c.Name, c.OrganizationId });
            return Json(jsonProducts, JsonRequestBehavior.AllowGet);
        }

    }
}
