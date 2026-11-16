using Cauldron.Data;
using Cauldron.Models;
using Cauldron.Models.DTOs;
using Cauldron.Models.ResultPatterns;
using Cauldron.State;
using Microsoft.EntityFrameworkCore;
namespace Cauldron.Services;

public class RecipeService
{
  private readonly AppDbContext _context;
  private readonly UserSessionState _userSessionState;

  public RecipeService(AppDbContext context, UserSessionState userSessionState)
  {
    _context = context;
    _userSessionState = userSessionState;
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
          .FirstAsync(r => r.Id == id);
    return recipe;
  }

  public async Task<int> CreateRecipeAsync(RecipeCreationDto dto)
  {
    int userId = _userSessionState.CurrentUserId
      ?? throw new InvalidOperationException("A signed-in user is required to create a recipe.");

    Recipe recipe = new()
    {
      Title = dto.Title,
      Description = dto.Description ?? string.Empty,
      Instructions = dto.Instructions,
      UserId = userId
    };

    _context.Recipes.Add(recipe);
    await _context.SaveChangesAsync();

    return recipe.Id;
  }

  public async Task<int> CreateIngredientAsync(IngredientDto dto, int recipeId)
  {
    RecipeIngredient ingredient = new()
    {
      Ingredient = dto.Ingredient,
      Quantity = dto.Quantity,
      RecipeId = recipeId
    };

    _context.RecipeIngredients.Add(ingredient);
    await _context.SaveChangesAsync();

    return ingredient.Id;
  }
}
