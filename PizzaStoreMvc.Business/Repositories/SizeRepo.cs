using PizzaStoreMvc.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Business.Repositories
{
  public static class SizeRepo
  {
    private static List<Size> sizes = new List<Size>
    {
      new Size() { Name="Small", Price = 4M, Quantity = 200 },
      new Size() { Name="Medium", Price = 6M, Quantity = 300 },
      new Size() { Name="Large", Price = 8M, Quantity = 400 }
    };

    public static List<Size> GetSizes()
    {
      return sizes;
    }
  }
}
