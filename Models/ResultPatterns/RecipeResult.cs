namespace Cauldron.Models.ResultPatterns;

public class RecipeResult
{
  public bool Succeeded => Errors.Count == 0;

  public Dictionary<string, string> Errors { get; set; } = new();

  public void AddError(string fieldName, string errorMsg)
  {
    Errors[fieldName] = errorMsg;
  }
}

public class RecipeResult<T> : RecipeResult
{
  public T? Data { get; set; }
}
