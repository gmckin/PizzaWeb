using PizzaStoreMvc.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Business.Repositories
{
  public static class CheeseRepo
  {
    private static List<Cheese> cheeses = new List<Cheese>
    {
      new Cheese() { Name="Mozzarella", Price = 1M, Quantity = 100 },
      new Cheese() { Name="Cheddar", Price = 0.5M, Quantity = 100 },
      new Cheese() { Name="No Cheese", Price = 0M, Quantity = 100 }
    };

    public static List<Cheese> GetCheeses()
    {
      return cheeses;
    }
  }
}
