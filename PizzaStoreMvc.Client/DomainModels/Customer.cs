using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Customer
  {
    //[Key]
    public int CustomerId { get; set; }

    public int NameID { get; set; }
    [ForeignKey("NameID")]
    public Name Name { get; set; }
    public int PhoneID { get; set; }
    [ForeignKey("PhoneID")]
    public Phone Phone { get; set; }
    public int AddressID { get; set; }
    [ForeignKey("AddressID")]
    public Address Address { get; set; }
    public int CityID { get; set; }
    [ForeignKey("CityID")]
    public City City { get; set; }
    public int StateID { get; set; }
    [ForeignKey("StateID")]
    public State State { get; set; }
    public int ZipID { get; set; }
    [ForeignKey("ZipID")]
    public Zip Zip { get; set; }

    public int EmailID { get; set; }
    [ForeignKey("EmailID")]
    public Email Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
  }
}