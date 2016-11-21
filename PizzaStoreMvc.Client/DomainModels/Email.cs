using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Email
  {
    [Key]
    public int EmailID { get; set; }
    [Required]   
    public string EmailAddress { get; set; }
  }
}