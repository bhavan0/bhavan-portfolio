# Story 6.3: Create ContactSection Component

Status: done

## Story

As a **visitor**,
I want **clear ways to contact the developer**,
So that **I can reach out for opportunities**.

## Acceptance Criteria

1. **AC1:** The section has `id="contact"` for navigation anchor linking
2. **AC2:** Email link is displayed as `mailto:` link
3. **AC3:** LinkedIn profile link is displayed
4. **AC4:** GitHub profile link is displayed
5. **AC5:** All external links open in new tab with `target="_blank" rel="noopener noreferrer"`
6. **AC6:** Links meet 44px touch target minimum
7. **AC7:** The section has proper padding and styling (`py-20 md:py-32`)
8. **AC8:** Section uses semantic HTML with aria-labelledby

## Tasks / Subtasks

- [x] Task 1: Create ContactSection.razor in Components/Sections/ (AC: 1, 7, 8)
  - [x] Create section with id="contact" and aria-labelledby
  - [x] Add heading with proper typography
  - [x] Add container with max-w-6xl mx-auto px-4 md:px-6
  - [x] Add proper padding py-20 md:py-32

- [x] Task 2: Add contact links (AC: 2, 3, 4, 5, 6)
  - [x] Add email mailto: link
  - [x] Add LinkedIn profile link
  - [x] Add GitHub profile link
  - [x] Ensure all external links have target="_blank" rel="noopener noreferrer"
  - [x] Ensure 44px minimum touch targets

## Dev Notes

### Architecture Requirements
- Component location: `Components/Sections/ContactSection.razor`
- Follow section patterns from AboutSection.razor, SkillsSection.razor
- Use only constrained B&W palette
- Will use SocialLink component (Story 6.4) when available

### Content Notes
- Email: placeholder (will use actual email)
- LinkedIn: placeholder (will use actual profile URL)
- GitHub: placeholder (will use actual profile URL)

### Project Structure Notes
- Follows established section pattern
- Will render SocialLink components when available
- Can initially use direct links before SocialLink component exists

### References
- [Source: _bmad-output/planning-artifacts/architecture.md#Project Structure]
- [Source: _bmad-output/planning-artifacts/epics.md#Story 6.3]

## Dev Agent Record

### Agent Model Used
Claude Opus 4.5 (claude-opus-4-5-20251101)

### Completion Notes List
- Created ContactSection.razor with all acceptance criteria met
- Uses SocialLink component for email, LinkedIn, and GitHub links
- Added to Home.razor page
- Removed redundant @using directive during code review

### File List
- BhavanPortfolio/Components/Sections/ContactSection.razor (created)
- BhavanPortfolio/Pages/Home.razor (modified - added ContactSection)
