using PizzaStoreMvc.Client.DomainModels;
using PizzaStoreMvc.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaStoreMvc.Tests
{
  public class MvcTests
  {
    private PizzaStoreAPIContext db = new PizzaStoreAPIContext();

    [Fact]
    public void Test_GetCustomerInfo()
    {
      var c = new Customer();
      
      var actual = c.CustomerId.ToString();

      Assert.NotNull(actual);
    }


    [Fact]
    public void Test_GetOrderInfo()
    {
      var c = new Customer();

      var actual = c.AddressID.ToString();

      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_GetCustomerOrders()
    {
      var c = new Customer();

      var actual = c.CityID.ToString();

      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_GetStoreOrders()
    {
      var c = new Store();

      var actual = c.Address.ToString();

      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_GetPizzas()
    {
      var c = new Pizza();

      var actual = c.PizzaId.ToString();

      Assert.NotNull(actual);
    }
  }
}
