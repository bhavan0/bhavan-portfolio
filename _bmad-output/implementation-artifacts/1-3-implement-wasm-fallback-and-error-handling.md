# Story 1.3: Implement WASM Fallback and Error Handling

Status: done

## Story

As a **visitor**,
I want **to see a helpful message if the application fails to load**,
So that **I understand the situation rather than seeing a broken page**.

## Acceptance Criteria

1. **AC1**: A fallback message is displayed if WASM fails to initialize within 10 seconds
2. **AC2**: The fallback message text is: "This site requires a modern browser with JavaScript enabled"
3. **AC3**: The fallback message maintains the B&W aesthetic (consistent with loading shell)
4. **AC4**: A `<noscript>` tag provides a message for JavaScript-disabled browsers
5. **AC5**: The fallback does NOT appear if Blazor initializes successfully
6. **AC6**: The loading shell gracefully transitions to the fallback state (fade effect)
7. **AC7**: The fallback handling does not break existing Blazor.start() integration

## Tasks / Subtasks

- [x] **Task 1: Implement 10-Second Timeout Fallback** (AC: 1, 2, 5)
  - [x] 1.1: Create a `setTimeout` function that triggers after 10000ms
  - [x] 1.2: Store the timeout ID in a variable for later clearing
  - [x] 1.3: In the timeout callback, display the fallback message
  - [x] 1.4: Clear the timeout when `Blazor.start().then()` resolves successfully
  - [x] 1.5: Ensure timeout is set before Blazor.start() is called

- [x] **Task 2: Create Fallback Message HTML** (AC: 2, 3, 6)
  - [x] 2.1: Create a hidden `<div id="wasm-fallback">` element in index.html
  - [x] 2.2: Add the message text: "This site requires a modern browser with JavaScript enabled"
  - [x] 2.3: Style with B&W aesthetic: `bg-black text-white` base classes
  - [x] 2.4: Center the message: `flex items-center justify-center min-h-screen`
  - [x] 2.5: Add typography styling: `text-xl md:text-2xl text-gray-400`
  - [x] 2.6: Initially hide with `display: none` or CSS class

- [x] **Task 3: Implement Fallback Display Logic** (AC: 1, 5, 6)
  - [x] 3.1: Create function to show fallback: removes loading shell, shows fallback div
  - [x] 3.2: Add CSS transition for smooth fade from loading shell to fallback
  - [x] 3.3: Remove `.blazor-loading` class when showing fallback
  - [x] 3.4: Ensure fallback function is only called by timeout (not on success)

- [x] **Task 4: Add Noscript Tag** (AC: 4)
  - [x] 4.1: Add `<noscript>` element inside `<body>` near the top
  - [x] 4.2: Include message: "This site requires JavaScript to function properly"
  - [x] 4.3: Style noscript content with B&W aesthetic
  - [x] 4.4: Center the noscript message similar to fallback

- [x] **Task 5: Add CSS for Fallback Transitions** (AC: 6)
  - [x] 5.1: Add `#wasm-fallback` styles to `tailwind-input.css`
  - [x] 5.2: Define hidden state: `opacity: 0; visibility: hidden`
  - [x] 5.3: Define visible state: `opacity: 1; visibility: visible`
  - [x] 5.4: Add transition properties: `transition: opacity 0.3s ease-out, visibility 0.3s ease-out`

- [x] **Task 6: Verify Integration with Existing Code** (AC: 7)
  - [x] 6.1: Ensure existing `Blazor.start().then()` logic still works
  - [x] 6.2: Verify loading shell still fades out correctly on success
  - [x] 6.3: Test that theme resolution still works
  - [x] 6.4: Run `dotnet build` and verify no errors

