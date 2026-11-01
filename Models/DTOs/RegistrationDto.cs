using System.ComponentModel.DataAnnotations;

namespace Cauldron.Models.DTOs;

public class RegistrationDto
{
  [Required(ErrorMessage = "Username is required")]
  [MinLength(5, ErrorMessage = "Username must be between 5 and 50 characters")]
  [MaxLength(50, ErrorMessage = "Username must be between 5 and 50 characters")]
  public string UserName { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required")]
  [MinLength(5, ErrorMessage = "Password must be at least 10 characters")]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = "Email is required.")]
  [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
  public string Email { get; set; } = string.Empty;
}
