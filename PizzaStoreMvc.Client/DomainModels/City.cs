using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class City
  {
    [Key]
    public int CityID { get; set; }

    [Required]
    [StringLength(160, MinimumLength = 3)]
    [Display(Name = "City")]
    public string Name { get; set; }   
  }
}