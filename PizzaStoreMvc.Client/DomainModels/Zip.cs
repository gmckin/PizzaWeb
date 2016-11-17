using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class Zip
  {
    [Key]
    public int AddressID { get; set; }

    [Required]
    [StringLength(160, MinimumLength = 3)]
    [Display(Name = "Zip Code")]
    public string Name { get; set; }
  }
}