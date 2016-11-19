using Newtonsoft.Json;
using PizzaStoreApp.WebAPI.Models;
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
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api";


    public HomeController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }


    [HttpGet]
    // GET: Home
    public async Task<ActionResult> Index()
    {
      var x = url + "/Customer";

      HttpResponseMessage responseMessage = await client.GetAsync(x);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var Customer = JsonConvert.DeserializeObject<List<Customer>>(responseData);

        return View(Customer);
      }
      return View("Error");
    }
    //var orderModel = new PizzaOrder();

    //return View(orderModel);
  

  //[HttpPost]
  //public ActionResult Index(PizzaOrder order)
  //{
  //  var sauce = order.Options.Sauces.FirstOrDefault(s => s.Selected);
  //  return View(sauce);
  //}



}
}
