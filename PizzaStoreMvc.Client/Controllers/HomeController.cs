using PizzaStoreMvc.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
      var orderModel = new PizzaOrder();
      
      return View(orderModel);
    }

    //[HttpPost]
    //public ActionResult Index(PizzaOrder order)
    //{
    //  var sauce = order.Options.Sauces.FirstOrDefault(s => s.Selected);
    //  return View(sauce);
    //}
  }
}