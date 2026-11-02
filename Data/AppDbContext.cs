using Microsoft.EntityFrameworkCore;
using Cauldron.Models;

namespace Cauldron.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Pantry> Pantries => Set<Pantry>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Recipes)
        .WithOne(r => r.User)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<RecipeIngredient>()
        .HasKey(ri => new { ri.RecipeId, ri.IngredientId});

      modelBuilder.Entity<RecipeIngredient>()
        .HasOne(ri => ri.Recipe)
        .WithMany(r => r.Ingredients)
        .HasForeignKey(ri => ri.RecipeId);

      modelBuilder.Entity<RecipeIngredient>()
        .HasOne(ri => ri.Ingredient)
        .WithMany(i => i.RecipeIngredients)
        .HasForeignKey(ri => ri.IngredientId);

      modelBuilder.Entity<PantryIngredient>()
        .HasKey(pi => new {pi.PantryId, pi.IngredientId});

      modelBuilder.Entity<PantryIngredient>()
        .HasOne(pi => pi.Pantry)
        .WithMany(p => p.PantryIngredients)
        .HasForeignKey(pi => pi.PantryId);

        modelBuilder.Entity<Ingredient>()
          .HasIndex(i => i.NormalizedName)
          .IsUnique();

        modelBuilder.Entity<Ingredient>().HasData(
          // --- Pantry & Baking Staples ---
          new Ingredient { Id = 1, Name = "All-Purpose Flour", NormalizedName = "allpurposeflour" },
          new Ingredient { Id = 2, Name = "Granulated Sugar", NormalizedName = "granulatedsugar" },
          new Ingredient { Id = 3, Name = "Kosher Salt", NormalizedName = "koshersalt" },
          new Ingredient { Id = 4, Name = "Black Pepper", NormalizedName = "blackpepper" },
          new Ingredient { Id = 5, Name = "Olive Oil", NormalizedName = "oliveoil" },
          new Ingredient { Id = 6, Name = "Baking Powder", NormalizedName = "bakingpowder" },
          new Ingredient { Id = 7, Name = "Vanilla Extract", NormalizedName = "vanillaextract" },
          new Ingredient { Id = 8, Name = "Chocolate Chips", NormalizedName = "chocolatechips" },
          new Ingredient { Id = 9, Name = "Maple Syrup", NormalizedName = "maplesyrup" },
          new Ingredient { Id = 10, Name = "Balsamic Vinegar", NormalizedName = "balsamicvinegar" },

          // --- Dairy & Refrigerated ---
          new Ingredient { Id = 11, Name = "Large Eggs", NormalizedName = "largeeggs" },
          new Ingredient { Id = 12, Name = "Whole Milk", NormalizedName = "wholemilk" },
          new Ingredient { Id = 13, Name = "Unsalted Butter", NormalizedName = "unsaltedbutter" },
          new Ingredient { Id = 14, Name = "Cheddar Cheese", NormalizedName = "cheddarcheese" },
          new Ingredient { Id = 15, Name = "Parmesan Cheese", NormalizedName = "parmesancheese" },
          new Ingredient { Id = 16, Name = "Heavy Cream", NormalizedName = "heavycream" },

          // --- Proteins ---
          new Ingredient { Id = 17, Name = "Bacon", NormalizedName = "bacon" },
          new Ingredient { Id = 18, Name = "Pork Sausage", NormalizedName = "porksausage" },
          new Ingredient { Id = 19, Name = "Deli Turkey", NormalizedName = "deliturkey" },
          new Ingredient { Id = 20, Name = "Chicken Breast", NormalizedName = "chickenbreast" },
          new Ingredient { Id = 21, Name = "Boneless Chicken Thighs", NormalizedName = "bonelesschickenthighs"},
          new Ingredient { Id = 22, Name = "Bone-In Chicken Thighs", NormalizedName = "boneinchickenthighs"},

          // --- Produce & Breads ---
          new Ingredient { Id = 23, Name = "Russet Potatoes", NormalizedName = "russetpotatoes" },
          new Ingredient { Id = 24, Name = "Garlic", NormalizedName = "garlic" },
          new Ingredient { Id = 25, Name = "Yellow Onion", NormalizedName = "yellowonion" },
          new Ingredient { Id = 26, Name = "Romaine Lettuce", NormalizedName = "romainelettuce" },
          new Ingredient { Id = 27, Name = "Tomatoes", NormalizedName = "tomatoes" },
          new Ingredient { Id = 28, Name = "Asparagus", NormalizedName = "asparagus" },
          new Ingredient { Id = 29, Name = "Lemons", NormalizedName = "lemons" },
          new Ingredient { Id = 30, Name = "Sourdough Bread", NormalizedName = "sourdoughbread" },
          new Ingredient { Id = 31, Name = "Croutons", NormalizedName = "croutons" },

          // --- Beverages ---
          new Ingredient { Id = 32, Name = "Coffee Beans", NormalizedName = "coffeebeans" }
);
    }

  }
}
