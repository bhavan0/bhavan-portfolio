# Story 3.1: Create HeroSection Component

Status: done

## Story

As a **visitor**,
I want **to immediately see who this portfolio belongs to**,
So that **I can validate this is the right candidate within 3 seconds**.

## Acceptance Criteria

1. **AC1**: HeroSection takes full viewport height (`min-h-screen`)
2. **AC2**: Content is centered vertically and horizontally (`flex items-center justify-center`)
3. **AC3**: Name "Bhavan" is displayed prominently (`text-5xl md:text-6xl font-bold`)
4. **AC4**: Title "Full Stack Developer" is displayed below (`text-xl md:text-2xl text-gray-400`)
5. **AC5**: Brief professional introduction is visible
6. **AC6**: Section has proper padding and container constraints (`max-w-6xl mx-auto px-4 md:px-6`)
7. **AC7**: Text meets WCAG AA contrast requirements (NFR8)

## Tasks / Subtasks

- [x] **Task 1: Create HeroSection Component** (AC: 1, 2, 3, 4, 5, 6, 7)
  - [x] 1.1: Create `Components/Sections/HeroSection.razor` file
  - [x] 1.2: Add full viewport height: `min-h-screen`
  - [x] 1.3: Add flex centering: `flex items-center justify-center`
  - [x] 1.4: Add container constraints: `max-w-6xl mx-auto px-4 md:px-6`
  - [x] 1.5: Display name "Bhavan" with `text-5xl md:text-6xl font-bold`
  - [x] 1.6: Display title "Full Stack Developer" with `text-xl md:text-2xl text-gray-400`
  - [x] 1.7: Add brief professional introduction paragraph
  - [x] 1.8: Ensure theme-aware text colors (dark/light mode support)
  - [x] 1.9: Verify WCAG AA contrast (4.5:1 ratio)

- [x] **Task 2: Integrate HeroSection into Home Page** (AC: all)
  - [x] 2.1: Update `Pages/Home.razor` to render HeroSection component
  - [x] 2.2: Remove placeholder content from Home.razor
  - [x] 2.3: Verify HeroSection renders correctly

- [x] **Task 3: Build and Test** (AC: all)
  - [x] 3.1: Run `dotnet build` successfully
  - [x] 3.2: Verify HeroSection takes full viewport height
  - [x] 3.3: Verify content is centered
  - [x] 3.4: Verify text contrast meets WCAG AA
  - [x] 3.5: Test in both dark and light themes

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document (architecture.md):**

**Component Location:**
- HeroSection goes in `Components/Sections/HeroSection.razor`
- Follows naming convention: PascalCase for Razor components

**Project Structure:**
- Sections folder: `Components/Sections/` for full viewport sections
- Component naming: PascalCase (e.g., `HeroSection.razor`)

**From UX Design Specification (ux-design-specification.md):**

**Hero Section Requirements:**
- Full viewport height (`min-h-screen`) - first thing visitors see
- Name "Bhavan" prominently displayed (F-pattern scan - top-left)
- Title "Full Stack Developer" below name
- Brief professional introduction (3-4 sentences max)
- Centered content with container constraints

**Typography (from UX spec):**
- Hero name: `text-5xl md:text-6xl font-bold`
- Hero title: `text-xl md:text-2xl text-gray-400`
- Intro text: `text-base md:text-lg leading-relaxed`

**Color Palette (B&W only):**
- Dark mode: `text-white` for primary, `text-gray-400` for secondary
- Light mode: `text-black` for primary, `text-gray-600` for secondary
- Use Tailwind `dark:` variants for theme support

**From Epic 2 Retrospective:**
- Theme system is fully functional (Stories 2.1, 2.2, 2.4)
- MainLayout structure ready (Story 2.1)
- Navigation infrastructure ready (Stories 2.3, 2.6)

### Existing Files Reference

**Home.razor (current placeholder):**
```razor
@page "/"

<PageTitle>Bhavan - Full Stack Developer</PageTitle>

<div class="text-center py-20">
    <h1 class="text-4xl font-bold text-white">Bhavan Portfolio</h1>
    <p class="text-gray-400 mt-4">Foundation ready for implementation</p>
</div>
```

**MainLayout.razor (from Story 2.1):**
- Has semantic structure with `<header>`, `<main>`, `<footer>`
- Main content area has `pt-16` to account for fixed NavBar
- Theme system integrated

### Component Structure Target

