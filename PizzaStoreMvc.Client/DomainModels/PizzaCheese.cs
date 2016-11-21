using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class PizzaCheese
  {
    [Key]
    public int PizzaCheeseID { get; set; }

    public int PizzaID { get; set; }
    [ForeignKey("PizzaID")]
    public Pizza Pizza { get; set; }

    public int ID { get; set; }
    [ForeignKey("ID")]
    public Cheese Cheese { get; set; }
    
  }
}