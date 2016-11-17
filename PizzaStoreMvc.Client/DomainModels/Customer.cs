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

    //[Required]
    //[StringLength(160, MinimumLength = 3)]
    //[Display(Name = "Customer Name")]
    //public Name Name { get; set; }

    //public Address Address { get; set; }

    //public City City { get; set; }

    //public State State { get; set; }

    //[Required(ErrorMessage = "Zip is a Required field.")]
    //[DataType(DataType.Text)]
    //[RegularExpression("\\d{5}", ErrorMessage = "Zip Code Must be Five Numbers Long and Cannot be 00000")]
    //public Zip Zip { get; set; }

    //[Required(ErrorMessage = "Phone Number is a Required field.")]
    //[DataType(DataType.PhoneNumber)]
    //[RegularExpression("^[01]?[- .]?\\(?[2-9]\\d{2}\\)?[- .]?\\d{3}[- .]?\\d{4}$",
    //    ErrorMessage = "Phone Number is required and must be properly formatted.")]
    //[Display(Order = 9, Name = "Phone Number")]
    //public Phone Phone { get; set; }

    //[EmailAddress(ErrorMessage = "You must enter a valid Email address")]
    //public Email Email { get; set; }
    ////public List<Order> Order { get; set; }
   

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
  }
}