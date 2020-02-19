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
    public class ProductFeaturesController : Controller
    {
        private DbEcommerce db = new DbEcommerce();

        // GET: ProductFeatures
        public ActionResult Index()
        {
            var productFeatures = db.ProductFeatures.Include(p => p.Feature).Include(p => p.FeatureOption).Include(p => p.Product);
            return View(productFeatures.ToList());
        }

        // GET: ProductFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeatures.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            return View(productFeature);
        }

        // GET: ProductFeatures/Create
        public ActionResult Create()
        {
            ViewBag.FeatureId = new SelectList(db.Features, "FeatureId", "FeatureName");
            ViewBag.FeatureOptionId = new SelectList(db.FeatureOptions, "FeatureOptionId", "FeatureOptionsName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: ProductFeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductFeatureId,ProductId,FeatureId,FeatureOptionId,FeaturePriceIncrement")] ProductFeature productFeature)
        {
            if (ModelState.IsValid)
            {
                db.ProductFeatures.Add(productFeature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FeatureId = new SelectList(db.Features, "FeatureId", "FeatureName", productFeature.FeatureId);
            ViewBag.FeatureOptionId = new SelectList(db.FeatureOptions, "FeatureOptionId", "FeatureOptionsName", productFeature.FeatureOptionId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productFeature.ProductId);
            return View(productFeature);
        }

        // GET: ProductFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeatures.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeatureId = new SelectList(db.Features, "FeatureId", "FeatureName", productFeature.FeatureId);
            ViewBag.FeatureOptionId = new SelectList(db.FeatureOptions, "FeatureOptionId", "FeatureOptionsName", productFeature.FeatureOptionId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productFeature.ProductId);
            return View(productFeature);
        }

        // POST: ProductFeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductFeatureId,ProductId,FeatureId,FeatureOptionId,FeaturePriceIncrement")] ProductFeature productFeature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productFeature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FeatureId = new SelectList(db.Features, "FeatureId", "FeatureName", productFeature.FeatureId);
            ViewBag.FeatureOptionId = new SelectList(db.FeatureOptions, "FeatureOptionId", "FeatureOptionsName", productFeature.FeatureOptionId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productFeature.ProductId);
            return View(productFeature);
        }

        // GET: ProductFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeatures.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            return View(productFeature);
        }

        // POST: ProductFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductFeature productFeature = db.ProductFeatures.Find(id);
            db.ProductFeatures.Remove(productFeature);
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
