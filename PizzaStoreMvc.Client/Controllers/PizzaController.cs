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
    public class PizzaController : Controller
    {
        private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/Pizza";
    
    public PizzaController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET: Pizza
    //public ActionResult Index()
    //{
    //    var pizzas = db.Pizzas.Include(p => p.Crust).Include(p => p.Order).Include(p => p.Sauce).Include(p => p.Size);
    //    return View(pizzas.ToList());
    public async Task<ActionResult> Index()
    {
      //var x = url + "/Email";
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var piz = JsonConvert.DeserializeObject<List<Pizza>>(responseData);

        return View(piz);
      }
      return View("Error");
    }

        // GET: Pizza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

    // GET: Address/Create
    public ActionResult Create()
    {
      return View(new Pizza());
    }

    // POST: Address/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "PizzaId,SizeID,CrustID,SauceID,Price,OrderID")] Pizza pizza)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, pizza);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }
    // GET: Pizza/Create
    //public ActionResult Create()
    //{
    //    ViewBag.CrustID = new SelectList(db.Crusts, "ID", "Name");
    //    ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
    //    ViewBag.SauceID = new SelectList(db.Sauces, "SauceID", "Name");
    //    ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Name");
    //    return View();
    //}

    //// POST: Pizza/Create
    //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create([Bind(Include = "PizzaId,SizeID,CrustID,SauceID,Price,OrderID")] Pizza pizza)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        db.Pizzas.Add(pizza);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    ViewBag.CrustID = new SelectList(db.Crusts, "ID", "Name", pizza.CrustID);
    //    ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", pizza.OrderID);
    //    ViewBag.SauceID = new SelectList(db.Sauces, "SauceID", "Name", pizza.SauceID);
    //    ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Name", pizza.SizeID);
    //    return View(pizza);
    //}

    // GET: Address/Edit/5
    public async Task<ActionResult> Edit(int? id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var pizza = JsonConvert.DeserializeObject<Pizza>(responseData);

        return View(pizza);
      }
      return View("Error");
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "PizzaId, SizeID, CrustID, SauceID, Price, OrderID")]int id, Pizza pizza)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, pizza);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    //// GET: Pizza/Edit/5
    //public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Pizza pizza = db.Pizzas.Find(id);
    //        if (pizza == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        ViewBag.CrustID = new SelectList(db.Crusts, "ID", "Name", pizza.CrustID);
    //        ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", pizza.OrderID);
    //        ViewBag.SauceID = new SelectList(db.Sauces, "SauceID", "Name", pizza.SauceID);
    //        ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Name", pizza.SizeID);
    //        return View(pizza);
    //    }

    //    // POST: Pizza/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "PizzaId,SizeID,CrustID,SauceID,Price,OrderID")] Pizza pizza)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(pizza).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.CrustID = new SelectList(db.Crusts, "ID", "Name", pizza.CrustID);
    //        ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", pizza.OrderID);
    //        ViewBag.SauceID = new SelectList(db.Sauces, "SauceID", "Name", pizza.SauceID);
    //        ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Name", pizza.SizeID);
    //        return View(pizza);
    //    }

    // GET: Pizza/Delete/5
    public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return HttpNotFound();
            }
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            db.Pizzas.Remove(pizza);
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
