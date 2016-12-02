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
  public class PizzaToppingController : Controller
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-34-193-186-107.compute-1.amazonaws.com/PizzaStoreAPI/api/PizzaTopping";

    public PizzaToppingController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET: PizzaTopping
    public async Task<ActionResult> Index()
    {      
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var pt = JsonConvert.DeserializeObject<List<PizzaTopping>>(responseData);

        return View(pt);
      }
      return View("Error");
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

    // GET: Phone/Create
    public ActionResult Create()
    {
      return View(new PizzaTopping());
    }

    // POST: Phone/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "PizzaToppingID,PizzaID,ID")] PizzaTopping pt)
    {

      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, pt);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Phone/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var pt = JsonConvert.DeserializeObject<PizzaTopping>(responseData);

        return View(pt);
      }
      return View("Error");
    }

    // POST: Phone/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "PizzaToppingID,PizzaID,ID")] int id, PizzaTopping pt)
    {
      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, pt);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    //// GET: PizzaTopping/Create
    //public ActionResult Create()
    //{
    //  ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId");
    //  ViewBag.ID = new SelectList(db.Toppings, "ID", "Name");
    //  return View();
    //}

    //// POST: PizzaTopping/Create
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create([Bind(Include = "PizzaToppingID,PizzaID,ID")] PizzaTopping pizzaTopping)
    //{
    //  if (ModelState.IsValid)
    //  {
    //    db.PizzaToppings.Add(pizzaTopping);
    //    db.SaveChanges();
    //    return RedirectToAction("Index");
    //  }

    //  ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaTopping.PizzaID);
    //  ViewBag.ID = new SelectList(db.Toppings, "ID", "Name", pizzaTopping.ID);
    //  return View(pizzaTopping);
    //}

    //// GET: PizzaTopping/Edit/5
    //public ActionResult Edit(int? id)
    //{
    //  if (id == null)
    //  {
    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //  }
    //  PizzaTopping pizzaTopping = db.PizzaToppings.Find(id);
    //  if (pizzaTopping == null)
    //  {
    //    return HttpNotFound();
    //  }
    //  ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaTopping.PizzaID);
    //  ViewBag.ID = new SelectList(db.Toppings, "ID", "Name", pizzaTopping.ID);
    //  return View(pizzaTopping);
    //}

    //// POST: PizzaTopping/Edit/5
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit([Bind(Include = "PizzaToppingID,PizzaID,ID")] PizzaTopping pizzaTopping)
    //{
    //  if (ModelState.IsValid)
    //  {
    //    db.Entry(pizzaTopping).State = EntityState.Modified;
    //    db.SaveChanges();
    //    return RedirectToAction("Index");
    //  }
    //  ViewBag.PizzaID = new SelectList(db.Pizzas, "PizzaId", "PizzaId", pizzaTopping.PizzaID);
    //  ViewBag.ID = new SelectList(db.Toppings, "ID", "Name", pizzaTopping.ID);
    //  return View(pizzaTopping);
    //}

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
