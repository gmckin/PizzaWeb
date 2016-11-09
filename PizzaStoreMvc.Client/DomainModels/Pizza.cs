using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Pizza
  {
    //[Key]
    public int PizzaId { get; set; }

    public Crust Crust { get; set; }
    public Sauce Sauce { get; set; }
    public Size Size { get; set; }
    public List<Cheese> Cheese { get; set; }
    public List<Topping> Topping { get; set; }
    //[Required]
    //[StringLength(20)]    
    //public string Name { get; set; }

    //[DataType(DataType.Currency)]
    //[Required, Display(Name = "Price")]
    //[Range(0.0, Double.MaxValue, ErrorMessage = "Price cannot be zero.")]
    //public decimal Value { get; set; }
  }
}