using PizzaStoreMvc.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Business.Repositories
{
  public static class ToppingRepo
  {
    private static List<Topping> toppings = new List<Topping>
    {
      new Topping() { Name="Pepperoni", Price = 1M, Quantity = 100 },
      new Topping() { Name="Canadian Bacon", Price = 1M, Quantity = 100 },
      new Topping() { Name="Sausage", Price = 1M, Quantity = 100 },
       new Topping() { Name="None", Price = 0M, Quantity = 100 }
    };

    public static List<Topping> GetToppings()
    {
      return toppings;
    }
  }
}
