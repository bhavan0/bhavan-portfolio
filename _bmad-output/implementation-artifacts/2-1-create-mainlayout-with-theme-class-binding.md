# Story 2.1: Create MainLayout with Theme Class Binding

Status: done

## Story

As a **visitor**,
I want **the page layout to reflect my theme preference**,
So that **the entire site displays consistently in dark or light mode**.

## Acceptance Criteria

1. **AC1**: MainLayout component renders and applies the correct theme class from ThemeService
2. **AC2**: Layout includes skip-to-content link for accessibility (first focusable element)
3. **AC3**: Layout structure supports NavBar at top, main content area, and Footer
4. **AC4**: Layout uses semantic HTML (`<header>`, `<main>`, `<footer>`)
5. **AC5**: All child components inherit the theme context through the layout structure

## Tasks / Subtasks

- [x] **Task 1: Create IThemeService Interface** (AC: 1, 5)
  - [x] 1.1: Create `Services/IThemeService.cs` with interface contract
  - [x] 1.2: Define `CurrentTheme` property (string: "dark" or "light")
  - [x] 1.3: Define `OnThemeChanged` event for component updates
  - [x] 1.4: Define `InitializeAsync()` method signature (syncs with index.html applied theme)
  - [x] 1.5: Define `ToggleThemeAsync()` method signature (placeholder for Story 2.2)

- [x] **Task 2: Create Basic ThemeService Implementation** (AC: 1, 5)
  - [x] 2.1: Create `Services/ThemeService.cs` implementing IThemeService
  - [x] 2.2: Implement InitializeAsync to read current theme from document (via JS interop)
  - [x] 2.3: Implement OnThemeChanged event invocation
  - [x] 2.4: Register as Singleton in `Program.cs`
  - [x] 2.5: Note: ToggleThemeAsync will be fully implemented in Story 2.2

- [x] **Task 3: Create theme.js Module** (AC: 1)
  - [x] 3.1: Create `wwwroot/js/theme.js` module
  - [x] 3.2: Implement `getCurrentTheme()` function (reads from document.documentElement.classList)
  - [x] 3.3: Export function for JS interop consumption
  - [x] 3.4: Note: getStoredTheme, setStoredTheme, getSystemPreference added in Story 2.2

- [x] **Task 4: Enhance MainLayout.razor** (AC: 1, 2, 3, 4, 5)
  - [x] 4.1: Add skip-to-content link as first element (`<a href="#main" class="skip-link">`)
  - [x] 4.2: Add `<header>` placeholder for NavBar (NavBar component in Story 2.3)
  - [x] 4.3: Wrap @Body in `<main id="main">` with proper semantic structure
  - [x] 4.4: Add `<footer>` placeholder (Footer component in Epic 7)
  - [x] 4.5: Inject IThemeService and subscribe to OnThemeChanged
  - [x] 4.6: Implement IDisposable for proper event unsubscription
  - [x] 4.7: Call ThemeService.InitializeAsync() in OnInitializedAsync

- [x] **Task 5: Add CSS for Skip Link and Layout** (AC: 2, 4)
  - [x] 5.1: Add skip-link styles to tailwind-input.css or as scoped styles
  - [x] 5.2: Skip link visually hidden until focused (accessibility pattern)

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document (architecture.md):**

**IThemeService Contract (MUST match exactly):**
```csharp
public interface IThemeService
{
    string CurrentTheme { get; }
    event Action? OnThemeChanged;
    Task InitializeAsync();  // Syncs with index.html applied theme
    Task ToggleThemeAsync(); // Switches theme and persists to localStorage
}
```

**Service Registration (Program.cs):**
```csharp
builder.Services.AddSingleton<IThemeService, ThemeService>();
```

**Theme Application Method:**
- Body class approach: `dark` or `light` class on `<body>` (set by index.html inline script)
- Tailwind config: `darkMode: 'class'` (already configured in Story 1.1)
- Theme resolution: localStorage > system preference > dark default (handled by index.html)

