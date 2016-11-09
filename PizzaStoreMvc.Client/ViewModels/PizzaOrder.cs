using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class PizzaOrder
  {
    public List<PizzaOrderDetail> Details { get; set; }
    public Customer Customer { get; set; }
  }
}