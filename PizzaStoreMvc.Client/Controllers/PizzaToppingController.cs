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
    public class PizzaToppingController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

        // GET: PizzaTopping
        public ActionResult Index()
        {
            var pizzaToppings = db.PizzaToppings.Include(p => p.Pizza).Include(p => p.Topping);
            return View(pizzaToppings.ToList());
        }

        // GET: PizzaTopping/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
            if (pizzaTopping == null)
            {
                return HttpNotFound();
            }
            return View(pizzaTopping);
        }

        // GET: PizzaTopping/Create
        public ActionResult Create()
        {
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId");
            ViewBag.ID = new SelectList(db.Toppings, "ID", "Name");
            return View();
        }

        // POST: PizzaTopping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PizzaToppingID,PizzaID,ID")] PizzaTopping pizzaTopping)
        {
            if (ModelState.IsValid)
            {
                db.PizzaToppings.Add(pizzaTopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaTopping.PizzaID);
            ViewBag.ID = new SelectList(db.Toppings, "ID", "Name", pizzaTopping.ID);
            return View(pizzaTopping);
        }

        // GET: PizzaTopping/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
            if (pizzaTopping == null)
            {
                return HttpNotFound();
            }
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaTopping.PizzaID);
            ViewBag.ID = new SelectList(db.Toppings, "ID", "Name", pizzaTopping.ID);
            return View(pizzaTopping);
        }

        // POST: PizzaTopping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PizzaToppingID,PizzaID,ID")] PizzaTopping pizzaTopping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizzaTopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaTopping.PizzaID);
            ViewBag.ID = new SelectList(db.Toppings, "ID", "Name", pizzaTopping.ID);
            return View(pizzaTopping);
        }

        // GET: PizzaTopping/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
            if (pizzaTopping == null)
            {
                return HttpNotFound();
            }
            return View(pizzaTopping);
        }

        // POST: PizzaTopping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
            db.PizzaToppings.Remove(pizzaTopping);
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
