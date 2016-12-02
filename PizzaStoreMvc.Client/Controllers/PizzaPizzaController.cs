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
  public class PizzaPizzaController : Controller
  {
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-34-193-186-107.compute-1.amazonaws.com/PizzaStoreAPI/api/email";


    public PizzaPizzaController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    // GET: PizzaPizza
    public ActionResult Index()
    {

      return View();
    }



    //public async Task <List<Topping>> GetStoresA()
    //{
    //  //HttpResponseMessage responseMessage = await client.GetAsync(url);
    //  //if (responseMessage.IsSuccessStatusCode)
    //  //{
    //  //  var responseData = responseMessage.Content.ReadAsStringAsync().Result;

    //  //  var top = JsonConvert.DeserializeObject<List<Topping>>(responseData);
    //  //  return View(top);
    //  }
    //    return Topping;
    //}

    public List<SelectListItem> SauceOption { get; set; }
    public List<SelectListItem> SizeOption { get; set; }
    public List<SelectListItem> CrustOption { get; set; }
    public List<SelectListItem> PizzaCheeseOption { get; set; }
    public List<SelectListItem> PizzaToppingOption { get; set; }


    public Order Order { get; set; }
    public Customer Customer { get; set; }
    public Store Store { get; set; }
  }

}