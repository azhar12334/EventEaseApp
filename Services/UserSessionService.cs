namespace EventEase.Services;

/// <summary>
/// Holds lightweight user-session state (who is signed in) for the
/// lifetime of the app. Satisfies the "state management for user
/// sessions" requirement. Raises OnChange so components can re-render.
/// </summary>
public class UserSessionService
{
    public string? UserName { get; private set; }

    public bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserName);

    public event Action? OnChange;

    public void SignIn(string userName)
    {
        UserName = userName;
        NotifyStateChanged();
    }

    public void SignOut()
    {
        UserName = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