- [x] **Task 7: Test Fallback Scenarios** (AC: 1, 2, 5)
  - [x] 7.1: Test normal success case: Blazor loads, no fallback shown
  - [x] 7.2: Test timeout case: Block WASM loading, verify fallback appears after 10s
  - [x] 7.3: Test noscript: Disable JavaScript, verify noscript message shown
  - [x] 7.4: Verify graceful transition animation

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document (architecture.md#Loading-Shell-Requirements):**
- 10-second timeout with fallback message for WASM failure
- `<noscript>` tag for JavaScript-disabled browsers
- Fallback maintains B&W aesthetic

**From Epics (FR37, NFR12):**
- FR37: Visitors can see a fallback message if the application fails to initialize
- NFR12: WASM Load Failure - Graceful fallback message via error scenario testing

### Previous Story State (Story 1.2)

**Current index.html Structure:**
```html
<body class="bg-black text-white dark:bg-black dark:text-white light:bg-white light:text-black blazor-loading">
    <!-- Loading Shell -->
    <div id="loading-shell">...</div>

    <!-- Blazor App Container -->
    <div id="app"></div>

    <div id="blazor-error-ui">...</div>

    <script src="_framework/blazor.webassembly.js"></script>
    <script>
        Blazor.start().then(function() {
            document.body.classList.remove('blazor-loading');
        });
    </script>
</body>
```

**What Story 1.2 Established:**
- Loading shell with `#loading-shell` div
- Theme resolution script in `<head>`
- `Blazor.start().then()` removes `.blazor-loading` class on success
- CSS transitions defined in `tailwind-input.css`

### Implementation Pattern

**Timeout + Fallback Pattern:**
```javascript
// Set timeout BEFORE calling Blazor.start()
var wasmTimeout = setTimeout(function() {
    // Hide loading shell
    document.getElementById('loading-shell').style.display = 'none';
    // Show fallback
    document.getElementById('wasm-fallback').style.display = 'flex';
    document.body.classList.remove('blazor-loading');
}, 10000);

// Start Blazor and clear timeout on success
Blazor.start().then(function() {
    clearTimeout(wasmTimeout);
    document.body.classList.remove('blazor-loading');
});
```

**Fallback HTML Structure:**
```html
<!-- WASM Fallback - shown after 10s timeout -->
<div id="wasm-fallback" class="min-h-screen flex items-center justify-center" style="display: none;">
    <div class="text-center max-w-6xl mx-auto px-4 md:px-6">
        <p class="text-xl md:text-2xl text-gray-400">
            This site requires a modern browser with JavaScript enabled.
        </p>
    </div>
</div>

<!-- Noscript for JS-disabled browsers -->
<noscript>
    <div class="min-h-screen flex items-center justify-center bg-black text-white">
        <p class="text-xl text-gray-400 text-center px-4">
            This site requires JavaScript to function properly.
        </p>
    </div>
</noscript>
```

### CSS Additions for Fallback

**Add to tailwind-input.css:**
```css
/* WASM Fallback transitions */
#wasm-fallback {
    transition: opacity 0.3s ease-out, visibility 0.3s ease-out;
}

#wasm-fallback.hidden {
    opacity: 0;
    visibility: hidden;
    display: none;
}

#wasm-fallback.visible {
    opacity: 1;
    visibility: visible;
}
```

### Testing Fallback Behavior

**How to Test Timeout:**
1. Open Chrome DevTools > Network tab
2. Set offline mode OR block `_framework/blazor.webassembly.js`
3. Refresh page
4. Wait 10 seconds
5. Verify fallback message appears

**How to Test Noscript:**
1. Chrome DevTools > Settings > Debugger > Disable JavaScript
2. Refresh page
3. Verify noscript message visible

### B&W Palette Reference (from Story 1.1)

Colors allowed: black, white, gray-50, gray-200, gray-300, gray-400, gray-600, gray-700, gray-800, gray-900

Fallback should use:
- Background: `bg-black` (or inherit from body)
- Text: `text-gray-400` for message
- Container: Same as loading shell for consistency

### Files to Modify

**Existing files to update:**
- `BhavanPortfolio/wwwroot/index.html` - Add fallback div, noscript, timeout logic
- `BhavanPortfolio/tailwind-input.css` - Add fallback transition styles (optional)

**No new files required.**

### Error Handling Best Practices

**Do NOT:**
- Show technical error messages to users
- Leave the page blank on failure
- Break existing functionality

**DO:**
- Provide a clear, friendly message
- Maintain visual consistency
- Allow the page to be refreshed

### References

- [Source: architecture.md#Loading-Shell-Requirements] - 10s timeout, noscript requirements
- [Source: epics.md#Story-1.3] - Acceptance criteria and BDD
- [Source: Story 1.2 File List] - Current index.html structure
- [Source: Story 1.2 Implementation] - Existing Blazor.start() pattern
- [Microsoft Learn: Blazor Startup](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/startup) - Blazor error handling

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5 (claude-opus-4-5-20251101)

### Debug Log References

- Build succeeded with Tailwind v4.1.18 compilation
- No errors or warnings during implementation

### Completion Notes List

- ✅ 10-second timeout implemented with `setTimeout`/`clearTimeout` pattern (AC1, AC5)
- ✅ Fallback message displays exact text: "This site requires a modern browser with JavaScript enabled" (AC2)
- ✅ Fallback maintains B&W aesthetic with `text-gray-400` and centered layout (AC3)
- ✅ `<noscript>` tag added at top of body with message: "This site requires JavaScript to function properly" (AC4)
- ✅ Timeout cleared on successful Blazor.start() - fallback never appears on success (AC5)
- ✅ Graceful fade transition: loading shell fades out (0.3s), then fallback fades in (AC6)
- ✅ Existing Blazor.start().then() integration preserved and working (AC7)
- ✅ Light mode CSS added for fallback and noscript elements
- ✅ `dotnet build` succeeds with Tailwind CSS output generated

### Change Log

- 2026-01-05: Implemented Story 1.3 - WASM fallback and error handling

### File List

**Modified Files:**
- BhavanPortfolio/wwwroot/index.html - Added noscript tag, wasm-fallback div, timeout logic
- BhavanPortfolio/tailwind-input.css - Added fallback transition CSS and light mode styles
- BhavanPortfolio/wwwroot/css/app.css - Compiled Tailwind CSS output (auto-generated)
- BhavanPortfolio/Pages/NotFound.razor - Added light mode support class

## Senior Developer Review (AI)

**Review Date:** 2026-01-05
**Reviewer:** Claude Opus 4.5

### Issues Found & Fixed:
1. **[MEDIUM] NotFound.razor hard-codes dark theme** - Added `.not-found-container` class and CSS for light mode support.
2. **[MEDIUM] Missing .catch() on Blazor.start()** - Added error handler; timeout still handles fallback display.

### Verification:
- Build succeeds with Tailwind v4.1.18
- Timeout logic correctly clears on success
- Error handling gracefully logs failures
- Light mode CSS added for all new elements
