namespace BhavanPortfolio.Services;

/// <summary>
/// Service interface for managing theme state (dark/light mode).
/// Theme resolution priority: localStorage > system preference > dark default.
/// </summary>
public interface IThemeService
{
    /// <summary>
    /// Current theme value: "dark" or "light".
    /// </summary>
    string CurrentTheme { get; }

    /// <summary>
    /// Event fired when theme changes. Components should subscribe to update their state.
    /// </summary>
    event Action? OnThemeChanged;

    /// <summary>
    /// Initializes the service by syncing with the theme applied by index.html inline script.
    /// Should be called once during application startup.
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// Toggles between dark and light themes, persists to localStorage.
    /// Full implementation in Story 2.2.
    /// </summary>
    Task ToggleThemeAsync();
}
