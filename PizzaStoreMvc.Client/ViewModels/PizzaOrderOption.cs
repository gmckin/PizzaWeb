using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class PizzaOrderOption
  {
    public SelectList Sauce { get; set; }
    public SelectList Crust { get; set; }
    public SelectList Cheese { get; set; }
    public SelectList Size  { get; set; }
    public SelectList Topping { get; set; }
  }
}