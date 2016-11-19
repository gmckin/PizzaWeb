using PizzaStoreApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class CustomerOrder
  {
    public int StoreID { get; set; }
    


    public IEnumerable<Customer> Customer { get; set; }
    public IEnumerable<Order> Order { get; set; }
    public IEnumerable<Pizza>Pizza { get; set; }
    public IEnumerable<PizzaCheese> PCheese { get; set; }
    public IEnumerable<PizzaTopping> PTopping { get; set; }
  }
}