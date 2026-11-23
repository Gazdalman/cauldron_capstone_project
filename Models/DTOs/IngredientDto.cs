using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models.DTOs;

public class IngredientDto
{
    public string Ingredient { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
}