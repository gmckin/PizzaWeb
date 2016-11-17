using System.ComponentModel.DataAnnotations;

namespace PizzaStoreMvc.Client.DomainModels
{
  public class State
  {
    [Key]
    public int StateID { get; set; }

    [Required]
    [StringLength(160, MinimumLength = 3)]
    [Display(Name = "State")]
    public string Name { get; set; }
  }
}