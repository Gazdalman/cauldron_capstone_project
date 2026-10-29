namespace Cauldron.Models.DTOs;

public class PasswordChangeResult
{
  public bool Succeeded {get; set;}
  public string ErrorMsg { get; set; } = string.Empty;
}
