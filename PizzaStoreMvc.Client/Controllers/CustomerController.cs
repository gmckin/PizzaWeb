using Newtonsoft.Json;
using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreMvc.Client.Controllers
{
    public class CustomerController : Controller
    {
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/customer";

    //The HttpClient Class, this will be used for performing 
    //HTTP Operations, GET, POST, PUT, DELETE
    //Set the base address and the Header Formatter
    public CustomerController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // GET: EmployeeInfo
    public async Task<ActionResult> Index()
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var Customer = JsonConvert.DeserializeObject<List<Customer>>(responseData);

        return View(Customer);
      }
      return View("Error");
    }

    public ActionResult Create()
    {
      return View(new Customer());
    }

    //The Post method
    [HttpPost]
    public async Task<ActionResult> Create(Customer customer)
    {

      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, customer);
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

        var Cust = JsonConvert.DeserializeObject<Customer>(responseData);

        return View(Cust);
      }
      return View("Error");
    }

    //The PUT Method
    [HttpPost]
    public async Task<ActionResult> Edit(int id, Customer customer)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, customer);
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

        var Cust = JsonConvert.DeserializeObject<Customer>(responseData);

        return View(Cust);
      }
      return View("Error");
    }

    //The DELETE method
    [HttpPost]
    public async Task<ActionResult> Delete(int id, Customer customer)
    {

      HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }
  }
}
