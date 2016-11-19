using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Pizza
  {
    [Key]
    public int PizzaId { get; set; }

    public int SizeID { get; set; }
    [ForeignKey("SizeID")]
    public Size Size { get; set; }

    public int CrustID { get; set; }
    [ForeignKey("CrustID")]
    public Crust Crust { get; set; }

    public int SauceID { get; set; }
    [ForeignKey("SauceID")]
    public Sauce Sauce { get; set; }
    //public List<Cheese> Cheese { get; set; }
    //public List<Topping> Topping { get; set; }   

    public decimal Price { get; set; }

    public int OrderID { get; set; }
    [ForeignKey("OrderID")]
    public Order Order { get; set; }

    public virtual ICollection<PizzaCheese> PizzaCheeses { get; set; }
    public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
  }
}