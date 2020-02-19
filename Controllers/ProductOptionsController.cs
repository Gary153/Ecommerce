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
    public class ProductOptionsController : Controller
    {
        private DbEcommerce db = new DbEcommerce();

        // GET: ProductOptions
        public ActionResult Index()
        {
            var productOptions = db.ProductOptions.Include(p => p.Option).Include(p => p.OptionGroup).Include(p => p.Product);
            return View(productOptions.ToList());
        }

        // GET: ProductOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOption productOption = db.ProductOptions.Find(id);
            if (productOption == null)
            {
                return HttpNotFound();
            }
            return View(productOption);
        }

        // GET: ProductOptions/Create
        public ActionResult Create()
        {
            ViewBag.OptionsId = new SelectList(db.Options, "OptionsId", "OptionName");
            ViewBag.OptionGroupId = new SelectList(db.OptionGroups, "OptionGroupId", "OptionGroupName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: ProductOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductOptionId,OptionsId,ProductId,OptionGroupId,OptionPriceIncrement")] ProductOption productOption)
        {
            if (ModelState.IsValid)
            {
                db.ProductOptions.Add(productOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OptionsId = new SelectList(db.Options, "OptionsId", "OptionName", productOption.OptionsId);
            ViewBag.OptionGroupId = new SelectList(db.OptionGroups, "OptionGroupId", "OptionGroupName", productOption.OptionGroupId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productOption.ProductId);
            return View(productOption);
        }

        // GET: ProductOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOption productOption = db.ProductOptions.Find(id);
            if (productOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.OptionsId = new SelectList(db.Options, "OptionsId", "OptionName", productOption.OptionsId);
            ViewBag.OptionGroupId = new SelectList(db.OptionGroups, "OptionGroupId", "OptionGroupName", productOption.OptionGroupId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productOption.ProductId);
            return View(productOption);
        }

        // POST: ProductOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductOptionId,OptionsId,ProductId,OptionGroupId,OptionPriceIncrement")] ProductOption productOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OptionsId = new SelectList(db.Options, "OptionsId", "OptionName", productOption.OptionsId);
            ViewBag.OptionGroupId = new SelectList(db.OptionGroups, "OptionGroupId", "OptionGroupName", productOption.OptionGroupId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productOption.ProductId);
            return View(productOption);
        }

        // GET: ProductOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOption productOption = db.ProductOptions.Find(id);
            if (productOption == null)
            {
                return HttpNotFound();
            }
            return View(productOption);
        }

        // POST: ProductOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOption productOption = db.ProductOptions.Find(id);
            db.ProductOptions.Remove(productOption);
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
