using PizzaStoreMvc.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreMvc.Business.Abstracts
{
  public abstract class AIngredient
  {
    //[Key]
    //public int ID { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public AIngredient () : base()
    {
      
    }


  }
}
