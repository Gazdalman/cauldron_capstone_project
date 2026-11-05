using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models;
public class RecipeIngredient
  {
  public int Id {get; set; }
  public int RecipeId {get; set; }
  public Recipe? Recipe { get; set; }

  [Required(ErrorMessage = "Ingredient name is required")]
  public string Ingredient {get; set; } = string.Empty;

  [Required(ErrorMessage = "Quantity/Measurement is required")]
  public string Quantity { get; set; } = string.Empty;
}
