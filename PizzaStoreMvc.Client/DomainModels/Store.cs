using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Store
  {
    [Key]
    public int ID { get; set; }

    [Required]
    [Display(Name = "Store Number")]
    public string LocationID { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [RegularExpression(@"^(\d{4})$", ErrorMessage = "Zip Code Must be Five Numbers Long and Cannot be 00000")]
    public string Zip { get; set; }
    public string phone { get; set; }   
  }
}