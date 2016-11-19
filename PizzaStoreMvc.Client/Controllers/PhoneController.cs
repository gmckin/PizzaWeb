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
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Client.Controllers
{
  public class PhoneController : Controller
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/phone";


    public PhoneController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET: Phone
    public async Task<ActionResult> Index()
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var phone = JsonConvert.DeserializeObject<List<Phone>>(responseData);

        return View(phone);
      }
      return View("Error");
      //return View(db.Phones.ToList());
    }

    // GET: Phone/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Phone phone = db.Phones.Find(id);
      if (phone == null)
      {
        return HttpNotFound();
      }
      return View(phone);
    }

    // GET: Phone/Create
    public ActionResult Create()
    {
      return View(new Phone());
    }

    // POST: Phone/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "NumberID,Number")] Phone phone)
    {

      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, phone);
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

        var phone = JsonConvert.DeserializeObject<Phone>(responseData);

        return View(phone);
      }
      return View("Error");
    }

    // POST: Phone/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "NumberID,Number")] int id, Phone phone)
    {
      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, phone);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Phone/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Phone phone = db.Phones.Find(id);
      if (phone == null)
      {
        return HttpNotFound();
      }
      return View(phone);
    }

    // POST: Phone/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Phone phone = db.Phones.Find(id);
      db.Phones.Remove(phone);
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
