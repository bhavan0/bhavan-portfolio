# Story 6.4: Create SocialLink Component

Status: done

## Story

As a **visitor**,
I want **consistent styling for social/contact links**,
So that **I can easily identify and click contact options**.

## Acceptance Criteria

1. **AC1:** Each link has an icon (email, LinkedIn, GitHub)
2. **AC2:** The link text/icon is clearly visible
3. **AC3:** Hover state indicates interactivity
4. **AC4:** Focus indicators are visible for keyboard navigation
5. **AC5:** The component is reusable across Contact and Footer sections
6. **AC6:** `aria-label` provides context for screen readers

## Tasks / Subtasks

- [x] Task 1: Create SocialLink.razor in Components/Shared/ (AC: 1-6)
  - [x] Create component with required parameters (Icon, Label, Url)
  - [x] Add icon display (using text symbols or inline SVG)
  - [x] Add visible link text
  - [x] Add hover states for interactivity indication
  - [x] Add focus:ring classes for keyboard navigation
  - [x] Add aria-label for screen reader context

- [x] Task 2: Ensure reusability (AC: 5)
  - [x] Make component flexible for different link types
  - [x] Support both internal mailto: and external https: links
  - [x] Use conditional target="_blank" for external links

## Dev Notes

### Architecture Requirements
- Component location: `Components/Shared/SocialLink.razor`
- Must use `[Parameter, EditorRequired]` for required props
- Follow existing shared component patterns from SkillBadge.razor, ProjectCard.razor
- Use only constrained B&W palette

### Component Parameters
- `IconType`: enum or string for icon selection (Email, LinkedIn, GitHub)
- `Label`: string (display text) - required
- `Url`: string (href) - required
- `IsExternal`: bool (whether to open in new tab) - optional, default true for http/https

### Icon Approach
- Use Unicode symbols or simple inline SVG
- Email: ✉ or envelope icon
- LinkedIn: ⇱ or "in" text badge
- GitHub: ⌂ or GitHub mark

### Project Structure Notes
- Used in ContactSection.razor and Footer.razor (Story 7.1)
- Follows shared component pattern
- Should meet 44px touch target minimum

### References
- [Source: _bmad-output/planning-artifacts/architecture.md#Shared Components]
- [Source: _bmad-output/planning-artifacts/epics.md#Story 6.4]

## Dev Agent Record

### Agent Model Used
Claude Opus 4.5 (claude-opus-4-5-20251101)

### Completion Notes List
- Created SocialLink.razor with all acceptance criteria met
- Uses SocialLinkType enum for icon selection
- Auto-detects mailto: links to disable external link behavior
- Updated icons to use emojis for visual consistency during code review

### File List
- BhavanPortfolio/Components/Shared/SocialLink.razor (created)
