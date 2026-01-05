// Scroll module for Blazor JS interop
// Provides smooth scroll navigation to page sections

/**
 * Scrolls smoothly to the specified section element.
 * Respects user's prefers-reduced-motion setting.
 * 
 * @param {string} sectionId - The ID of the target element (without #)
 * @param {number} headerOffset - Pixels to offset for fixed header (default: 64)
 */
export function scrollToSection(sectionId, headerOffset = 64) {
    // Validate input
    if (!sectionId || typeof sectionId !== 'string') {
        console.warn('[scroll.js] Invalid sectionId:', sectionId);
        return;
    }

    // Find the target element
    const element = document.getElementById(sectionId);
    if (!element) {
        console.warn('[scroll.js] Element not found:', sectionId);
        return;
    }

    // Check for reduced motion preference
    const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;

    // Calculate target position accounting for header
    const elementPosition = element.getBoundingClientRect().top;
    const offsetPosition = elementPosition + window.scrollY - headerOffset;

    // Scroll to position with appropriate behavior
    window.scrollTo({
        top: offsetPosition,
        behavior: prefersReducedMotion ? 'auto' : 'smooth'
    });
}

/**
 * Scrolls to top of the page.
 * Useful for "back to top" functionality.
 */
export function scrollToTop() {
    const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    
    window.scrollTo({
        top: 0,
        behavior: prefersReducedMotion ? 'auto' : 'smooth'
    });
}
