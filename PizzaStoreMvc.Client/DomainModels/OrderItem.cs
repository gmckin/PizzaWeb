using PizzaStoreApp.WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class OrderItem
  {
    [Key]
    public int OrderItemID { get; set; }

    public int CustomerID { get; set; }
    [ForeignKeyAttribute("CustomerID")]
    public Customer Customer { get; set; }

    public int OrderID { get; set; }
    [ForeignKeyAttribute("OrderID")]
    public Order Order { get; set; }
  }
}