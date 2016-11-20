using PizzaStoreMvc.Business;
using PizzaStoreMvc.Business.Repositories;
using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class PizzaOrderOption
  {
    [Required]
    [Display(Name = "Sauce Options")]
    public List<SelectListItem> Sauce { get; set; }

    [Required]
    [Display(Name = "Crust Options")]
    public List<SelectListItem> Crust { get; set; }

    [Required]
    [Display(Name = "Cheese Options")]
    public List<SelectListItem> Cheese { get; set; }

    [Required]
    [Display(Name = "Size Options")]
    public List<SelectListItem> Size { get; set; }

    [Required]
    [Display(Name = "Topping Options")]
    public List<SelectListItem> Topping { get; set; }

   

    public PizzaOrderOption()
    {
      Sauce = GetSauceOptions();
      Crust = GetCrustOptions();
      Cheese = GetCheeseOptions();
      Size = GetSizeOptions();
      Topping = GetToppingOptions();
    }

    private List<SelectListItem> GetSauceOptions()
    {
      var sauces = SauceRepo.GetSauces();
      var sauceOptions = new List<SelectListItem>();

      foreach (var sauce in sauces)
      {
        //sauceOptions.Add(new SelectListItem() { Text = sauce.Name, Value = sauce.SauceID.ToString() });
      };
      return sauceOptions;

    }

    private List<SelectListItem> GetSizeOptions()
    {
      var sizes = SizeRepo.GetSizes();
      var sizeOptions = new List<SelectListItem>();

      foreach (var size in sizes)
      {
        //sizeOptions.Add(new SelectListItem() { Text = size.Name, Value = size.SizeID.ToString() });
      };
      return sizeOptions;
    }

    private List<SelectListItem> GetCrustOptions()
    {
      var crusts = CrustRepo.GetCrusts();
      var crustOptions = new List<SelectListItem>();

      foreach (var crust in crusts)
      {
       // crustOptions.Add(new SelectListItem() { Text = crust.Name, Value = crust.CrustID.ToString() });
      };
      return crustOptions;

    }

    private List<SelectListItem> GetToppingOptions()
    {
      var toppings = ToppingRepo.GetToppings();
      var toppingOptions = new List<SelectListItem>();

      foreach (var topping in toppings)
      {
       // toppingOptions.Add(new SelectListItem() { Text = topping.Name, Value = topping.ToppingID.ToString() });
      };
      return toppingOptions;
    }

    private List<SelectListItem> GetCheeseOptions()
    {
      var cheeses = CheeseRepo.GetCheeses();
      var cheeseOptions = new List<SelectListItem>();

      foreach (var cheese in cheeses)
      {
       // cheeseOptions.Add(new SelectListItem() { Text = cheese.Name, Value = cheese.CheeseID.ToString() });
      };
      return cheeseOptions;

    }
  }
}
