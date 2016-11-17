using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Address
  {
    [Key]
    public int AddressID { get; set; }

    [Required]
    [StringLength(160, MinimumLength = 3)]    
    public string StreetAddress { get; set; }

  }
}