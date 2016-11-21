using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class CustomerViewModel
  {
    public int CustomerId { get; set; }
    [Required]
    [StringLength(160, MinimumLength = 3)]
    [Display(Name = "Customer Name")]
    public virtual Name Name { get; set; }

    public virtual Address Address { get; set; }

    public virtual City City { get; set; }

    public virtual State State { get; set; }

    [Required(ErrorMessage = "Zip is a Required field.")]
    [DataType(DataType.Text)]
    [RegularExpression("\\d{5}", ErrorMessage = "Zip Code Must be Five Numbers Long and Cannot be 00000")]
    public virtual Zip Zip { get; set; }

    [Required(ErrorMessage = "Phone Number is a Required field.")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression("^[01]?[- .]?\\(?[2-9]\\d{2}\\)?[- .]?\\d{3}[- .]?\\d{4}$",
        ErrorMessage = "Phone Number is required and must be properly formatted.")]
    [Display(Order = 9, Name = "Phone Number")]
    public virtual Phone Phone { get; set; }

    [EmailAddress(ErrorMessage = "You must enter a valid Email address")]
    public virtual Email Email { get; set; }
    public List<Order> Order { get; set; }

  }
}