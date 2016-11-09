using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Customer
  {
    //[Key]
    public int CustomerId { get; set; }

    //[Required]
    //[StringLength(160, MinimumLength = 3)]
    //[Display(Name = "Customer Name")]
    public Name Name { get; set; }
    public Address Address { get; set; }
    public string City { get; set;}
    public string State { get; set; }

    //[Required(ErrorMessage = "Zip is a Required field.")]
    //[DataType(DataType.Text)]
    //[RegularExpression("\\d{5}", ErrorMessage = "Zip Code Must be Five Numbers Long and Cannot be 00000")]
    //public string Zip { get; set; }

    //[Required(ErrorMessage = "Phone is a Required field.")]
    //[DataType(DataType.PhoneNumber)]
    //[RegularExpression("^[01]?[- .]?\\(?[2-9]\\d{2}\\)?[- .]?\\d{3}[- .]?\\d{4}$",
    //    ErrorMessage = "Phone is required and must be properly formatted.")]
    //[Display(Order = 9, Name = "Phone")]
    public Phone Phone { get; set; }

    //[EmailAddress(ErrorMessage = "You must enter a valid Email address")]
    public Email Email { get; set; }
    public List<Order> Order { get; set; }
  }
}