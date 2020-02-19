﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class OptionGroupsController : Controller
    {
        private DbEcommerce db = new DbEcommerce();

        // GET: OptionGroups
        public ActionResult Index()
        {
            return View(db.OptionGroups.ToList());
        }

        // GET: OptionGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionGroup optionGroup = db.OptionGroups.Find(id);
            if (optionGroup == null)
            {
                return HttpNotFound();
            }
            return View(optionGroup);
        }

        // GET: OptionGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OptionGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OptionGroupId,OptionGroupName")] OptionGroup optionGroup)
        {
            if (ModelState.IsValid)
            {
                db.OptionGroups.Add(optionGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(optionGroup);
        }

        // GET: OptionGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionGroup optionGroup = db.OptionGroups.Find(id);
            if (optionGroup == null)
            {
                return HttpNotFound();
            }
            return View(optionGroup);
        }

        // POST: OptionGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OptionGroupId,OptionGroupName")] OptionGroup optionGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(optionGroup);
        }

        // GET: OptionGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionGroup optionGroup = db.OptionGroups.Find(id);
            if (optionGroup == null)
            {
                return HttpNotFound();
            }
            return View(optionGroup);
        }

        // POST: OptionGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionGroup optionGroup = db.OptionGroups.Find(id);
            db.OptionGroups.Remove(optionGroup);
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
