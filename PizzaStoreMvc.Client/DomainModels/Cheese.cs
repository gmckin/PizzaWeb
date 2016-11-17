using PizzaStoreMvc.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Cheese : AIngredient
  {
    [Key]
    public int ID { get; set; }

    //[Required]
    //[StringLength(20)]
    //[Display(Name = "Type of Cheese")]
    //public string Name { get; set; }

  }
}