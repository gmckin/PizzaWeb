using Newtonsoft.Json;
using PizzaStoreMvc.Business;
using PizzaStoreMvc.Business.Repositories;
using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class PizzaOrderOption
  {
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api";

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
    public List<Topping> Topping { get; set; }

   

    public PizzaOrderOption()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      //Sauce = GetSauceOptions();
     // Crust = GetCrustOptions();
      //Cheese = GetCheeseOptions();
      //Size = GetSizeOptions();
      //Topping = GetToppingOptions();
    }

    private async Task<List<Sauce>> GetSauceOptions()
    {
      List<Sauce> sauces = null;
      HttpResponseMessage response = client.GetAsync(url +"/sauce").Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var s = JsonConvert.DeserializeObject<List<Sauce>>(data);
        sauces = s;
      }
      return sauces;
    }

    private async Task<List<SelectListItem>> GetSizeOptions()
    {

      var sizeOptions = new List<SelectListItem>();
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/size");
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var size = JsonConvert.DeserializeObject<List<Size>>(responseData);

        foreach (var item in size)
        {
          sizeOptions.Add(new SelectListItem() { Text = item.Name, Value = item.SizeID.ToString() });
        };
        return sizeOptions;
      }
      return sizeOptions;
    }

    private async Task<List<SelectListItem>> GetCrustOptions()
    {

      var crustOptions = new List<SelectListItem>();
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/crust");
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var crust = JsonConvert.DeserializeObject<List<Crust>>(responseData);

        foreach (var item in crust)
        {
          crustOptions.Add(new SelectListItem() { Text = item.Name, Value = item.CrustID.ToString() });
        };
        return crustOptions;
      }
      return crustOptions;

    }

    private async Task<List<SelectListItem>> GetToppingOptions()
    {
      var toppings = ToppingRepo.GetToppings();
      var toppingOptions = new List<SelectListItem>();
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/topping");
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var topping = JsonConvert.DeserializeObject<List<Topping>>(responseData);

        foreach (var item in topping)
        {
          toppingOptions.Add(new SelectListItem() { Text = item.Name, Value = item.ToppingID.ToString() });
        };
        return toppingOptions;
      }
      return toppingOptions;
    }

    private async Task<List<SelectListItem>> GetCheeseOptions()
    {
      
      var cheeseOptions = new List<SelectListItem>();
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/cheese");
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var cheese = JsonConvert.DeserializeObject<List<Cheese>>(responseData);

        foreach (var item in cheese)
        {
          cheeseOptions.Add(new SelectListItem() { Text = item.Name, Value = item.CheeseID.ToString() });
        };
        return cheeseOptions;
      }
      return cheeseOptions;

    }
  }
}
