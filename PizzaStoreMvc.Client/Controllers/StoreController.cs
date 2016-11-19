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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzaStoreMvc.Client.Controllers
{
    public class StoreController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/store";


    public StoreController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET: Email
    public async Task<ActionResult> Index()
    {
      //var x = url + "/Email";
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var store = JsonConvert.DeserializeObject<List<Store>>(responseData);

        return View(store);
      }
      return View("Error");
      //return View(db.Emails.ToList());
    }

    // GET: Email/Create
    public ActionResult Create()
    {
      return View(new Store());
    }

    // POST: Email/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "StoreID,Phone,Address,City,State,Email,Zip")] Store store)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, store);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Email/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var store = JsonConvert.DeserializeObject<Store>(responseData);

        return View(store);
      }
      return View("Error");
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "StoreID,Phone,Address,City,State,Email,Zip")] int id, Store store)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, store);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Store/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }
                 
        // GET: Store/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
