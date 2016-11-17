using PizzaStoreMvc.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Sauce :AIngredient
  {
    [Key]
    public int SauceID { get; set; }

    //[Required]
    //[StringLength(20)]
    //[Display(Name = "Type of Sauce")]
    //public string Name { get; set; }   
  }
}