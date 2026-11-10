using Cauldron.Data;
using Cauldron.Models;
using Cauldron.Models.DTOs;
using Cauldron.Models.ResultPatterns;
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
      .Include(ri => ri.Ingredients).ToListAsync();
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

  public async Task<int> CreateRecipeAsync(RecipeCreationDto dto)
  {
    Recipe recipe = new()
    {
      Title = dto.Title,
      Description = dto.Description ?? string.Empty,
      Instructions = dto.Instructions
    };

    _context.Recipes.Add(recipe);
    await _context.SaveChangesAsync();

    return recipe.Id;
  }
}
