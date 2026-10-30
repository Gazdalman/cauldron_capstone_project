namespace Cauldron.Models.ResultPatterns;

public class PasswordChangeResult
{
  public bool Succeeded {get; set;}
  public string ErrorMsg { get; set; } = string.Empty;
}

