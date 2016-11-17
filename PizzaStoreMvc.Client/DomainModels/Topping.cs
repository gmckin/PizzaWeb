using PizzaStoreMvc.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Topping : AIngredient
  {
    [Key]
    public int ToppingID { get; set; }

    //[Required]
    //[StringLength(20)]
    //[Display(Name = "Topping Name")]
    //public string Name { get; set; }

  }
}