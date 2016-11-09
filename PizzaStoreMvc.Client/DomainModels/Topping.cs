using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Topping
  {
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(20)]
    [Display(Name = "Topping Name")]
    public string Name { get; set; }

    [DataType(DataType.Currency)]
    [Required, Display(Name = "Price")]
    [Range(0.0, Double.MaxValue, ErrorMessage = "Price cannot be zero.")]
    public decimal Value { get; set; }
  }
}