using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.ViewModels
{
  public class PizzaOrderDetail
  {
    public class Name
    {

      [JsonProperty("NameID")]
      public int NameID { get; set; }

      [JsonProperty("First")]
      public string First { get; set; }

      [JsonProperty("Last")]
      public string Last { get; set; }
    }

    public class Phone
    {

      [JsonProperty("PhoneID")]
      public int PhoneID { get; set; }

      [JsonProperty("Number")]
      public string Number { get; set; }
    }

    public class Address
    {

      [JsonProperty("AddressID")]
      public int AddressID { get; set; }

      [JsonProperty("StreetAddress")]
      public string StreetAddress { get; set; }
    }

    public class City
    {

      [JsonProperty("CityID")]
      public int CityID { get; set; }

      [JsonProperty("Name")]
      public string Name { get; set; }
    }

    public class State
    {

      [JsonProperty("StateID")]
      public int StateID { get; set; }

      [JsonProperty("Name")]
      public string Name { get; set; }
    }

    public class Zip
    {

      [JsonProperty("ZipID")]
      public int ZipID { get; set; }

      [JsonProperty("Name")]
      public string Name { get; set; }
    }

    public class Email
    {

      [JsonProperty("EmailID")]
      public int EmailID { get; set; }

      [JsonProperty("EmailAddress")]
      public string EmailAddress { get; set; }
    }

    public class Customer
    {

      [JsonProperty("CustomerID")]
      public int CustomerID { get; set; }

      [JsonProperty("NameID")]
      public int NameID { get; set; }

      [JsonProperty("Name")]
      public Name Name { get; set; }

      [JsonProperty("PhoneID")]
      public int PhoneID { get; set; }

      [JsonProperty("Phone")]
      public Phone Phone { get; set; }

      [JsonProperty("AddressID")]
      public int AddressID { get; set; }

      [JsonProperty("Address")]
      public Address Address { get; set; }

      [JsonProperty("CityID")]
      public int CityID { get; set; }

      [JsonProperty("City")]
      public City City { get; set; }

      [JsonProperty("StateID")]
      public int StateID { get; set; }

      [JsonProperty("State")]
      public State State { get; set; }

      [JsonProperty("ZipID")]
      public int ZipID { get; set; }

      [JsonProperty("Zip")]
      public Zip Zip { get; set; }

      [JsonProperty("EmailID")]
      public int EmailID { get; set; }

      [JsonProperty("Email")]
      public Email Email { get; set; }
    }

    public class Store
    {

      [JsonProperty("StoreID")]
      public int StoreID { get; set; }

      [JsonProperty("Phone")]
      public string Phone { get; set; }

      [JsonProperty("Address")]
      public string Address { get; set; }

      [JsonProperty("City")]
      public string City { get; set; }

      [JsonProperty("State")]
      public string State { get; set; }

      [JsonProperty("Email")]
      public string Email { get; set; }

      [JsonProperty("Zip")]
      public string Zip { get; set; }
    }

    public class Order
    {

      [JsonProperty("OrderID")]
      public int OrderID { get; set; }

      [JsonProperty("Date")]
      public DateTime Date { get; set; }

      [JsonProperty("TotalPrice")]
      public double TotalPrice { get; set; }

      [JsonProperty("CustomerID")]
      public int CustomerID { get; set; }

      [JsonProperty("Customer")]
      public Customer Customer { get; set; }

      [JsonProperty("StoreID")]
      public int StoreID { get; set; }

      [JsonProperty("Store")]
      public Store Store { get; set; }
    }



  }
}