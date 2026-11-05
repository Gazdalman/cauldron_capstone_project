using System.ComponentModel.DataAnnotations;
namespace Cauldron.Models;

public class PantryIngredient
{
  public int Id {get; set; }
  public int PantryId {get; set; }
  public Pantry? Pantry {get; set; }

  [Required(ErrorMessage = "Ingredient name is required")]
  public string Ingredient {get; set; } = string.Empty;

  [Required(ErrorMessage = "Quantity/Measurement is required")]
  public string Quantity { get; set; } = string.Empty;
}
