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
    public class ToppingController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-34-193-186-107.compute-1.amazonaws.com/PizzaStoreAPI/api/topping";

    public ToppingController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<ActionResult> Index()
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var topping = JsonConvert.DeserializeObject<List<Topping>>(responseData);

        return View(topping);
      }
      return View("Error");
    }

    // GET: Cheese/Details/5


    // GET: Cheese/Create
    public ActionResult Create()
    {
      return View(new Topping());
    }

    // POST: Cheese/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "ID,Name,Quantity,Price")] Topping topping)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, topping);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    public async Task<ActionResult> Edit(int? id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var topping = JsonConvert.DeserializeObject<Topping>(responseData);

        return View(topping);
      }
      return View("Error");
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Quantity,Price")]int id, Topping topping)
    {
      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, topping);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
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
