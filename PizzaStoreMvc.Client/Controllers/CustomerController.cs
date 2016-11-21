using Newtonsoft.Json;
using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PizzaStoreMvc.Client.Controllers
{
    public class CustomerController : Controller
    {
    HttpClient client;
    //The URL of the WEB API Service
    string url = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/customer";
    string addr = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/address";
    string cty = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/city";
    string sta = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/state";
    string zp = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/zip";
    string phn = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/phone";
    string eml = "http://ec2-54-208-26-255.compute-1.amazonaws.com/pizzastoreapi/api/email";

    //The HttpClient Class, this will be used for performing 
    //HTTP Operations, GET, POST, PUT, DELETE
    //Set the base address and the Header Formatter
    public CustomerController()
    {
      client = new HttpClient();
      client.BaseAddress = new Uri(url);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // GET: EmployeeInfo
    public async Task<ActionResult> Index()
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var Customer = JsonConvert.DeserializeObject<List<Customer>>(responseData);
        ViewBag.AddressID = new SelectList(await GetAddress(), "AddressID", "StreetAddress");
        ViewBag.CityID = new SelectList(await GetCity(), "CityID", "CityName");
        ViewBag.StateID = new SelectList(await GetState(), "StateID", "StateName");
        ViewBag.ZipID = new SelectList(await GetZip(), "ZipID", "ZipCode");
        ViewBag.EmailID = new SelectList(await GetEmail(), "EmailID", "EmailAddress");
        ViewBag.PhoneID = new SelectList(await GetPhone(), "PhoneID", "Number");

        return View(Customer);
      }
      return View("Error");
    }

    public ActionResult Create()
    {
      return View(new Customer());
    }

    //The Post method
    [HttpPost]
    public async Task<ActionResult> Create(Customer customer)
    {

      HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, customer);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    public async Task<ActionResult> Edit(int id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var Cust = JsonConvert.DeserializeObject<Customer>(responseData);

        return View(Cust);
      }
      return View("Error");
    }

    //The PUT Method
    [HttpPost]
    public async Task<ActionResult> Edit(int id, Customer customer)
    {

      HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, customer);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    public async Task<ActionResult> Delete(int id)
    {
      HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        var Cust = JsonConvert.DeserializeObject<Customer>(responseData);

        return View(Cust);
      }
      return View("Error");
    }

    //The DELETE method
    [HttpPost]
    public async Task<ActionResult> Delete(int id, Customer customer)
    {

      HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
      if (responseMessage.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Error");
    }

    public async Task<List<Address>> GetAddress()
    {
      List<Address> address = null;
      HttpResponseMessage response = client.GetAsync(addr).Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<List<Address>>(data);
        address = a;
      }
      return address;
    }

    public async Task<List<City>> GetCity()
    {
      List<City> city = null;
      HttpResponseMessage response = client.GetAsync(cty).Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<List<City>>(data);
        city = a;
      }
      return city;
    }

    public async Task<List<State>> GetState()
    {
      List<State> state = null;
      HttpResponseMessage response = client.GetAsync(cty).Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<List<State>>(data);
        state = a;
      }
      return state;
    }

    public async Task<List<Zip>> GetZip()
    {
      List<Zip> zip = null;
      HttpResponseMessage response = client.GetAsync(zp).Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<List<Zip>>(data);
        zip = a;
      }
      return zip;
    }

    public async Task<List<Phone>> GetPhone()
    {
      List<Phone> phone = null;
      HttpResponseMessage response = client.GetAsync(phn).Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<List<Phone>>(data);
        phone = a;
      }
      return phone;
    }
    public async Task<List<Email>> GetEmail()
    {
      List<Email> email = null;
      HttpResponseMessage response = client.GetAsync(eml).Result;
      if (response.IsSuccessStatusCode)
      {
        var data = await response.Content.ReadAsStringAsync();
        var a = JsonConvert.DeserializeObject<List<Email>>(data);
        email = a;
      }
      return email;
    }
  }
}
