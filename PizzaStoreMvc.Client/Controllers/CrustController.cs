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
    public class CrustController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

        // GET: Crust
        public ActionResult Index()
        {
            return View(db.Crusts.ToList());
        }

        // GET: Crust/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crust crust = db.Crusts.Find(id);
            if (crust == null)
            {
                return HttpNotFound();
            }
            return View(crust);
        }

        // GET: Crust/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crust/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Crust crust)
        {
            if (ModelState.IsValid)
            {
                db.Crusts.Add(crust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crust);
        }

        // GET: Crust/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crust crust = db.Crusts.Find(id);
            if (crust == null)
            {
                return HttpNotFound();
            }
            return View(crust);
        }

        // POST: Crust/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Crust crust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crust).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crust);
        }

        // GET: Crust/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crust crust = db.Crusts.Find(id);
            if (crust == null)
            {
                return HttpNotFound();
            }
            return View(crust);
        }

        // POST: Crust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crust crust = db.Crusts.Find(id);
            db.Crusts.Remove(crust);
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
