# Story 2.4: Implement ThemeToggle Component

Status: done

## Story

As a **visitor**,
I want **a visible toggle to switch between dark and light modes**,
so that **I can view the portfolio in my preferred color scheme**.

## Acceptance Criteria

1. **Given** a visitor clicks the theme toggle **When** the toggle is activated **Then** the icon changes from moon (dark mode) to sun (light mode) or vice versa
2. **Given** a theme toggle interaction **When** the transition occurs **Then** it is instant with subtle animation
3. **Given** the theme toggle button **When** rendered **Then** it meets 44px minimum touch target (NFR11)
4. **Given** the theme toggle button **When** rendered **Then** `aria-label` and `aria-pressed` attributes are set correctly
5. **Given** the theme toggle button **When** a user navigates via keyboard **Then** the toggle is keyboard accessible (Enter/Space activation)
6. **Given** the theme toggle button **When** focused **Then** focus indicator is visible (`focus:ring-2 focus:ring-white focus:ring-offset-2`)

## Tasks / Subtasks

- [x] Task 1: Create ThemeToggle.razor component in Components/Shared/ (AC: 1, 2, 3)
  - [x] Create component file with sun/moon SVG icons
  - [x] Implement icon swap based on current theme from IThemeService
  - [x] Apply 44px minimum touch target styling (w-11 h-11 or min-w-[44px] min-h-[44px])
  - [x] Add transition animation for icon swap (transition-transform duration-200)
- [x] Task 2: Implement accessibility attributes (AC: 4, 5, 6)
  - [x] Add dynamic aria-label based on current theme
  - [x] Add aria-pressed attribute reflecting theme state
  - [x] Ensure button is focusable and keyboard accessible
  - [x] Add focus ring styling matching project patterns
- [x] Task 3: Integrate ThemeToggle into NavBar (AC: 1, 2)
  - [x] Replace inline theme toggle code in NavBar.razor with ThemeToggle component
  - [x] Verify theme toggle works in both desktop and mobile contexts
- [x] Task 4: Test keyboard and screen reader accessibility (AC: 4, 5, 6)
  - [x] Test Enter key activates toggle
  - [x] Test Space key activates toggle  
  - [x] Verify aria attributes update correctly on toggle

## Dev Notes

### Architecture Requirements
- Component location: `Components/Shared/ThemeToggle.razor`
- Uses IThemeService via @inject for theme state management
- Must implement IDisposable to unsubscribe from OnThemeChanged event
- Follow service event subscription pattern from project-context.md

### Technical Implementation
- Icons: Sun (☀) for light mode indicator, Moon (🌙) for dark mode indicator
- Current NavBar.razor already has inline theme toggle - extract to reusable component
- Button styling must include:
  - `w-11 h-11` for 44px touch target
  - `flex items-center justify-center` for centering
  - `rounded-lg` for consistent shape
  - Theme-aware colors: `text-gray-600 dark:text-gray-400`
  - Hover states: `hover:bg-gray-100 dark:hover:bg-gray-800`
  - Focus ring: `focus:outline-none focus:ring-2 focus:ring-black dark:focus:ring-white focus:ring-offset-2 focus:ring-offset-white dark:focus:ring-offset-gray-900`

### UX Design Reference
From ux-design-specification.md:
- ThemeToggle: Icon button, sun/moon, 44px touch target
- Instant theme toggle, no flash, localStorage persist
- Icon swap with subtle animation

### Existing Code Reference
Current inline implementation in NavBar.razor (lines 36-58) to be extracted and enhanced.

### Project Structure Notes
- Path: `BhavanPortfolio/Components/Shared/ThemeToggle.razor`
- Update `NavBar.razor` to use the new component

### References
- [Source: _bmad-output/planning-artifacts/epics.md - Story 2.4]
- [Source: _bmad-output/planning-artifacts/architecture.md - Service Event Pattern]
- [Source: _bmad-output/project-context.md - Component Parameters]
- [Source: _bmad-output/planning-artifacts/ux-design-specification.md - ThemeToggle component]

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5

### Debug Log References

Build successful with 0 warnings, 0 errors.

### Completion Notes List

- Created ThemeToggle.razor as a reusable component in Components/Shared/
- Component includes sun/moon SVG icons with CSS transition animations for smooth icon swap
- Applied w-11 h-11 (44px) for proper touch target sizing per NFR11
- Implemented full accessibility: aria-label, aria-pressed, keyboard accessible button
- Integrated into NavBar.razor, replacing inline implementation
- Added Components.Shared namespace to _Imports.razor for global availability
- Component properly implements IDisposable for event subscription cleanup

### Change Log

- 2026-01-05: Created ThemeToggle component, integrated into NavBar

### File List

- BhavanPortfolio/Components/Shared/ThemeToggle.razor (created)
- BhavanPortfolio/Components/Layout/NavBar.razor (modified)
- BhavanPortfolio/_Imports.razor (modified)
