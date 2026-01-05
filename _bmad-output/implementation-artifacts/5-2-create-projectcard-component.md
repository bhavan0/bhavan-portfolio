# Story 5.2: Create ProjectCard Component

Status: done

## Story

As a **visitor**,
I want **to see project details in a clear card format**,
So that **I can understand what was built and access the code**.

## Acceptance Criteria

1. **AC1**: The card displays a screenshot/visual (`aspect-video object-cover`)
2. **AC2**: The card shows project title (`text-xl font-semibold`)
3. **AC3**: The card shows project description
4. **AC4**: Technology tags are displayed (reusing SkillBadge or similar styling)
5. **AC5**: GitHub link is prominent with arrow icon (`→`)
6. **AC6**: Live demo link is shown when available (FR19)
7. **AC7**: The card has proper styling (`bg-gray-800 rounded-lg overflow-hidden`)
8. **AC8**: Hover effect is implemented (`hover:shadow-lg hover:-translate-y-1 transition-all duration-200`)
9. **AC9**: The card uses semantic `<article>` with proper heading and descriptive image `alt`

## Tasks / Subtasks

- [x] **Task 1: Create ProjectCard.razor Component** (AC: 1-9)
  - [x] 1.1: Create file at `Components/Shared/ProjectCard.razor`
  - [x] 1.2: Define component parameters with `[Parameter]` attributes:
    - Title (EditorRequired)
    - Description (EditorRequired)
    - ImageUrl (EditorRequired)
    - ImageAlt (EditorRequired)
    - GitHubUrl (EditorRequired)
    - DemoUrl (nullable, optional)
    - Technologies (List<string>, EditorRequired)
  - [x] 1.3: Create outer `<article>` element with proper styling
  - [x] 1.4: Apply card background `bg-white dark:bg-gray-800` and rounded corners `rounded-lg`
  - [x] 1.5: Add `overflow-hidden` for image containment
  - [x] 1.6: Add hover effects: `hover:shadow-lg hover:-translate-y-1 transition-all duration-200`

- [x] **Task 2: Add Project Image Section** (AC: 1, 9)
  - [x] 2.1: Add image container with `aspect-video` aspect ratio
  - [x] 2.2: Apply `object-cover` for proper image scaling
  - [x] 2.3: Set descriptive `alt` attribute from parameter
  - [x] 2.4: Add placeholder image support for missing images

- [x] **Task 3: Add Project Content Section** (AC: 2, 3)
  - [x] 3.1: Add content padding `p-6`
  - [x] 3.2: Add title with `<h3>` and styling `text-xl font-semibold text-black dark:text-white`
  - [x] 3.3: Add description with appropriate text styling `text-gray-600 dark:text-gray-400 mt-2`
  - [x] 3.4: Apply proper spacing between elements

- [x] **Task 4: Add Technology Tags Section** (AC: 4)
  - [x] 4.1: Create flex container for technology tags `flex flex-wrap gap-2 mt-4`
  - [x] 4.2: Render technology tags using similar styling to SkillBadge
  - [x] 4.3: Style tags: `rounded-full px-2 py-1 text-xs font-medium bg-gray-100 dark:bg-gray-700`

- [x] **Task 5: Add Action Links Section** (AC: 5, 6)
  - [x] 5.1: Create links container with flex layout `flex items-center gap-4 mt-4`
  - [x] 5.2: Add GitHub link with arrow icon: "View Code →"
  - [x] 5.3: Style link: `text-gray-600 dark:text-gray-400 hover:text-black dark:hover:text-white`
  - [x] 5.4: Conditionally render Demo link when DemoUrl is provided
  - [x] 5.5: Add `target="_blank" rel="noopener noreferrer"` for external links
  - [x] 5.6: Ensure links have proper focus indicators

- [x] **Task 6: Update ProjectsSection to Use ProjectCard** (AC: all)
  - [x] 6.1: Replace placeholder divs in ProjectsSection.razor with ProjectCard components
  - [x] 6.2: Pass sample project data to ProjectCard components
  - [x] 6.3: Verify grid layout still works with actual cards

- [x] **Task 7: Build and Test** (AC: all)
  - [x] 7.1: Run `dotnet build` successfully (0 errors, 0 warnings)
  - [x] 7.2: Verify card displays correctly in both themes
  - [x] 7.3: Verify hover effects work (elevation + shadow)
  - [x] 7.4: Verify responsive behavior
  - [x] 7.5: Verify links open correctly
  - [x] 7.6: Verify image aspect ratio maintained

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document:**

