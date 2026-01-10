/**
 * Focus trap module for modal dialogs
 * Ensures keyboard focus stays within a modal when open
 */

const FOCUSABLE_SELECTORS = [
    'button:not([disabled])',
    'a[href]',
    'input:not([disabled])',
    'select:not([disabled])',
    'textarea:not([disabled])',
    '[tabindex]:not([tabindex="-1"])'
].join(', ');

// Store active trap handlers for cleanup
const activeTraps = new Map();

/**
 * Gets all focusable elements within a container
 * @param {HTMLElement} container - The container element
 * @returns {HTMLElement[]} Array of focusable elements
 */
function getFocusableElements(container) {
    if (!container) return [];
    return Array.from(container.querySelectorAll(FOCUSABLE_SELECTORS))
        .filter(el => el.offsetParent !== null); // Filter out hidden elements
}

/**
 * Creates a keydown handler for focus trapping
 * @param {HTMLElement} container - The container element
 * @returns {Function} The keydown handler
 */
function createTrapHandler(container) {
    return function(event) {
        if (event.key !== 'Tab') return;

        const focusableElements = getFocusableElements(container);
        if (focusableElements.length === 0) return;

        const firstElement = focusableElements[0];
        const lastElement = focusableElements[focusableElements.length - 1];

        // Shift+Tab on first element -> go to last
        if (event.shiftKey && document.activeElement === firstElement) {
            event.preventDefault();
            lastElement.focus();
        }
        // Tab on last element -> go to first
        else if (!event.shiftKey && document.activeElement === lastElement) {
            event.preventDefault();
            firstElement.focus();
        }
    };
}

/**
 * Activates focus trap on a container
 * @param {string} containerId - The ID of the container element
 */
export function activateTrap(containerId) {
    const container = document.getElementById(containerId);
    if (!container) return;

    // Remove any existing trap on this container
    deactivateTrap(containerId);

    const handler = createTrapHandler(container);
    container.addEventListener('keydown', handler);
    activeTraps.set(containerId, handler);
}

/**
 * Deactivates focus trap on a container
 * @param {string} containerId - The ID of the container element
 */
export function deactivateTrap(containerId) {
    const handler = activeTraps.get(containerId);
    if (handler) {
        const container = document.getElementById(containerId);
        if (container) {
            container.removeEventListener('keydown', handler);
        }
        activeTraps.delete(containerId);
    }
}

/**
 * Focuses the first focusable element in a container
 * @param {string} containerId - The ID of the container element
 */
export function focusFirstElement(containerId) {
    const container = document.getElementById(containerId);
    if (!container) return;

    const focusableElements = getFocusableElements(container);
    if (focusableElements.length > 0) {
        focusableElements[0].focus();
    }
}

/**
 * Focuses a specific element by ID
 * @param {string} elementId - The ID of the element to focus
 */
export function focusElement(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}
