using System;
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
    public class FeatureOptionsController : Controller
    {
        private DbEcommerce db = new DbEcommerce();

        // GET: FeatureOptions
        public ActionResult Index()
        {
            return View(db.FeatureOptions.ToList());
        }

        // GET: FeatureOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureOption featureOption = db.FeatureOptions.Find(id);
            if (featureOption == null)
            {
                return HttpNotFound();
            }
            return View(featureOption);
        }

        // GET: FeatureOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeatureOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeatureOptionId,FeatureOptionsName")] FeatureOption featureOption)
        {
            if (ModelState.IsValid)
            {
                db.FeatureOptions.Add(featureOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(featureOption);
        }

        // GET: FeatureOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureOption featureOption = db.FeatureOptions.Find(id);
            if (featureOption == null)
            {
                return HttpNotFound();
            }
            return View(featureOption);
        }

        // POST: FeatureOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeatureOptionId,FeatureOptionsName")] FeatureOption featureOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(featureOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(featureOption);
        }

        // GET: FeatureOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeatureOption featureOption = db.FeatureOptions.Find(id);
            if (featureOption == null)
            {
                return HttpNotFound();
            }
            return View(featureOption);
        }

        // POST: FeatureOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeatureOption featureOption = db.FeatureOptions.Find(id);
            db.FeatureOptions.Remove(featureOption);
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
