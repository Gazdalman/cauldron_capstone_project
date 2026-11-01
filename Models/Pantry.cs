using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models;
public class Pantry
{
  [Required(ErrorMessage = "Please enter a quantity")]
  public string Quantity { get; set; } = string.Empty;

  public int UserId { get; set; }
  public User? User { get; set; }

  public int IngredientId { get; set; }
  public Ingredient? Ingredient { get; set; }

  public string PantryString()
  {
    return $"{Quantity} {(Ingredient != null  ? Ingredient.Name : null)}";
  }

}
