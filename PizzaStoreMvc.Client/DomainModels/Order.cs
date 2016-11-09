using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Order
  {
    [Key]
    public int ID { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Entry Date")]
    public DateTime Date { get; set; }

    [Required]
    [Range(1, Double.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
    public int Quantity { get; set; }

    [DataType(DataType.Currency)]
    [Required, Display(Name = "Price")]
    [Range(0.0, Double.MaxValue, ErrorMessage = "Price cannot be zero.")]
    public decimal Value { get; set; }

  }
}