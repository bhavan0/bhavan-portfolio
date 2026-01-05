# Story 6.2: Create TimelineItem Component

Status: done

## Story

As a **visitor**,
I want **to see details of each work experience**,
So that **I can evaluate relevant background**.

## Acceptance Criteria

1. **AC1:** A vertical line connects entries using `border-l-2 border-gray-700`
2. **AC2:** A dot marks each entry (`w-3 h-3 rounded-full bg-white`)
3. **AC3:** The date/period is displayed (`text-sm text-gray-400 font-medium`)
4. **AC4:** The role title is prominent (`text-lg font-semibold`)
5. **AC5:** The company name is shown (`text-base text-gray-400`)
6. **AC6:** A brief role description is included
7. **AC7:** Entries use semantic list structure
8. **AC8:** `<time>` elements have `datetime` attribute for accessibility

## Tasks / Subtasks

- [x] Task 1: Create TimelineItem.razor in Components/Shared/ (AC: 1-8)
  - [x] Create component with required parameters
  - [x] Add vertical line with border-l-2 styling
  - [x] Add dot marker with proper positioning
  - [x] Display period with <time> element and datetime attribute
  - [x] Display role title with prominent styling
  - [x] Display company name with secondary styling
  - [x] Display role description

- [x] Task 2: Ensure proper accessibility (AC: 7, 8)
  - [x] Use semantic HTML structure
  - [x] Add datetime attribute to <time> element
  - [x] Ensure proper contrast ratios

## Dev Notes

### Architecture Requirements
- Component location: `Components/Shared/TimelineItem.razor`
- Must use `[Parameter, EditorRequired]` for required props
- Follow existing component patterns from ProjectCard.razor and SkillBadge.razor
- Use only constrained B&W palette

### Component Parameters
- `Period`: string (e.g., "2022 - Present") - required
- `DateTimeValue`: string (ISO date for datetime attribute, e.g., "2022-01") - required
- `Role`: string (job title) - required
- `Company`: string (company name) - required
- `Description`: string (brief description) - required

### Project Structure Notes
- Will be rendered inside TimelineSection.razor
- Follows shared component pattern like SkillBadge and ProjectCard
- Should be rendered as `<li>` element inside parent `<ul>`

### References
- [Source: _bmad-output/planning-artifacts/architecture.md#Component Patterns]
- [Source: _bmad-output/planning-artifacts/epics.md#Story 6.2]

## Dev Agent Record

### Agent Model Used
Claude Opus 4.5 (claude-opus-4-5-20251101)

### Completion Notes List
- Created TimelineItem.razor with all acceptance criteria met
- Uses semantic `<li>` element with `<time>` datetime attribute
- Fixed vertical line to use border-l-2 per AC1 during code review

### File List
- BhavanPortfolio/Components/Shared/TimelineItem.razor (created)
