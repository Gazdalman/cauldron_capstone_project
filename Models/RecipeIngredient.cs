using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models{
  public class RecipeIngredient
  {
    public int RecipeId {get; set; }
    public Recipe? Recipe { get; set; }

    public int IngredientId {get; set; }
    public Ingredient? Ingredient {get; set; }

    [Required(ErrorMessage = "Quantity/Measurement is required")]
    public string Quantity { get; set; } = string.Empty;
  }
}
