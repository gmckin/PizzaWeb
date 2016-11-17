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
    public class PizzaCheeseController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

        // GET: PizzaCheese
        public ActionResult Index()
        {
            var pizzaCheese = db.PizzaCheese.Include(p => p.Cheese).Include(p => p.Pizza);
            return View(pizzaCheese.ToList());
        }

        // GET: PizzaCheese/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaCheese pizzaCheese = db.PizzaCheese.Find(id);
            if (pizzaCheese == null)
            {
                return HttpNotFound();
            }
            return View(pizzaCheese);
        }

        // GET: PizzaCheese/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Cheeses, "ID", "Name");
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId");
            return View();
        }

        // POST: PizzaCheese/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PizzaCheeseID,PizzaID,ID")] PizzaCheese pizzaCheese)
        {
            if (ModelState.IsValid)
            {
                db.PizzaCheese.Add(pizzaCheese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Cheeses, "ID", "Name", pizzaCheese.ID);
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaCheese.PizzaID);
            return View(pizzaCheese);
        }

        // GET: PizzaCheese/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaCheese pizzaCheese = db.PizzaCheese.Find(id);
            if (pizzaCheese == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Cheeses, "ID", "Name", pizzaCheese.ID);
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaCheese.PizzaID);
            return View(pizzaCheese);
        }

        // POST: PizzaCheese/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PizzaCheeseID,PizzaID,ID")] PizzaCheese pizzaCheese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizzaCheese).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Cheeses, "ID", "Name", pizzaCheese.ID);
            ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaCheese.PizzaID);
            return View(pizzaCheese);
        }

        // GET: PizzaCheese/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaCheese pizzaCheese = db.PizzaCheese.Find(id);
            if (pizzaCheese == null)
            {
                return HttpNotFound();
            }
            return View(pizzaCheese);
        }

        // POST: PizzaCheese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaCheese pizzaCheese = db.PizzaCheese.Find(id);
            db.PizzaCheese.Remove(pizzaCheese);
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
