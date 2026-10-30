namespace Cauldron.State;

public class UserSessionState
{
  public int? CurrentUserId { get; private set; }
  public string? CurrentUserName { get; private set; }
  public bool IsLoggedIn => CurrentUserId.HasValue;

  public event Action? OnChange;

  public void Login(int userId, string username)
  {
    CurrentUserId = userId;
    CurrentUserName = username;
    NotifyStateChanged();
  }

  public void Logout()
  {
    CurrentUserId = null;
    CurrentUserName = null;
    NotifyStateChanged();
  }

  private void NotifyStateChanged() => OnChange?.Invoke();
}
