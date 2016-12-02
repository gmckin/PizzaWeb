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
  public class EmailController : Controller
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-34-193-186-107.compute-1.amazonaws.com/PizzaStoreAPI.Client/api/email";


    public EmailController()
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

        var Email = JsonConvert.DeserializeObject<List<Email>>(responseData);
       
        return View(Email);
      }
      return View("Error");
      //return View(db.Emails.ToList());
    }

    // GET: Email/Create
    public ActionResult Create()
    {
      return View(new Email());
    }

    // POST: Email/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "EmailID,EmailAddress")] Email email)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, email);
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

        var email = JsonConvert.DeserializeObject<Email>(responseData);

        return View(email);
      }
      return View("Error");
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "EmailID,EmailAddress")] int id, Email email)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, email);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    // GET: Email/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Email email = db.Emails.Find(id);
      if (email == null)
      {
        return HttpNotFound();
      }
      return View(email);
    }

    // POST: Email/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Email email = db.Emails.Find(id);
      db.Emails.Remove(email);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    // GET: Email/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Email email = db.Emails.Find(id);
      if (email == null)
      {
        return HttpNotFound();
      }
      return View(email);
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
