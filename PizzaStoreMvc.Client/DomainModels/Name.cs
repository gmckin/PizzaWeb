using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Name
  {
    [Key]
    public int NameID { get; set; }
    [Required(ErrorMessage = "You must enter a first name")]
    [Display(Name = "First Name")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 3)]
    [ValidName]
    public string First { get; set; }

    [Required(ErrorMessage ="You must enter a last name")]
    [Display(Name = "Last Name")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 3)]
    [ValidName]
    public string Last { get; set; }

    public override string ToString()
    {
      return string.Format("{0}{1}", First, Last);
    }
  }
}