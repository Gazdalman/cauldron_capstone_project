using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models;
public class Pantry
{
  public int Id {get; set; }

  [Required(ErrorMessage = "Please enter a quantity")]
  public string Quantity { get; set; } = string.Empty;

  public int UserId { get; set; }
  public User? User { get; set; }
  public List<PantryIngredient> PantryIngredients { get; set; } = new();

}
