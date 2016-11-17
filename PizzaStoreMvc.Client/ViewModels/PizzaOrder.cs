using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class PizzaOrder
  {
    [Required(ErrorMessage = "fix it")]
    public List<PizzaOrderOption> Options { get; set; }

    [Required(ErrorMessage = "fix it")]
    public List<PizzaOrderDetail> Details { get; set; }

    [Required(ErrorMessage = "fix it")]
    public Customer Customer { get; set; }

    public PizzaOrder()
    {
      Options = new List<PizzaOrderOption>();
      Details = new List<PizzaOrderDetail>();
    }
  }
}