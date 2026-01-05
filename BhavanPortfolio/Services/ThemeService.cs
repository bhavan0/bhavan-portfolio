using Microsoft.JSInterop;

namespace BhavanPortfolio.Services;

/// <summary>
/// Theme service implementation that manages dark/light mode state.
/// Uses JS interop to read theme from document and sync with index.html applied theme.
/// </summary>
public class ThemeService : IThemeService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _themeModule;
    private string _currentTheme = "dark";
    private bool _isInitialized;

    public string CurrentTheme => _currentTheme;

    public event Action? OnThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Initializes the theme service by reading the current theme from the document.
    /// The theme is already applied by index.html inline script before Blazor loads.
    /// </summary>
    public async Task InitializeAsync()
    {
        // Guard against multiple initialization calls
        if (_isInitialized)
        {
            return;
        }

        try
        {
            _themeModule = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./js/theme.js");

            var theme = await _themeModule.InvokeAsync<string>("getCurrentTheme");
            if (!string.IsNullOrEmpty(theme))
            {
                _currentTheme = theme;
            }

            _isInitialized = true;
        }
        catch (JSException ex)
        {
            // Log error for debugging - JS interop failures can be hard to diagnose
            Console.WriteLine($"[ThemeService] JS interop initialization failed: {ex.Message}");
            _currentTheme = "dark";
            _isInitialized = true; // Mark as initialized to prevent retry loops
        }
    }

    /// <summary>
    /// Toggles between dark and light themes.
    /// Full implementation with localStorage persistence in Story 2.2.
    /// </summary>
    public async Task ToggleThemeAsync()
    {
        _currentTheme = _currentTheme == "dark" ? "light" : "dark";

        if (_themeModule != null)
        {
            try
            {
                await _themeModule.InvokeVoidAsync("setTheme", _currentTheme);
            }
            catch (JSException ex)
            {
                // Log but don't throw - theme state is updated, just not persisted
                Console.WriteLine($"[ThemeService] Failed to persist theme: {ex.Message}");
            }
        }
        else
        {
            // Module failed to load - theme change won't persist to localStorage
            Console.WriteLine("[ThemeService] Warning: Theme module not loaded, changes won't persist");
        }

        OnThemeChanged?.Invoke();
    }

    public async ValueTask DisposeAsync()
    {
        if (_themeModule != null)
        {
            await _themeModule.DisposeAsync();
        }
    }
}
