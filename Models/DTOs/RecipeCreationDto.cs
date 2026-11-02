using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models.DTOs;

public class RecipeCreationDto
{
  [Required(ErrorMessage = "Recipe must have a title.")]
  [StringLength(50, MinimumLength = 4, ErrorMessage = "Recipe title must be between 4 and 50 characters")]
  public string Title { get; set; }

  public string? Description;

  [Required(ErrorMessage = "Recipe must have instructions")]
  public string Instructions;
}
