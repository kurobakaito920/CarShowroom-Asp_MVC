using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_car_demo2.Models;

namespace web_car_demo2.Areas.admin.Controllers
{
    public class stocksController : Controller
    {
        private JinzuaCarShopEntities db = new JinzuaCarShopEntities();

        // GET: admin/stocks
        public ActionResult Index()
        {
            var stocks = db.stocks.Include(s => s.product);
            return View(stocks.ToList());
        }

        // GET: admin/stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: admin/stocks/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
            return View();
        }

        // POST: admin/stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,quantity")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", stock.product_id);
            return View(stock);
        }

        // GET: admin/stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", stock.product_id);
            return View(stock);
        }

        // POST: admin/stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,quantity")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", stock.product_id);
            return View(stock);
        }

        // GET: admin/stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: admin/stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock stock = db.stocks.Find(id);
            db.stocks.Remove(stock);
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
