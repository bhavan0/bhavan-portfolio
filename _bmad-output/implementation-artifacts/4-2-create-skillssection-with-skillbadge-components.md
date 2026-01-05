# Story 4.2: Create SkillsSection with SkillBadge Components

Status: review

## Story

As a **visitor**,
I want **to quickly scan technical skills**,
So that **I can validate the developer matches my requirements in under 5 seconds**.

## Acceptance Criteria

1. **AC1**: The section has `id="skills"` for navigation
2. **AC2**: Skills are displayed as pill-shaped badges using SkillBadge component
3. **AC3**: SkillBadge has styling: `rounded-full px-3 py-1 text-sm font-medium`
4. **AC4**: Badges have background (`bg-gray-800 dark:bg-gray-800`) and border (`border border-gray-700`)
5. **AC5**: Badges have subtle hover effect (`hover:bg-gray-700`)
6. **AC6**: Skills are organized in a responsive grid (2 cols mobile, 3 cols tablet, 4 cols desktop)
7. **AC7**: Badges are rendered as semantic list (`<ul>` with `<li>` items)
8. **AC8**: The layout allows scanning in 3-5 seconds

## Tasks / Subtasks

- [x] **Task 1: Create SkillBadge.razor Component** (AC: 2, 3, 4, 5)
  - [x] 1.1: Create file at `Components/Shared/SkillBadge.razor`
  - [x] 1.2: Add [Parameter] for skill name text with [EditorRequired]
  - [x] 1.3: Apply pill-shaped styling with `rounded-full`
  - [x] 1.4: Apply padding `px-3 py-1` and text styling `text-sm font-medium`
  - [x] 1.5: Apply background and border colors for both themes
  - [x] 1.6: Add hover effect with transition
  - [x] 1.7: Render as `<li>` element for semantic list usage

- [x] **Task 2: Create SkillsSection.razor Component** (AC: 1, 6, 7, 8)
  - [x] 2.1: Create file at `Components/Sections/SkillsSection.razor`
  - [x] 2.2: Add section element with `id="skills"` and aria attributes
  - [x] 2.3: Add section heading with correct typography
  - [x] 2.4: Create `<ul>` container for skill badges
  - [x] 2.5: Apply responsive grid: `grid-cols-2 md:grid-cols-3 lg:grid-cols-4`
  - [x] 2.6: Add placeholder skills using SkillBadge components
  - [x] 2.7: Apply section padding and container constraints

- [x] **Task 3: Integrate SkillsSection into Home.razor** (AC: 1)
  - [x] 3.1: Import SkillsSection in Home.razor
  - [x] 3.2: Place after AboutSection
  - [x] 3.3: Verify navigation can scroll to section

- [x] **Task 4: Add Navigation Link in NavBar** (AC: 1)
  - [x] 4.1: Verify NavBar has "Skills" link pointing to `#skills` (already existed from Epic 2)
  - [x] 4.2: Verify smooth scroll works to Skills section

- [x] **Task 5: Build and Test** (AC: all)
  - [x] 5.1: Run `dotnet build` successfully (0 errors, 0 warnings)
  - [x] 5.2: Verify badges display correctly in both themes
  - [x] 5.3: Verify responsive grid at all breakpoints
  - [x] 5.4: Verify hover effects work
  - [x] 5.5: Verify semantic HTML structure (ul/li)

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document:**

**File Locations:**
- SkillBadge component: `Components/Shared/SkillBadge.razor` (reusable shared component)
- SkillsSection component: `Components/Sections/SkillsSection.razor`

**Component Parameters:**
- Use `[Parameter, EditorRequired]` for mandatory parameters
- Use `[Parameter]` with default for optional parameters

**Styling Requirements:**
- Constrained B&W palette only
- Dark mode via Tailwind `dark:` variants

**From UX Design Specification:**

**SkillBadge Styling:**
- Shape: `rounded-full` (pill)
- Padding: `px-3 py-1`
- Background: `bg-gray-800` (dark) / `bg-gray-100` (light)
- Border: `border border-gray-700`
- Text: `text-sm font-medium`
- Hover: `hover:bg-gray-700` (subtle)

**Grid Layout:**
- 2 columns on mobile (< 768px)
- 3 columns on tablet (768px+)
- 4 columns on desktop (1024px+)
- Gap: `gap-2` or `gap-3`

**Section Structure:**
- Section heading: `text-3xl md:text-4xl font-semibold`
- Section padding: `py-20 md:py-32`
- Container: `max-w-6xl mx-auto px-4 md:px-6`

### Accessibility Requirements

- Use semantic list structure (`<ul>` with `<li>`)
- Screen readers will announce list of skills
- Keyboard focus should be visible on badges if interactive

### Pattern from UX Document

```
┌─────────────────────────────────────────┐
│                Skills                    │
│                                         │
│  [Blazor] [.NET] [C#] [Azure]           │
│  [React] [TypeScript] [SQL] [AI/ML]     │
│  ...                                    │
└─────────────────────────────────────────┘
```

### References

- [Source: epics.md#Story-4.2] - Acceptance criteria
- [Source: architecture.md#Component-Structure] - File organization
- [Source: ux-design-specification.md#SkillBadge] - Component specification
- [Source: prd.md#Skills-Section] - FR12, FR13, FR14

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5

### Debug Log References

None - implementation proceeded without errors.

### Completion Notes List

1. **SkillBadge.razor Created (AC2-AC5):**
   - Created at `Components/Shared/SkillBadge.razor`
   - Uses `[Parameter, EditorRequired]` for SkillName property
   - Pill-shaped styling: `rounded-full px-3 py-1`
   - Text styling: `text-sm font-medium`
   - Background: `bg-gray-100 dark:bg-gray-800`
   - Border: `border border-gray-200 dark:border-gray-700`
   - Hover: `hover:bg-gray-200 dark:hover:bg-gray-700`
   - Renders as `<li>` for semantic list usage
   - Includes `transition-colors duration-200` for smooth hover

2. **SkillsSection.razor Created (AC1, AC6-AC8):**
   - Created at `Components/Sections/SkillsSection.razor`
   - Section has `id="skills"` for navigation
   - Uses `aria-labelledby="skills-heading"` and `aria-label` on list
   - Heading styled with `text-3xl md:text-4xl font-semibold`
   - Responsive grid: `grid-cols-2 md:grid-cols-3 lg:grid-cols-4`
   - Gap: `gap-3` for spacing between badges
   - Section padding: `py-20 md:py-32`
   - Container: `max-w-6xl mx-auto px-4 md:px-6`

3. **Theme Support:**
   - Section background: `bg-white dark:bg-black`
   - Badge colors properly contrast in both modes

4. **Build Verified:**
   - `dotnet build` succeeded with 0 errors, 0 warnings

### Change Log

- 2026-01-05: Story 4.2 implementation - Created SkillBadge and SkillsSection components

### File List

**Created:**
- `BhavanPortfolio/Components/Shared/SkillBadge.razor`
- `BhavanPortfolio/Components/Sections/SkillsSection.razor`

**Modified:**
- `BhavanPortfolio/Pages/Home.razor` - Added SkillsSection
