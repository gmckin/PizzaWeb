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
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PizzaStoreMvc.Client.Controllers
{
  public class OrderController : Controller
  {
    HttpClient client;
     private PizzaStoreAPIContext db = new PizzaStoreAPIContext();
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/order";

    public OrderController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET: Order
    public async Task<ActionResult> Index()
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var Ord = JsonConvert.DeserializeObject<List<Order>>(responseData);

        return View(Ord);
      }
      return View("Error");
    }

    public ActionResult Create()
    {
      return View(new Customer());
    }

    //The Post method
    [HttpPost]
    public async Task<ActionResult> Create(Order order)
    {
      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, order);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }
    
    public async Task<ActionResult> Edit(int id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var ord = JsonConvert.DeserializeObject<Order>(responseData);

        return View(ord);
      }
      return View("Error");
    }

    //The PUT Method
    [HttpPost]
    public async Task<ActionResult> Edit(int id, Order order)
    {
      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, order);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    public async Task<ActionResult> Delete(int id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var order = JsonConvert.DeserializeObject<Order>(responseData);

        return View(order);
      }
      return View("Error");
    }

    //The DELETE method
    [HttpPost]
    public async Task<ActionResult> Delete(int id, Order order)
    {
      HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
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
