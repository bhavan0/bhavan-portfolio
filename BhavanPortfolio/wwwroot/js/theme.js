// Theme module for Blazor JS interop
// Provides browser API access for theme detection and manipulation

/**
 * Gets the current theme from the document's html element class.
 * The theme class is applied by index.html inline script before Blazor loads.
 * @returns {string} "dark" or "light"
 */
export function getCurrentTheme() {
    if (document.documentElement.classList.contains('dark')) {
        return 'dark';
    }
    if (document.documentElement.classList.contains('light')) {
        return 'light';
    }
    // Default to dark if neither class is present
    return 'dark';
}

/**
 * Sets the theme by updating document classes and localStorage.
 * @param {string} theme - "dark" or "light"
 */
export function setTheme(theme) {
    // Validate input - only accept valid theme values
    if (theme !== 'dark' && theme !== 'light') {
        console.warn('[theme.js] Invalid theme value:', theme, '- defaulting to dark');
        theme = 'dark';
    }

    // Remove both theme classes
    document.documentElement.classList.remove('dark', 'light');
    // Add the new theme class
    document.documentElement.classList.add(theme);
    // Persist to localStorage
    localStorage.setItem('theme', theme);
}

/**
 * Gets the stored theme from localStorage.
 * @returns {string|null} "dark", "light", or null if not set
 */
export function getStoredTheme() {
    return localStorage.getItem('theme');
}

/**
 * Saves the theme preference to localStorage.
 * Used for direct localStorage access without DOM updates.
 * @param {string} theme - "dark" or "light"
 */
export function setStoredTheme(theme) {
    if (theme !== 'dark' && theme !== 'light') {
        console.warn('[theme.js] setStoredTheme: Invalid theme value:', theme, '- ignoring');
        return;
    }
    localStorage.setItem('theme', theme);
}

/**
 * Gets the system color scheme preference.
 * @returns {string} "dark" or "light" based on prefers-color-scheme media query
 */
export function getSystemPreference() {
    return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
}
