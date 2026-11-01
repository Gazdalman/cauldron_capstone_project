using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models;

public class Recipe
{
  public int Id { get; set; }
  [Required(ErrorMessage = "Recipe must have a title!")]
  [StringLength(100, MinimumLength = 10, ErrorMessage = "Title must be between 10 and 100 characters!")]
  public string Title { get; set; } = string.Empty;
  [Required(ErrorMessage = "Recipe must have a description!")]
  [StringLength(250, ErrorMessage = "Description must be under 250 characters!")]
  public string Description { get; set; } = string.Empty;
  [Required(ErrorMessage = "Recipe must have instructions")]
  public string Instructions { get; set; } = string.Empty;
  [Required]
  public string UserId { get; set; } = string.Empty;
  public User? User { get; set; }
  public List<RecipeIngredient> Ingredients { get; set; } = new();
}
