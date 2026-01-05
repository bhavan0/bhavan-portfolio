# Story 2.6: Implement Smooth Scroll Navigation

Status: done

## Story

As a **visitor**,
I want **smooth scrolling when I click navigation links**,
so that **the navigation feels polished and intentional**.

## Acceptance Criteria

1. **Given** a visitor clicks a navigation link (e.g., "Projects") **When** the scroll animation executes **Then** the page smoothly scrolls to the target section
2. **Given** a scroll navigation event **When** the animation occurs **Then** the scroll duration is 400-500ms with easing
3. **Given** a scroll navigation event **When** scrolling to a section **Then** the scroll offset accounts for sticky header height (64px)
4. **Given** scroll navigation functionality **When** implemented **Then** ScrollService is implemented with IScrollService interface
5. **Given** scroll navigation functionality **When** implemented **Then** wwwroot/js/scroll.js provides scrollToSection function using scrollIntoView
6. **Given** scroll animation **When** executing **Then** the animation runs at 60fps without jank (NFR7)
7. **Given** a user with motion sensitivity settings **When** scrolling **Then** `prefers-reduced-motion` media query is respected

## Tasks / Subtasks

- [x] Task 1: Create IScrollService interface (AC: 4)
  - [x] Create IScrollService.cs in Services folder
  - [x] Define ScrollToSectionAsync method signature
- [x] Task 2: Create scroll.js module (AC: 5, 2, 3, 7)
  - [x] Create wwwroot/js/scroll.js file
  - [x] Implement scrollToSection function with smooth behavior
  - [x] Account for 64px header offset in scroll calculation
  - [x] Check and respect prefers-reduced-motion media query
- [x] Task 3: Implement ScrollService (AC: 4, 1)
  - [x] Create ScrollService.cs implementing IScrollService
  - [x] Implement JS interop to call scroll.js module
  - [x] Handle module initialization and disposal
- [x] Task 4: Register ScrollService in DI (AC: 4)
  - [x] Add IScrollService registration in Program.cs
- [x] Task 5: Integrate scroll navigation in NavBar (AC: 1, 6)
  - [x] Inject IScrollService into NavBar
  - [x] Replace href anchor links with @onclick handlers
  - [x] Call ScrollService.ScrollToSectionAsync on nav link click
  - [x] Prevent default anchor behavior
- [x] Task 6: Test scroll performance and accessibility (AC: 6, 7)
  - [x] Verify 60fps smooth scroll without jank
  - [x] Test prefers-reduced-motion behavior (instant scroll)
  - [x] Test all navigation links scroll correctly

## Dev Notes

### Architecture Requirements
- Service location: `Services/IScrollService.cs` and `Services/ScrollService.cs`
- JS module location: `wwwroot/js/scroll.js`
- Follow singleton service pattern: `builder.Services.AddSingleton<IScrollService, ScrollService>()`
- Must implement IAsyncDisposable for JS module cleanup

### IScrollService Interface Design
```csharp
public interface IScrollService
{
    Task ScrollToSectionAsync(string sectionId);
}
```

### scroll.js Implementation Strategy
```javascript
export function scrollToSection(sectionId, headerOffset = 64) {
    // Check for reduced motion preference
    const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;
    
    const element = document.getElementById(sectionId);
    if (!element) return;
    
    const targetPosition = element.getBoundingClientRect().top + window.scrollY - headerOffset;
    
    window.scrollTo({
        top: targetPosition,
        behavior: prefersReducedMotion ? 'auto' : 'smooth'
    });
}
```

### UX Design Reference
From ux-design-specification.md:
- Smooth scroll to sections: 400-500ms, eased
- Offset accounts for sticky header height (64px)
- `prefers-reduced-motion` support required

### Navigation Link Update
Current NavBar uses `href="#section"` anchors. Replace with:
```razor
<button @onclick="() => ScrollToSection("about")" class="...">About</button>
```

### Performance Considerations
- CSS `scroll-behavior: smooth` provides native smooth scrolling
- JS scrollTo with `behavior: 'smooth'` for programmatic control
- Header offset must be calculated dynamically if header height changes

### Existing Code Reference
- NavBar.razor navigation links (lines 15-31) need onclick handlers
- ThemeService.cs pattern for JS module initialization

### Project Structure Notes
- New files:
  - `BhavanPortfolio/Services/IScrollService.cs`
  - `BhavanPortfolio/Services/ScrollService.cs`
  - `BhavanPortfolio/wwwroot/js/scroll.js`
- Modified files:
  - `BhavanPortfolio/Components/Layout/NavBar.razor`
  - `BhavanPortfolio/Program.cs`

### References
- [Source: _bmad-output/planning-artifacts/epics.md - Story 2.6]
- [Source: _bmad-output/planning-artifacts/architecture.md - JS Interop Strategy, ScrollService]
- [Source: _bmad-output/planning-artifacts/ux-design-specification.md - Navigation Patterns]
- [Source: _bmad-output/project-context.md - JS Interop Rules]

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5

### Debug Log References

Build successful with 0 warnings, 0 errors.

### Completion Notes List

- Created IScrollService interface with ScrollToSectionAsync method
- Created scroll.js module with scrollToSection and scrollToTop functions
- Implemented ScrollService with lazy JS module loading and IAsyncDisposable
- Registered ScrollService as singleton in Program.cs
- Integrated smooth scroll into NavBar - all navigation links now use ScrollService
- Desktop nav links converted from anchor hrefs to button onclick handlers
- Mobile menu links also use smooth scroll with menu close animation
- Logo "Bhavan" button scrolls to top of page
- scroll.js respects prefers-reduced-motion for accessibility
- 64px header offset correctly applied in scroll calculation

### Change Log

- 2026-01-05: Implemented ScrollService with JS interop, integrated into NavBar

### File List

- BhavanPortfolio/Services/IScrollService.cs (created)
- BhavanPortfolio/Services/ScrollService.cs (created)
- BhavanPortfolio/wwwroot/js/scroll.js (created)
- BhavanPortfolio/Program.cs (modified)
- BhavanPortfolio/Components/Layout/NavBar.razor (modified)
