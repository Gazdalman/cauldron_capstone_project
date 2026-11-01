using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models;

public class Ingredient
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; } = string.Empty;

  public List<RecipeIngredient> RecipeIngredients { get; set; } = new();
}
