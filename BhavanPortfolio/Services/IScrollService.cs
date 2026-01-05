namespace BhavanPortfolio.Services;

/// <summary>
/// Service interface for smooth scroll navigation to page sections.
/// </summary>
public interface IScrollService
{
    /// <summary>
    /// Scrolls smoothly to the specified section.
    /// Accounts for sticky header offset and respects prefers-reduced-motion.
    /// </summary>
    /// <param name="sectionId">The ID of the target section element (without #)</param>
    Task ScrollToSectionAsync(string sectionId);
}
