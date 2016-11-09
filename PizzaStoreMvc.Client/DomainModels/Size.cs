using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Size
  {
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    
  }
}