**Service Event Pattern (MUST follow):**
```csharp
@implements IDisposable

@code {
    protected override void OnInitialized()
    {
        ThemeService.OnThemeChanged += HandleThemeChanged;
    }

    private void HandleThemeChanged() => StateHasChanged();

    public void Dispose()
    {
        ThemeService.OnThemeChanged -= HandleThemeChanged;
    }
}
```

### Project Structure (From Architecture)

**Files to Create:**
- `Services/IThemeService.cs` - Interface definition
- `Services/ThemeService.cs` - Implementation
- `wwwroot/js/theme.js` - Browser API access module

**Files to Modify:**
- `Components/Layout/MainLayout.razor` - Enhance with semantic structure
- `Program.cs` - Register ThemeService
- `tailwind-input.css` - Add skip-link styles (optional, can use Tailwind utilities)

### Naming Conventions (Architecture Compliance)

| Element | Convention | This Story |
|---------|------------|------------|
| C# Interface | I + PascalCase | `IThemeService.cs` |
| C# Class | PascalCase | `ThemeService.cs` |
| JS Module | camelCase | `theme.js` |
| Razor Component | PascalCase | `MainLayout.razor` |

### Existing Theme Infrastructure

**index.html (already implemented in Story 1.2):**
- Inline script adds `dark` or `light` class to `document.documentElement` (html element)
- Body has class `bg-black text-white blazor-loading`
- Theme class is on `<html>` element, Tailwind dark mode utilities work via ancestor

**Current MainLayout.razor (minimal):**
```razor
@inherits LayoutComponentBase

<div class="min-h-screen">
    <main>
        @Body
    </main>
</div>
```

### JavaScript Interop Pattern

**Module-based JS Interop (from Architecture):**
```csharp
// In ThemeService.cs
private readonly IJSRuntime _jsRuntime;
private IJSObjectReference? _themeModule;

public async Task InitializeAsync()
{
    _themeModule = await _jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./js/theme.js");
    CurrentTheme = await _themeModule.InvokeAsync<string>("getCurrentTheme");
}
```

### Skip Link Accessibility Pattern

**Standard skip-link implementation:**
```html
<a href="#main" class="sr-only focus:not-sr-only focus:absolute focus:top-4 focus:left-4 
   focus:z-50 focus:px-4 focus:py-2 focus:bg-white focus:text-black focus:rounded">
   Skip to main content
</a>
```

### Layout Structure Target

```html
<body class="dark">
  <a href="#main" class="skip-link">Skip to main content</a>
  <header>
    <!-- NavBar placeholder - implemented in Story 2.3 -->
  </header>
  <main id="main" class="min-h-screen">
    @Body (page content)
  </main>
  <footer>
    <!-- Footer placeholder - implemented in Epic 7 -->
  </footer>
</body>
```

### Previous Epic Learnings (Epic 1 Retrospective)

**From epic-1-retro-2026-01-05.md:**
- Tailwind v4 uses `@import "tailwindcss"` syntax (not @tailwind directives)
- Dark mode classes work via `dark:` prefix when ancestor has `dark` class
- Build verification: Always run `dotnet build` after changes
- Test theme visually: Check both dark and light modes render correctly

### Styling Patterns (From UX Design)

**Color Palette Enforcement (B&W only):**
| Purpose | Dark Mode | Light Mode |
|---------|-----------|------------|
| Background | `bg-black` / `bg-gray-900` | `bg-white` / `bg-gray-50` |
| Text Primary | `text-white` | `text-black` |
| Text Secondary | `text-gray-400` | `text-gray-600` |

### Testing Approach

1. **Theme Detection**: ThemeService.CurrentTheme returns "dark" or "light" based on html class
2. **Skip Link**: Tab to first element, verify skip link appears and focuses main content
3. **Semantic Structure**: Inspect DOM for proper header/main/footer elements
4. **Build**: `dotnet build` must succeed with 0 errors, 0 warnings

### Dependencies

**This story depends on:**
- Story 1.1: Tailwind CSS setup (complete)
- Story 1.2: index.html with theme resolution script (complete)

**Stories that depend on this:**
- Story 2.2: ThemeService JS Interop (extends ThemeService)
- Story 2.3: NavBar (uses header placeholder)
- Story 2.4: ThemeToggle (uses ThemeService)
- All section components (inherit theme context)

