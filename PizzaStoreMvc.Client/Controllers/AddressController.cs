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
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PizzaStoreMvc.Client.Controllers
{
  public class AddressController : Controller
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/Address";
   
    public AddressController()
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

        var Address = JsonConvert.DeserializeObject<List<Address>>(responseData);
       
        return View(Address);
      }
      return View("Error");      
    }

   
    // GET: Address/Create
    public ActionResult Create()
    {
      return View(new Address());
    }

    // POST: Address/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "AddressID,StreetAddress")] Address address)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, address);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Address/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var addr = JsonConvert.DeserializeObject<Address>(responseData);

        return View(addr);
      }
      return View("Error");     
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "AddressID,StreetAddress")]int id, Address address)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, address);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");     
    }

    // GET: Address/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Address address = db.Addresses.Find(id);
      if (address == null)
      {
        return HttpNotFound();
      }
      return View(address);
    }

    // GET: Address/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Address address = db.Addresses.Find(id);
      if (address == null)
      {
        return HttpNotFound();
      }
      return View(address);
    }

    // POST: Address/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Address address = db.Addresses.Find(id);
      db.Addresses.Remove(address);
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
