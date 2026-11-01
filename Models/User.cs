using Microsoft.AspNetCore.Identity;

namespace Cauldron.Models;

public class User : IdentityUser
{
<<<<<<< HEAD
=======
  public int Id {set; get; }
>>>>>>> dev
  public string DisplayName { get; set; } = string.Empty;
  public List<Recipe> Recipes { get; set; } = new();
}
