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
    public class CheeseController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

        // GET: Cheese
        public ActionResult Index()
        {
            return View(db.Cheeses.ToList());
        }

        // GET: Cheese/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheese cheese = db.Cheeses.Find(id);
            if (cheese == null)
            {
                return HttpNotFound();
            }
            return View(cheese);
        }

        // GET: Cheese/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cheese/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Cheese cheese)
        {
            if (ModelState.IsValid)
            {
                db.Cheeses.Add(cheese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cheese);
        }

        // GET: Cheese/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheese cheese = db.Cheeses.Find(id);
            if (cheese == null)
            {
                return HttpNotFound();
            }
            return View(cheese);
        }

        // POST: Cheese/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Cheese cheese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cheese).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cheese);
        }

        // GET: Cheese/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheese cheese = db.Cheeses.Find(id);
            if (cheese == null)
            {
                return HttpNotFound();
            }
            return View(cheese);
        }

        // POST: Cheese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cheese cheese = db.Cheeses.Find(id);
            db.Cheeses.Remove(cheese);
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
