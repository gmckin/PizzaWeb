using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzaStoreMvc.Client.DomainModels;
using PizzaStoreMvc.Client.Models;

namespace PizzaStoreMvc.Client.Controllers
{
    public class ToppingController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

        // GET: Topping
        public ActionResult Index()
        {
            return View(db.Toppings.ToList());
        }

        // GET: Topping/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topping topping = db.Toppings.Find(id);
            if (topping == null)
            {
                return HttpNotFound();
            }
            return View(topping);
        }

        // GET: Topping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Topping topping)
        {
            if (ModelState.IsValid)
            {
                db.Toppings.Add(topping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topping);
        }

        // GET: Topping/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topping topping = db.Toppings.Find(id);
            if (topping == null)
            {
                return HttpNotFound();
            }
            return View(topping);
        }

        // POST: Topping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Topping topping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topping);
        }

        // GET: Topping/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topping topping = db.Toppings.Find(id);
            if (topping == null)
            {
                return HttpNotFound();
            }
            return View(topping);
        }

        // POST: Topping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topping topping = db.Toppings.Find(id);
            db.Toppings.Remove(topping);
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