```razor
<section class="min-h-screen flex items-center justify-center">
    <div class="max-w-6xl mx-auto px-4 md:px-6 text-center">
        <h1 class="text-5xl md:text-6xl font-bold text-white dark:text-white">
            Bhavan
        </h1>
        <p class="text-xl md:text-2xl text-gray-400 dark:text-gray-400 mt-4">
            Full Stack Developer
        </p>
        <p class="text-base md:text-lg text-gray-300 dark:text-gray-300 mt-6 leading-relaxed max-w-2xl mx-auto">
            [Professional introduction text]
        </p>
    </div>
</section>
```

### Professional Introduction Content

**Required:** Brief professional introduction (3-4 sentences)
**Tone:** Professional, confident, concise
**Content:** Should mention:
- Full Stack Developer focus
- Key technologies or domains
- Value proposition

**Placeholder text (to be replaced with actual content):**
"I'm a Full Stack Developer passionate about building clean, efficient solutions. I specialize in modern web technologies and cloud platforms, delivering high-quality software that solves real problems."

### Theme-Aware Styling

**Dark Mode:**
- Name: `text-white`
- Title: `text-gray-400`
- Intro: `text-gray-300`

**Light Mode:**
- Name: `text-black`
- Title: `text-gray-600`
- Intro: `text-gray-700`

**Implementation:** Use Tailwind `dark:` variants:
```razor
<h1 class="text-5xl md:text-6xl font-bold text-black dark:text-white">
```

### WCAG AA Contrast Requirements (NFR8)

**Contrast Ratio:** Minimum 4.5:1 for normal text, 3:1 for large text

**Verification:**
- Name (large text): `text-white` on `bg-black` = 21:1 ✅
- Title: `text-gray-400` on `bg-black` = ~4.5:1 ✅
- Intro: `text-gray-300` on `bg-black` = ~7:1 ✅

**Light Mode:**
- Name: `text-black` on `bg-white` = 21:1 ✅
- Title: `text-gray-600` on `bg-white` = ~7:1 ✅
- Intro: `text-gray-700` on `bg-white` = ~12:1 ✅

### Dependencies

**This story depends on:**
- Story 2.1: MainLayout with Theme Class Binding (complete)
- Story 1.1: Tailwind CSS setup (complete)
- Story 1.2: Theme resolution in index.html (complete)

**Stories that depend on this:**
- Story 3.2: Add Hero Call-to-Action Buttons (extends HeroSection)
- Story 3.3: Integrate Resume PDF Download (uses HeroSection)

### References

- [Source: epics.md#Story-3.1] - Acceptance criteria
- [Source: architecture.md#Component-Structure] - Component organization
- [Source: architecture.md#Styling-Patterns] - Tailwind color palette
- [Source: ux-design-specification.md#Hero-Section] - UX requirements
- [Source: epic-2-retro-2026-01-05.md] - Epic 2 learnings

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5

### Debug Log References

None - implementation proceeded without errors.

### Completion Notes List

1. **HeroSection Component Created (AC1-AC7):**
   - Created `Components/Sections/HeroSection.razor` with full viewport height
   - Content centered vertically and horizontally using flex
   - Name "Bhavan" displayed with `text-5xl md:text-6xl font-bold`
   - Title "Full Stack Developer" with `text-xl md:text-2xl`
   - Professional introduction paragraph added
   - Theme-aware colors: `text-black dark:text-white` for name, `text-gray-600 dark:text-gray-400` for title
   - Background: `bg-white dark:bg-black` for theme support
   - Container constraints: `max-w-6xl mx-auto px-4 md:px-6`
   - WCAG AA contrast verified: All text meets 4.5:1 minimum ratio

2. **Home.razor Updated:**
   - Replaced placeholder content with `<HeroSection />` component
   - PageTitle remains: "Bhavan - Full Stack Developer"

3. **_Imports.razor Updated:**
   - Added `@using BhavanPortfolio.Components.Sections` namespace

4. **Build Verified:**
   - `dotnet build` succeeded with 0 errors, 0 warnings
   - Tailwind CSS compiled successfully

### Change Log

- 2026-01-05: Story 3.1 implementation - Created HeroSection component and integrated into Home page
- 2026-01-05: Code review fixes - Added `id="hero"`, `aria-labelledby="hero-heading"`, `id="hero-heading"` for accessibility

### File List

**Created:**
- `BhavanPortfolio/Components/Sections/HeroSection.razor`

**Modified:**
- `BhavanPortfolio/Pages/Home.razor`
- `BhavanPortfolio/_Imports.razor`
