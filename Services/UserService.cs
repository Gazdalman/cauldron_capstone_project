using Cauldron.Data;
using Cauldron.Models;
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

    ///<summary>
    /// Adds a user to the database.
    /// </summary>
    /// <param name="email">String that represents the user's email.</param>
    /// <returns>
    /// The newly created User
    /// </returns>
  public async Task<User> RegisterUserAsync(string username, string email, string password, string? displayName)
  {

    var user = new User
    {
      UserName = username,
      Email = email,
      DisplayName = displayName ?? username,
      NormalizedEmail = email.ToUpper(),
      NormalizedUserName = username.ToUpper()
    };

    user.PasswordHash = _passwordHasher.HashPassword(user, password);

    _context.Users.Add(user);

    await _context.SaveChangesAsync();

    return user;
  }

  public async Task<bool> ChangePasswordAsync(int id, string currPass, string newPass)
  {
    var user = await _context.Users.FindAsync(id);
    if (user == null)
    {
      return false;
    }

    var verified = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currPass);
    if (verified != PasswordVerificationResult.Success)
    {
      return false;
    }

    user.PasswordHash = _passwordHasher.HashPassword(user, newPass);
    await _context.SaveChangesAsync();

    return true;
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
