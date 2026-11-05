using Microsoft.EntityFrameworkCore;
using Cauldron.Models;

namespace Cauldron.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Pantry> Pantries => Set<Pantry>();
    public DbSet<PantryIngredient> PantryIngredients => Set<PantryIngredient>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>()
        .HasMany(u => u.Recipes)
        .WithOne(r => r.User)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<User>()
        .HasOne(u => u.Pantry)
        .WithOne(p => p.User)
        .HasForeignKey<Pantry>(p => p.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<RecipeIngredient>()
        .HasOne(ri => ri.Recipe)
        .WithMany(r => r.Ingredients)
        .HasForeignKey(ri => ri.RecipeId);

      modelBuilder.Entity<PantryIngredient>()
        .HasOne(pi => pi.Pantry)
        .WithMany(p => p.PantryIngredients)
        .HasForeignKey(pi => pi.PantryId);

    }
  }
}
