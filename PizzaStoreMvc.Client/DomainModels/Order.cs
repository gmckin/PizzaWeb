using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Order
  {
    [Key]
    public int OrderID { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Purchase Date")]
    public DateTime Date { get; set; }           

    [DataType(DataType.Currency)]
    [Required, Display(Name = "Price")]
    [Range(0.0, Double.MaxValue, ErrorMessage = "Price cannot be zero.")]
    public decimal TotalPrice { get; set; }

    public int CustomerID { get; set; }
    [ForeignKey("CustomerID")]
    public Customer Customer { get; set; }

    public int StoreID { get; set; }
    [ForeignKey("StoreID")]
    public Store Store { get; set; }

    public virtual ICollection<Pizza> Pizzas { get; set; }
  }
}