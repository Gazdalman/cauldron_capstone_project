using Cauldron.Data;
using Cauldron.Models;
using Cauldron.Models.DTOs;
using Cauldron.Models.ResultPatterns;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cauldron.Services;

public class UserService
{
  private readonly AppDbContext _context;
  private readonly IPasswordHasher<User> _passwordHasher;

  public UserService(AppDbContext context, IPasswordHasher<User> passwordHasher)
  {
    _context = context;
    _passwordHasher = passwordHasher;
  }

  public async Task<User> GetUserByIdAsync(int userId)
  {
    return await _context.Users.FindAsync(userId);
  }

  public async Task<LogInResult?> LogInUserAsync(string credential, string password)
  {
    var normalized = credential.ToUpper();
    var user = await _context.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == normalized || u.NormalizedEmail == normalized);

    if (user == null || string.IsNullOrEmpty(user.PasswordHash))
    {
      return null;
    }

    var verification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

    if (verification != PasswordVerificationResult.Success)
    {
      return null;
    }

    var result = new LogInResult
    {
      UserId = user.Id,
      UserName = user.UserName
    };

    return result;
  }

    ///<summary>
    /// Adds a user to the database.
    /// </summary>
    /// <param name="email">String that represents the user's email.</param>
    /// <returns>
    /// The newly created User stored inside a RegistrationResult object.
    /// </returns>
  public async Task<RegistrationResult> RegisterUserAsync(RegistrationDto dto)
  {
    var result = new RegistrationResult();

    if (await _context.Users.AnyAsync(u => u.NormalizedUserName == dto.UserName.ToUpper()))
    {
      result.AddError("UserName", "Username is already taken.");
    }

    if (await _context.Users.AnyAsync(u => u.NormalizedEmail == dto.Email.ToUpper()))
    {
      result.AddError("Email", "An account with this email already exists.");
    }

    if (!result.Succeeded)
    {
      return result;
    }

    var user = new User
    {
      UserName = dto.UserName,
      Email = dto.Email,
      DisplayName = dto.UserName,
      NormalizedEmail = dto.Email.ToUpper(),
      NormalizedUserName = dto.UserName.ToUpper()
    };

    user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

    _context.Users.Add(user);

    await _context.SaveChangesAsync();

    return result;
  }

  public async Task<PasswordChangeResult> ChangePasswordAsync(int id, string currPass, string newPass)
  {
    var user = await _context.Users.FindAsync(id);
    if (user == null)
    {
      return new PasswordChangeResult { Succeeded = false, ErrorMsg = "No user found"};
    }

    var verified = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currPass);
    if (verified != PasswordVerificationResult.Success)
    {
      return new PasswordChangeResult { Succeeded = false, ErrorMsg = "Wrong password entered."};
    }

    verified = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, newPass);
    if (verified == PasswordVerificationResult.Success)
    {
      return new PasswordChangeResult { Succeeded = false, ErrorMsg = "New password cannot be the same as your current password."};
    }

    user.PasswordHash = _passwordHasher.HashPassword(user, newPass);
    await _context.SaveChangesAsync();

    return new PasswordChangeResult { Succeeded = true };
  }

  public async Task<bool> DeleteUserAsync(int id)
  {
    var user = await _context.Users.FindAsync(id);
    if (user == null)
    {
      return false;
    }

    _context.Users.Remove(user);

    await _context.SaveChangesAsync();
    return true;
  }


}
