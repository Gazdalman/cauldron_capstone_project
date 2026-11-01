using Cauldron.Data;
using Cauldron.Models;
using Microsoft.EntityFrameworkCore;
namespace Cauldron.Services;

public class RecipeService
{
  private readonly AppDbContext _context;

  public RecipeService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<Recipe>> GetAllRecipesAsync()
  {
    var recipes = await _context.Recipes
    .Include(r => r.Ingredients)          // Pulls the RecipeIngredients join table
      .ThenInclude(ri => ri.Ingredient).ToListAsync();
    return recipes;
  }

  public async Task<Recipe> GetRecipeByIdAsync(int id)
  {
    var recipe = await _context.Recipes
      .Include(r => r.User)
      .Include(r => r.Ingredients)
        .ThenInclude(ri => ri.Ingredient)
          .FirstAsync(r => r.Id == id);
    return recipe;
  }
}
