using Microsoft.JSInterop;

namespace BhavanPortfolio.Services;

/// <summary>
/// Service implementation for smooth scroll navigation.
/// Uses JS interop to call scroll.js module for browser scrollIntoView API.
/// </summary>
public class ScrollService : IScrollService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _scrollModule;
    private bool _isModuleLoaded;

    /// <summary>
    /// Header height in pixels to offset scroll position.
    /// Matches the h-16 (64px) sticky header.
    /// </summary>
    private const int HeaderOffset = 64;

    public ScrollService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Scrolls smoothly to the specified section with header offset.
    /// </summary>
    public async Task ScrollToSectionAsync(string sectionId)
    {
        if (string.IsNullOrWhiteSpace(sectionId))
        {
            return;
        }

        try
        {
            await EnsureModuleLoadedAsync();
            
            if (_scrollModule != null)
            {
                await _scrollModule.InvokeVoidAsync("scrollToSection", sectionId, HeaderOffset);
            }
        }
        catch (JSException ex)
        {
            // Log error but don't throw - scroll failure is non-critical
            Console.WriteLine($"[ScrollService] Failed to scroll to section '{sectionId}': {ex.Message}");
        }
    }

    /// <summary>
    /// Ensures the scroll JS module is loaded (lazy initialization).
    /// </summary>
    private async Task EnsureModuleLoadedAsync()
    {
        if (_isModuleLoaded)
        {
            return;
        }

        try
        {
            _scrollModule = await _jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./js/scroll.js");
            _isModuleLoaded = true;
        }
        catch (JSException ex)
        {
            Console.WriteLine($"[ScrollService] Failed to load scroll module: {ex.Message}");
            _isModuleLoaded = true; // Mark as loaded to prevent retry loops
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_scrollModule != null)
        {
            await _scrollModule.DisposeAsync();
        }
    }
}
