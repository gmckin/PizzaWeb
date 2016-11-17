using PizzaStoreMvc.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Business.Repositories
{
  public static class SauceRepo
  {
    private static List<Sauce> sauces = new List<Sauce>
    {
      new Sauce() { Name="Tomato", Price = 1M, Quantity = 100 },
      new Sauce() { Name="Marinara", Price = 0.5M, Quantity = 100 },
      new Sauce() { Name="No Sauce", Price = 0M, Quantity = 100 }
    };

    public static List<Sauce> GetSauces()
    {
      return sauces;
    }
  }
}
