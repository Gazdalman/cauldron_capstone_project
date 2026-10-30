namespace Cauldron.Models.ResultPatterns;

public class RegistrationResult
{
  public bool Succeeded => Errors.Count == 0;

  public Dictionary<string, string> Errors { get; set; } = new();

  public void AddError(string fieldName, string errorMsg)
  {
    Errors[fieldName] = errorMsg;
  }
}

public class RegistrationResult<T> : RegistrationResult
{
  public T? Data { get; set; }
}
