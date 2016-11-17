using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Phone
  {
    [Key]
    public int PhoneID { get; set; }

    [Required(ErrorMessage = "Please provide a phone number in the proper format")]
    [DataType(DataType.PhoneNumber)]
    [Display(Name ="Phone Number")]
    public string Number { get; set; }
  }
}