**File Location:**
- ProjectCard component: `Components/Shared/ProjectCard.razor`

**Component Parameters Pattern:**
```csharp
// Required parameters
[Parameter, EditorRequired] public string Title { get; set; } = "";

// Optional parameters with default
[Parameter] public string? DemoUrl { get; set; }
```

**Styling Requirements:**
- Constrained B&W palette only
- Dark mode via Tailwind `dark:` variants

### From UX Design Specification

**Card Design:**
```
┌──────────────────────┐
│    [Screenshot]      │ ← aspect-video, object-cover
│                      │
├──────────────────────┤
│ Project Title        │ ← text-xl font-semibold
│ Description text     │ ← text-gray-400
│                      │
│ [C#] [Blazor] [API]  │ ← tech tags
│                      │
│ View Code → Demo →   │ ← links with arrows
└──────────────────────┘
```

**Card Styling:**
- Background: `bg-white dark:bg-gray-800`
- Border radius: `rounded-lg`
- Shadow on hover: `hover:shadow-lg`
- Elevation on hover: `hover:-translate-y-1`
- Transition: `transition-all duration-200`
- Content padding: `p-6`

**Image Section:**
- Aspect ratio: `aspect-video` (16:9)
- Scaling: `object-cover`
- No overflow: contained by `overflow-hidden` on card

**Link Styling:**
- Base: `text-gray-600 dark:text-gray-400`
- Hover: `hover:text-black dark:hover:text-white`
- Arrow suffix: `→` character
- External links: `target="_blank" rel="noopener noreferrer"`

### FRs Addressed

- **FR16**: Visitors can see project title, description, and technologies used
- **FR17**: Visitors can view a screenshot/visual for each project
- **FR18**: Visitors can access the GitHub repository link
- **FR19**: Visitors can access live demo links when available
- **FR20**: Visitors can see visual feedback when interacting with project cards

### Accessibility Requirements

- Use `<article>` for semantic project card structure
- `<h3>` for project title (proper heading hierarchy under section h2)
- Descriptive `alt` text for images
- Focus indicators on links
- Proper link text (not "click here")
- External links announce as such to screen readers

### References

- [Source: epics.md#Story-5.2] - Acceptance criteria
- [Source: architecture.md#Component-Structure] - File organization
- [Source: ux-design-specification.md#ProjectCard] - Component specification
- [Source: prd.md#Projects-Section] - FR16-FR20

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5

### Debug Log References

None - implementation proceeded without errors.

### Completion Notes List

1. **ProjectCard.razor Created (AC1-AC9):**
   - Created at `Components/Shared/ProjectCard.razor`
   - Uses `<article>` semantic element
   - All required parameters with `[Parameter, EditorRequired]`
   - Optional `DemoUrl` as nullable string
   - Technologies as `IEnumerable<string>`

2. **Image Section (AC1, AC9):**
   - `aspect-video` container with `overflow-hidden`
   - Image with `object-cover` for proper scaling
   - Alt text from parameter for accessibility

3. **Content Section (AC2, AC3):**
   - Padding `p-6`
   - Title with `<h3>` and `text-xl font-semibold`
   - Description with `text-gray-600 dark:text-gray-400 mt-2`
   - Added `line-clamp-3` for description truncation

4. **Technology Tags (AC4):**
   - Flex container: `flex flex-wrap gap-2 mt-4`
   - Tags styled: `rounded-full px-2 py-1 text-xs font-medium`
   - Added border for better visibility

5. **Action Links (AC5, AC6):**
   - GitHub link always shown with "View Code →"
   - Demo link conditionally rendered when DemoUrl provided
   - External links: `target="_blank" rel="noopener noreferrer"`
   - Focus indicators with ring styling

6. **Hover Effects (AC8):**
   - `hover:shadow-lg hover:-translate-y-1 transition-all duration-200`

7. **ProjectsSection Updated:**
   - Replaced placeholder cards with ProjectCard components
   - Added ProjectData class for data management
   - Sample data for 3 projects

8. **Build Verified:**
   - `dotnet build` succeeded with 0 errors, 0 warnings

### Change Log

- 2026-01-05: Story 5.2 implementation - Created ProjectCard component and updated ProjectsSection

### File List

**Created:**
- `BhavanPortfolio/Components/Shared/ProjectCard.razor`
- `BhavanPortfolio/wwwroot/assets/images/projects/` (directory)

**Modified:**
- `BhavanPortfolio/Components/Sections/ProjectsSection.razor` - Updated to use ProjectCard
