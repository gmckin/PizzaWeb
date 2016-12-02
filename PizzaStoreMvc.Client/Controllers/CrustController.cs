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
using System.Web.Helpers;

namespace PizzaStoreMvc.Client.Controllers
{
    public class CrustController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-34-193-186-107.compute-1.amazonaws.com/PizzaStoreAPI.Client/api/crust";

    public CrustController()
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

        var crust = JsonConvert.DeserializeObject<List<Crust>>(responseData);

        return View(crust);
      }
      return View("Error");
    }

    private async Task<List<SelectListItem>> GetCrust()
    {

      var crustOptions = new List<SelectListItem>();
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var crust = JsonConvert.DeserializeObject<List<Crust>>(responseData);

        foreach (var item in crust)
        {
          crustOptions.Add(new SelectListItem() { Text = item.Name, Value = item.CrustID.ToString() });
        };
        return crustOptions;
      }
      return crustOptions;

    }

    // GET: Crust/Create
    // GET: Cheese/Create
    public ActionResult Create()
    {
      return View(new Crust());
    }

    // POST: Cheese/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "ID,Name,Quantity,Price")] Crust crust)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, crust);
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

        var crust = JsonConvert.DeserializeObject<Crust>(responseData);

        return View(crust);
      }
      return View("Error");
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Quantity,Price")]int id, Crust crust)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, crust);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
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
