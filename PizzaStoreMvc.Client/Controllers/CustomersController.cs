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
    public class CustomersController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Address).Include(c => c.City).Include(c => c.Email).Include(c => c.Name).Include(c => c.Phone).Include(c => c.State).Include(c => c.Zip);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress");
            ViewBag.NameID = new SelectList(db.Names, "NameID", "First");
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number");
            ViewBag.StateID = new SelectList(db.State, "StateID", "Name");
            ViewBag.ZipID = new SelectList(db.Zip, "AddressID", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,NameID,PhoneID,AddressID,CityID,StateID,ZipID,EmailID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", customer.AddressID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", customer.CityID);
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress", customer.EmailID);
            ViewBag.NameID = new SelectList(db.Names, "NameID", "First", customer.NameID);
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number", customer.PhoneID);
            ViewBag.StateID = new SelectList(db.State, "StateID", "Name", customer.StateID);
            ViewBag.ZipID = new SelectList(db.Zip, "AddressID", "Name", customer.ZipID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", customer.AddressID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", customer.CityID);
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress", customer.EmailID);
            ViewBag.NameID = new SelectList(db.Names, "NameID", "First", customer.NameID);
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number", customer.PhoneID);
            ViewBag.StateID = new SelectList(db.State, "StateID", "Name", customer.StateID);
            ViewBag.ZipID = new SelectList(db.Zip, "AddressID", "Name", customer.ZipID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,NameID,PhoneID,AddressID,CityID,StateID,ZipID,EmailID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", customer.AddressID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", customer.CityID);
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress", customer.EmailID);
            ViewBag.NameID = new SelectList(db.Names, "NameID", "First", customer.NameID);
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number", customer.PhoneID);
            ViewBag.StateID = new SelectList(db.State, "StateID", "Name", customer.StateID);
            ViewBag.ZipID = new SelectList(db.Zip, "AddressID", "Name", customer.ZipID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
