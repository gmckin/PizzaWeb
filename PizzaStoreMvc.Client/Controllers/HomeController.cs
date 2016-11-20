using Newtonsoft.Json;
using PizzaStoreApp.WebAPI.Models;

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
    


    [HttpGet]
    // GET: Home
    public ActionResult Index()
    {
      return View();
    }
   
  

  //[HttpPost]
  //public ActionResult Index(PizzaOrder order)
  //{
  //  var sauce = order.Options.Sauces.FirstOrDefault(s => s.Selected);
  //  return View(sauce);
  //}



}
}
