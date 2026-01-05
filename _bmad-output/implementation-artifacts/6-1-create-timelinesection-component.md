# Story 6.1: Create TimelineSection Component

Status: done

## Story

As a **visitor**,
I want **to see work experience chronologically**,
So that **I can understand career progression and relevant experience**.

## Acceptance Criteria

1. **AC1:** The section has `id="experience"` for navigation anchor linking
2. **AC2:** The section heading is properly styled (`text-3xl md:text-4xl font-semibold`)
3. **AC3:** Timeline entries are displayed vertically with appropriate spacing
4. **AC4:** The section has proper padding (`py-20 md:py-32`)
5. **AC5:** Entries show career progression clearly (most recent first)
6. **AC6:** The section uses semantic HTML (`<section>` with `aria-labelledby`)
7. **AC7:** The component follows B&W aesthetic from architecture (constrained palette)

## Tasks / Subtasks

- [x] Task 1: Create TimelineSection.razor in Components/Sections/ (AC: 1, 2, 4, 6, 7)
  - [x] Create section with id="experience" and aria-labelledby
  - [x] Add heading with proper typography classes
  - [x] Add container with max-w-6xl mx-auto px-4 md:px-6
  - [x] Add proper padding py-20 md:py-32
  - [x] Apply B&W aesthetic with dark mode support

- [x] Task 2: Create timeline layout structure (AC: 3, 5)
  - [x] Create vertical timeline line using border-l-2
  - [x] Set up placeholder structure for TimelineItem components
  - [x] Ensure proper spacing between items

## Dev Notes

### Architecture Requirements
- Component location: `Components/Sections/TimelineSection.razor`
- Must follow PascalCase naming convention
- Use only constrained B&W palette: black, white, gray-50 through gray-900
- Section should integrate with existing MainLayout structure

### Project Structure Notes
- Follows established pattern from SkillsSection.razor and ProjectsSection.razor
- Will render TimelineItem components (Story 6.2) when available
- Initially can have placeholder content until TimelineItem is created

### References
- [Source: _bmad-output/planning-artifacts/architecture.md#Project Structure]
- [Source: _bmad-output/planning-artifacts/epics.md#Story 6.1]
- [Source: _bmad-output/planning-artifacts/ux-design-specification.md#Timeline Section]

## Dev Agent Record

### Agent Model Used
Claude Opus 4.5 (claude-opus-4-5-20251101)

### Completion Notes List
- Created TimelineSection.razor with all acceptance criteria met
- Added to Home.razor page
- Renders TimelineItem components for work experience

### File List
- BhavanPortfolio/Components/Sections/TimelineSection.razor (created)
- BhavanPortfolio/Pages/Home.razor (modified - added TimelineSection)
