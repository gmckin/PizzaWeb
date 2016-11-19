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
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PizzaStoreMvc.Client.Controllers
{
  public class CheeseController : Controller
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/cheese";

    public CheeseController()
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

        var cheese = JsonConvert.DeserializeObject<List<Cheese>>(responseData);

        return View(cheese);
      }
      return View("Error");      
    }

    // GET: Cheese/Details/5
   

    // GET: Cheese/Create
    public ActionResult Create()
    {
      return View(new Cheese());
    }

    // POST: Cheese/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "ID,Name,Quantity,Price")] Cheese cheese)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, cheese);
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

        var cheese = JsonConvert.DeserializeObject<Cheese>(responseData);

        return View(cheese);
      }
      return View("Error");    
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Quantity,Price")]int id, Cheese cheese)
    {
      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, cheese);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");      
    }

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
