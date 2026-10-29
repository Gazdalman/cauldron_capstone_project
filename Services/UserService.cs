using Cauldron.Data;
using Cauldron.Models;
using Microsoft.EntityFrameworkCore;

namespace Cauldron.Services;

public class UserService
{
  private readonly AppDbContext _context;

  public UserService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<User> GetUserByIdAsync(int userId)
  {
    return await _context.Users.FindAsync(userId);
  }

  public async Task<User> CreateUserAsync(string email, string displayName)
  {
    var user = new User
    {
      Email = email,
      DisplayName = displayName
    };

    _context.Users.Add(user);

    await _context.SaveChangesAsync();

    return user;
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