### References

- [Source: architecture.md#Frontend-Architecture] - IThemeService contract
- [Source: architecture.md#Service-Event-Pattern] - Component subscription pattern
- [Source: architecture.md#JS-Interop-Strategy] - Module-based JS interop
- [Source: architecture.md#Project-Structure] - File organization
- [Source: ux-design-specification.md#Accessibility-Strategy] - Skip link requirement
- [Source: epics.md#Story-2.1] - Acceptance criteria

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5 (claude-opus-4-5-20251101)

### Debug Log References

None - implementation proceeded without errors.

### Completion Notes List

1. **IThemeService Interface Created (AC1, AC5):**
   - Created `Services/IThemeService.cs` with exact contract from architecture
   - Properties: `CurrentTheme` (string)
   - Events: `OnThemeChanged` (Action?)
   - Methods: `InitializeAsync()`, `ToggleThemeAsync()`

2. **ThemeService Implementation Created (AC1, AC5):**
   - Created `Services/ThemeService.cs` implementing IThemeService
   - Uses IJSRuntime for module-based JS interop
   - InitializeAsync reads current theme from document via theme.js
   - Implements IAsyncDisposable for proper cleanup
   - Registered as Singleton in Program.cs

3. **theme.js Module Created (AC1):**
   - Created `wwwroot/js/theme.js` with ES module exports
   - `getCurrentTheme()` reads theme from document.documentElement.classList
   - `setTheme()` updates classes and localStorage (basic implementation)
   - Placeholder comments for Story 2.2 additional functions

4. **MainLayout.razor Enhanced (AC1-AC5):**
   - Skip-to-content link as first focusable element (AC2)
   - Uses Tailwind `sr-only focus:not-sr-only` pattern for accessibility
   - Semantic `<header>` with role="navigation" and aria-label (AC3, AC4)
   - Semantic `<main id="main">` wrapper for @Body (AC3, AC4)
   - Semantic `<footer>` placeholder (AC3, AC4)
   - Injects IThemeService and subscribes to OnThemeChanged (AC5)
   - Implements IDisposable with proper event unsubscription
   - Calls InitializeAsync in OnInitializedAsync

5. **Build verified:** `dotnet build` succeeded with 0 errors, 0 warnings

### Change Log

- 2026-01-05: Story 2.1 implementation complete
- 2026-01-05: Code review fixes applied (5 issues resolved)

## Senior Developer Review (AI)

**Review Date:** 2026-01-05
**Outcome:** Approved (with fixes applied)

### Issues Found and Resolved

| # | Severity | Description | Status |
|---|----------|-------------|--------|
| 1 | HIGH | InitializeAsync lacks guard against multiple calls | ✅ Fixed |
| 2 | HIGH | No error logging on JS interop failure | ✅ Fixed |
| 3 | MEDIUM | setTheme doesn't validate input parameter | ✅ Fixed |
| 4 | MEDIUM | ToggleThemeAsync doesn't handle module load failure | ✅ Fixed |
| 5 | MEDIUM | Skip link focus ring missing explicit color | ✅ Fixed |

### Fixes Applied

1. **ThemeService.cs:** Added `_isInitialized` guard flag to prevent multiple JS module imports
2. **ThemeService.cs:** Added Console.WriteLine logging for JS interop failures
3. **ThemeService.cs:** Added try/catch and warning in ToggleThemeAsync for module failures
4. **theme.js:** Added input validation in setTheme() with warning for invalid values
5. **MainLayout.razor:** Added explicit `focus:ring-white focus:ring-offset-black` for visibility
6. **MainLayout.razor:** Removed redundant dark: prefixes and story-reference comments

### File List

**Created:**
- `BhavanPortfolio/Services/IThemeService.cs`
- `BhavanPortfolio/Services/ThemeService.cs`
- `BhavanPortfolio/wwwroot/js/theme.js`

**Modified:**
- `BhavanPortfolio/Components/Layout/MainLayout.razor`
- `BhavanPortfolio/Program.cs`
- `BhavanPortfolio/_Imports.razor`
