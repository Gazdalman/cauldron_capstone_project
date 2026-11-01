using Microsoft.AspNetCore.Identity;

namespace Cauldron.Models;

public class User : IdentityUser
{
  public string DisplayName { get; set; } = string.Empty;
  public List<Recipe> Recipes { get; set; } = new();
}
