using PizzaStoreMvc.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Business.Repositories
{
  public static class CrustRepo
  {
    private static List<Crust> crusts = new List<Crust>
    {
      new Crust() { Name="Classic", Price = 1M, Quantity = 100 },
      new Crust() { Name="Thin", Price = 0.5M, Quantity = 100 },
      new Crust() { Name="Deep Dish", Price = 0M, Quantity = 100 }
    };

    public static List<Crust> GetCrusts()
    {
      return crusts;
    }
  }
}
