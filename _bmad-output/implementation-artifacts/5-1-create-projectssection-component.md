# Story 5.1: Create ProjectsSection Component

Status: done

## Story

As a **visitor**,
I want **to see a showcase of projects**,
So that **I can validate the developer's practical experience**.

## Acceptance Criteria

1. **AC1**: The section has `id="projects"` for navigation
2. **AC2**: The section heading is properly styled (`text-3xl md:text-4xl font-semibold`)
3. **AC3**: Projects are displayed in a responsive grid (1 col mobile, 2 cols tablet, 3 cols desktop)
4. **AC4**: The section has proper padding (`py-20 md:py-32`)
5. **AC5**: At least 3 projects are displayed (FR15 - placeholder data acceptable until Story 5.3)
6. **AC6**: The grid has appropriate gap spacing (`gap-6`)
7. **AC7**: Section uses semantic HTML (`<section>`, `<h2>`, `<ul>` or `<div>` grid)
8. **AC8**: Section has proper `aria-labelledby` accessibility attributes

## Tasks / Subtasks

- [x] **Task 1: Create ProjectsSection.razor Component** (AC: 1, 2, 4, 7, 8)
  - [x] 1.1: Create file at `Components/Sections/ProjectsSection.razor`
  - [x] 1.2: Add section element with `id="projects"` and `aria-labelledby="projects-heading"`
  - [x] 1.3: Add section heading with `id="projects-heading"` and typography `text-3xl md:text-4xl font-semibold`
  - [x] 1.4: Apply section padding `py-20 md:py-32`
  - [x] 1.5: Apply container constraints `max-w-6xl mx-auto px-4 md:px-6`
  - [x] 1.6: Apply theme-aware background colors `bg-gray-50 dark:bg-gray-900` (alternate from previous section)

- [x] **Task 2: Create Responsive Project Grid Container** (AC: 3, 5, 6)
  - [x] 2.1: Add grid container with responsive columns `grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3`
  - [x] 2.2: Apply gap spacing `gap-6`
  - [x] 2.3: Add 3 placeholder `<div>` cards for layout testing (to be replaced by ProjectCard in Story 5.2)
  - [x] 2.4: Placeholder cards should show project title placeholder and basic styling

- [x] **Task 3: Integrate ProjectsSection into Home.razor** (AC: 1)
  - [x] 3.1: Import ProjectsSection in Home.razor
  - [x] 3.2: Place after SkillsSection in the page layout order
  - [x] 3.3: Verify section ordering: Hero > About > Skills > Projects

- [x] **Task 4: Verify Navigation Integration** (AC: 1)
  - [x] 4.1: Verify NavBar has "Projects" link pointing to `#projects`
  - [x] 4.2: Verify smooth scroll works to Projects section
  - [x] 4.3: Verify mobile menu includes Projects navigation

- [x] **Task 5: Build and Test** (AC: all)
  - [x] 5.1: Run `dotnet build` successfully (0 errors, 0 warnings)
  - [x] 5.2: Verify section displays correctly in both dark and light themes
  - [x] 5.3: Verify responsive grid at mobile, tablet, and desktop breakpoints
  - [x] 5.4: Verify section accessible via navigation scroll
  - [x] 5.5: Verify semantic HTML structure

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document:**

**File Location:**
- ProjectsSection component: `Components/Sections/ProjectsSection.razor`

**Project Structure:**
```
Components/
├── Sections/
│   ├── HeroSection.razor     ✅ (exists)
│   ├── AboutSection.razor    ✅ (exists)
│   ├── SkillsSection.razor   ✅ (exists)
│   ├── ProjectsSection.razor ← THIS STORY
│   ├── TimelineSection.razor (Epic 6)
│   └── ContactSection.razor  (Epic 6)
```

**Component Parameters:**
- Use `[Parameter, EditorRequired]` for mandatory parameters
- Use `[Parameter]` with default for optional parameters

**Styling Requirements:**
- Constrained B&W palette only (black, white, gray-50 through gray-900)
- Dark mode via Tailwind `dark:` variants
- No colors outside the defined palette

### From UX Design Specification

**Section Layout:**
- Section padding: `py-20 md:py-32` (80-128px vertical)
- Container: `max-w-6xl mx-auto px-4 md:px-6`
- Background alternating between sections for visual separation

**Project Grid:**
- 1 column on mobile (< 640px)
- 2 columns on tablet (640px - 1024px)
- 3 columns on desktop (> 1024px)
- Gap: `gap-6` (24px)

**Section Heading:**
- Typography: `text-3xl md:text-4xl font-semibold`
- Centered: `text-center`
- Margin below: `mb-12` or `mb-16`

### FRs Addressed

- **FR15**: Visitors can view at least 3 project showcases
- **FR16-20**: Will be addressed by ProjectCard component (Story 5.2)

### Accessibility Requirements

- Section landmark with proper labeling
- `aria-labelledby` pointing to heading
- Semantic list/grid structure for projects
- Focus indicators on interactive elements (future ProjectCards)

### Previous Story Learnings (Epic 4)

From Story 4.2 (SkillsSection):
- Use alternating background colors between sections
- Ensure section `id` matches NavBar link targets
- Apply consistent container constraints across all sections
- Test smooth scroll navigation after integration

### Pattern Reference

```
┌─────────────────────────────────────────┐
│               Projects                   │
│                                         │
│  ┌─────────┐  ┌─────────┐  ┌─────────┐  │
│  │ Project │  │ Project │  │ Project │  │
│  │   Card  │  │   Card  │  │   Card  │  │
│  └─────────┘  └─────────┘  └─────────┘  │
│                                         │
└─────────────────────────────────────────┘
```

### References

- [Source: epics.md#Story-5.1] - Acceptance criteria
- [Source: architecture.md#Component-Structure] - File organization
- [Source: ux-design-specification.md#ProjectsSection] - Component specification
- [Source: prd.md#Projects-Section] - FR15-FR20

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5

### Debug Log References

None - implementation proceeded without errors.

### Completion Notes List

1. **ProjectsSection.razor Created (AC1-AC8):**
   - Created at `Components/Sections/ProjectsSection.razor`
   - Section has `id="projects"` for navigation
   - Uses `aria-labelledby="projects-heading"` for accessibility
   - Heading styled with `text-3xl md:text-4xl font-semibold text-center`
   - Section padding: `py-20 md:py-32`
   - Container: `max-w-6xl mx-auto px-4 md:px-6`
   - Alternating background: `bg-gray-50 dark:bg-gray-900`

2. **Responsive Grid Implementation (AC3, AC5, AC6):**
   - Grid: `grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3`
   - Gap: `gap-6`
   - 3 placeholder cards with hover effects

3. **Placeholder Cards:**
   - Article semantic structure
   - Aspect-video placeholder image area
   - Title, description, tech tags, and link placeholders
   - Hover effects: `hover:shadow-lg hover:-translate-y-1 transition-all duration-200`

4. **Navigation Integration:**
   - NavBar already had "Projects" link pointing to `#projects`
   - Mobile menu already includes Projects navigation

5. **Build Verified:**
   - `dotnet build` succeeded with 0 errors, 0 warnings

### Change Log

- 2026-01-05: Story 5.1 implementation - Created ProjectsSection component with placeholder cards

### File List

**Created:**
- `BhavanPortfolio/Components/Sections/ProjectsSection.razor`

**Modified:**
- `BhavanPortfolio/Pages/Home.razor` - Added ProjectsSection
