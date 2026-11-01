using System.ComponentModel.DataAnnotations;
namespace Cauldron.Models;

public class PantryIngredient
{
  public int PantryId {get; set; }
  public Pantry? Pantry {get; set; }

  public int IngredientId { get; set; }
  public Ingredient? Ingredient { get; set; }

  [Required(ErrorMessage = "Quantity/Measurement is required")]
  public string Quantity { get; set; } = string.Empty;
}
