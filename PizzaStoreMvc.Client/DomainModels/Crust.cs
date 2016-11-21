using PizzaStoreMvc.Business.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Crust :AIngredient
  {
    [Key]
    public int CrustID { get; set; }

    //[Required]
    //[StringLength(20)]
    //[Display(Name = "Type of Crust")]
    //public string Name { get; set; }
  }
}