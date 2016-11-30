using Newtonsoft.Json;
//using PizzaStoreApp.WebAPI.Models;
using PizzaStoreMvc.Client.ViewModels;
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
  public class HomeController : Controller
  {

    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/order";

    public HomeController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }


    [HttpGet]
    // GET: Home
    public ActionResult Index()
    {
      return View();
    }



    [HttpPost]
    public ActionResult Index1(PizzaOrder order)
    {

           var cos = order.Customer.Orders.ToList();
      return View(cos);
    }


    //[HttpPost]
    //public ActionResult Index2(CustomerViewModel customer)
    //{
    //  var cus = new Customer();
      
      
    //  return View(customer);
    //}

    //[HttpPost]
    //public async Task<ActionResult> OrderInfo(PizzaOrderDetail od)
    //{
    //  HttpResponseMessage responseMessage = await client.GetAsync(url);
    //  if (responseMessage.IsSuccessStatusCode)
    //  {
    //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //    var s = JsonConvert.DeserializeObject<List<Order>>(responseData);

    //    return View(s);
    //  }
    //  return View("Error");
    //}

    //private async Task<List<SelectListItem>> GetSauceOptions()
    //{

    //  var sauceOptions = new List<SelectListItem>();

    //  HttpResponseMessage responseMessage = await client.GetAsync(url + "/sauce");
    //  if (responseMessage.IsSuccessStatusCode)
    //  {
    //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //    var sauce = JsonConvert.DeserializeObject<List<Sauce>>(responseData);

    //    foreach (var item in sauce)
    //    {
    //      sauceOptions.Add(new SelectListItem() { Text = item.Name, Value = item.SauceID.ToString() });
    //    };
    //    return sauceOptions;
    //  }
    //  return sauceOptions;
    //}

    //private async Task<List<SelectListItem>> GetSizeOptions()
    //{

    //  var sizeOptions = new List<SelectListItem>();
    //  HttpResponseMessage responseMessage = await client.GetAsync(url + "/size");
    //  if (responseMessage.IsSuccessStatusCode)
    //  {
    //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //    var size = JsonConvert.DeserializeObject<List<Size>>(responseData);

    //    foreach (var item in size)
    //    {
    //      sizeOptions.Add(new SelectListItem() { Text = item.Name, Value = item.SizeID.ToString() });
    //    };
    //    return sizeOptions;
    //  }
    //  return sizeOptions;
    //}

    //private async Task<List<SelectListItem>> GetCrustOptions()
    //{

    //  var crustOptions = new List<SelectListItem>();
    //  HttpResponseMessage responseMessage = await client.GetAsync(url + "/crust");
    //  if (responseMessage.IsSuccessStatusCode)
    //  {
    //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //    var crust = JsonConvert.DeserializeObject<List<Crust>>(responseData);

    //    foreach (var item in crust)
    //    {
    //      crustOptions.Add(new SelectListItem() { Text = item.Name, Value = item.CrustID.ToString() });
    //    };
    //    return crustOptions;
    //  }
    //  return crustOptions;

    //}

    //private async Task<List<SelectListItem>> GetToppingOptions()
    //{      
    //  var toppingOptions = new List<SelectListItem>();
    //  HttpResponseMessage responseMessage = await client.GetAsync(url + "/topping");
    //  if (responseMessage.IsSuccessStatusCode)
    //  {
    //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //    var topping = JsonConvert.DeserializeObject<List<Topping>>(responseData);

    //    foreach (var item in topping)
    //    {
    //      toppingOptions.Add(new SelectListItem() { Text = item.Name, Value = item.ToppingID.ToString() });
    //    };
    //    return toppingOptions;
    //  }
    //  return toppingOptions;
    //}

    //private async Task<List<SelectListItem>> GetCheeseOptions()
    //{

    //  var cheeseOptions = new List<SelectListItem>();
    //  HttpResponseMessage responseMessage = await client.GetAsync(url + "/cheese");
    //  if (responseMessage.IsSuccessStatusCode)
    //  {
    //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //    var cheese = JsonConvert.DeserializeObject<List<Cheese>>(responseData);

    //    foreach (var item in cheese)
    //    {
    //      cheeseOptions.Add(new SelectListItem() { Text = item.Name, Value = item.CheeseID.ToString() });
    //    };
    //    return cheeseOptions;
    //  }
    //  return cheeseOptions;
    //}

  }
}
