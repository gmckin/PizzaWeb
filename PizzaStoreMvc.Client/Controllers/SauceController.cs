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
  public class SauceController : Controller
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-34-193-186-107.compute-1.amazonaws.com/PizzaStoreAPI/api/sauce";

    public SauceController()
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

        var sauce = JsonConvert.DeserializeObject<List<Sauce>>(responseData);

        return View(sauce);
      }
      return View("Error");
    }

    // GET: Sauce/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Sauce sauce = db.Sauces.Find(id);
      if (sauce == null)
      {
        return HttpNotFound();
      }
      return View(sauce);
    }

    // GET: Sauce/Create
    public ActionResult Create()
    {
      return View(new Sauce());
    }

    // POST: Sauce/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "ID,Name,Quantity,Price")] Sauce sauce)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, sauce);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Sauce/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Sauce sauce = db.Sauces.Find(id);
      if (sauce == null)
      {
        return HttpNotFound();
      }
      return View(sauce);
    }

    // POST: Sauce/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ID,Name")] Sauce sauce)
    {
      if (ModelState.IsValid)
      {
        db.Entry(sauce).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(sauce);
    }

    // GET: Sauce/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Sauce sauce = db.Sauces.Find(id);
      if (sauce == null)
      {
        return HttpNotFound();
      }
      return View(sauce);
    }

    // POST: Sauce/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Sauce sauce = db.Sauces.Find(id);
      db.Sauces.Remove(sauce);
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
