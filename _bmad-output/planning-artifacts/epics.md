---
stepsCompleted: [1, 2, 3, 4]
inputDocuments:
  - "_bmad-output/planning-artifacts/prd.md"
  - "_bmad-output/planning-artifacts/architecture.md"
  - "_bmad-output/planning-artifacts/ux-design-specification.md"
workflowType: 'epics-and-stories'
lastStep: 4
status: 'complete'
project_name: 'bhavan-portfolio'
user_name: 'Bhavan'
date: '2026-01-04'
completionDate: '2026-01-04'
validationResults:
  frCoverage: '45/45 (100%)'
  nfrCoverage: '19/19 (100%)'
  totalEpics: 7
  totalStories: 28
  dependencyCheck: 'passed'
  architectureCompliance: 'passed'
---

# bhavan-portfolio - Epic Breakdown

## Overview

This document provides the complete epic and story breakdown for bhavan-portfolio, decomposing the requirements from the PRD, UX Design if it exists, and Architecture requirements into implementable stories.

## Requirements Inventory

### Functional Requirements

**Navigation & Header**
- FR1: Visitors can see a sticky header that remains visible while scrolling
- FR2: Visitors can navigate to any section using header navigation links
- FR3: Visitors can download the resume PDF in one click from the header
- FR4: Visitors can toggle between dark and light themes
- FR5: Mobile visitors can access navigation through a hamburger menu
- FR6: Mobile visitors can access resume download from the mobile menu

**Hero Section**
- FR7: Visitors can see the developer's name prominently displayed
- FR8: Visitors can see the developer's title/role (Full Stack Developer)
- FR9: Visitors can read a brief professional introduction

**About Section**
- FR10: Visitors can read a personal/professional summary
- FR11: Visitors can understand the developer's background and approach

**Skills Section**
- FR12: Visitors can identify key skills through scannable visual organization
- FR13: Visitors can see skills organized in a scannable visual format
- FR14: Visitors can identify primary technology competencies

**Projects Section**
- FR15: Visitors can view at least 3 project showcases
- FR16: Visitors can see project title, description, and technologies used for each project
- FR17: Visitors can view a screenshot or visual for each project
- FR18: Visitors can access the GitHub repository link for each project
- FR19: Visitors can access live demo links when available for projects
- FR20: Visitors can see visual feedback when interacting with project cards

**Timeline Section**
- FR21: Visitors can view work experience in chronological order
- FR22: Visitors can see role titles, companies, and timeframes
- FR23: Visitors can understand career progression

**Contact Section**
- FR24: Visitors can access the developer's email address
- FR25: Visitors can access the developer's LinkedIn profile
- FR26: Visitors can access the developer's GitHub profile

**Footer**
- FR27: Visitors can access the portfolio's source code repository
- FR28: Visitors can access social links from the footer

**Theme & Appearance**
- FR29: The site can default to dark mode on initial visit
- FR30: The site can persist theme preference across sessions
- FR31: The site can detect and respect system theme preference as fallback
- FR32: The site can resolve theme using priority: stored preference > system preference > dark default
- FR33: The theme toggle can provide immediate visual transition feedback

**Loading Experience**
- FR34: Visitors can see styled content within 500ms of page request
- FR35: Visitors can see a progressive content reveal during WASM initialization
- FR36: The loading state can maintain the B&W aesthetic
- FR37: Visitors can see a fallback message if the application fails to initialize

**Responsive Design**
- FR38: The site can adapt layout for mobile devices (< 640px)
- FR39: The site can adapt layout for tablet devices (640-1024px)
- FR40: The site can adapt layout for desktop devices (> 1024px)
- FR41: Touch targets can meet minimum 44px size on mobile

**Navigation Experience**
- FR42: Visitors can experience smooth scroll navigation between sections

**SEO & Discoverability**
- FR43: The site can provide meta tags for search engines
- FR44: The site can provide OpenGraph tags for social sharing
- FR45: The site can use semantic HTML structure

### NonFunctional Requirements

**Performance**
- NFR1: Lighthouse Performance Score >= 90 (Lighthouse audit on desktop)
- NFR2: First Contentful Paint (FCP) < 1.5s (Lighthouse/WebPageTest)
- NFR3: Largest Contentful Paint (LCP) < 2.5s (Core Web Vitals)
- NFR4: Time to Interactive (TTI) < 5s (Lighthouse - WASM-realistic)
- NFR5: Styled Loading Shell < 500ms (Manual testing)
- NFR6: Theme Toggle Response Immediate (<100ms perceived instant)
- NFR7: Smooth Scroll Animation 60fps (No jank during navigation)

**Accessibility**
- NFR8: Color Contrast WCAG AA (4.5:1 text) via automated contrast checker
- NFR9: Keyboard Navigation - All interactive elements reachable via manual testing
- NFR10: Focus Indicators - Visible on all focusable elements via visual inspection
- NFR11: Touch Targets >= 44px on mobile via design review

**Reliability**
- NFR12: WASM Load Failure - Graceful fallback message via error scenario testing
- NFR13: Asset Loading - No broken images or missing resources via visual inspection
- NFR14: Cross-Browser Consistency - Identical experience across supported browsers via browser matrix testing

**Maintainability (Codebase Quality)**
- NFR15: Component Organization - Logical folder structure (Layout/, Sections/, Shared/) via code review
- NFR16: Naming Conventions - Consistent PascalCase for components via code review
- NFR17: Code Cleanliness - No commented-out code, no console.logs via code review
- NFR18: README Documentation - Clear setup and architecture explanation via documentation review
- NFR19: Inline Comments - Key decisions documented via code review

### Additional Requirements

**From Architecture Document:**

- **Starter Template**: `dotnet new blazorwasm -o BhavanPortfolio --framework net10.0` - Epic 1 Story 1 must initialize project with this command
- Bootstrap removal required after project initialization
- Tailwind CSS v4 setup via standalone CLI (no npm dependency)
- MSBuild target integration for Tailwind compilation
- `.nojekyll` file required for GitHub Pages `_framework` folder serving
- `.gitattributes` with `*.js binary` for line ending handling
- GitHub Actions deployment workflow with artifact-based deployment
- Tailwind CLI download in CI pipeline (no npm in CI)

**Theme System Requirements:**
- Theme resolution priority: localStorage > system preference > dark default
- Inline script in index.html for flash-free theme application
- Body class approach (`dark`/`light`) with Tailwind `darkMode: 'class'`
- IThemeService interface with InitializeAsync, ToggleThemeAsync, OnThemeChanged event

**Loading Shell Requirements:**
- Static HTML hero matching HeroSection component
- CSS fade transition when Blazor hydrates
- 10-second timeout with fallback message for WASM failure
- `<noscript>` tag for JavaScript-disabled browsers

**Project Structure Requirements:**
- Components/Layout/ for MainLayout, NavBar, Footer
- Components/Sections/ for Hero, About, Skills, Projects, Timeline, Contact
- Components/Shared/ for ThemeToggle, ProjectCard, SkillBadge, TimelineItem, SocialLink
- Services/ for IThemeService, ThemeService, IScrollService, ScrollService
- wwwroot/js/ for theme.js and scroll.js modules

**Naming Convention Requirements:**
- PascalCase for .razor and .cs files
- camelCase for JS modules
- kebab-case for CSS and asset files
- [EditorRequired] attribute for mandatory component parameters

**From UX Design Document:**

- F-pattern layout optimization for recruiter 8-second scan
- Sticky header with backdrop blur effect (`bg-gray-900/95 backdrop-blur-sm`)
- Hero section full viewport height (`min-h-screen`)
- Section padding: `py-20 md:py-32` (80-128px)
- Container max-width: `max-w-6xl mx-auto px-4 md:px-6`
- Mobile hamburger menu with full-screen overlay
- 400-500ms smooth scroll animation with easing
- Constrained B&W palette: black, white, gray-50 through gray-900 only
- Typography: System font stack, text-5xl/6xl for hero name, text-3xl/4xl for section headings
- Button hierarchy: Primary (filled), Secondary (outline), Tertiary (text)
- Card hover effects: `-translate-y-1 shadow-lg transition-all duration-200`
- Focus indicators: `focus:ring-2 focus:ring-white focus:ring-offset-2`
- Reduced motion support: `prefers-reduced-motion` media query
- Skip-to-content link for accessibility
- ARIA labels on navigation and interactive elements

### FR Coverage Map

| FR | Epic | Description |
|----|------|-------------|
| FR1 | Epic 2 | Sticky header visible while scrolling |
| FR2 | Epic 2 | Navigate to sections via header links |
| FR3 | Epic 3 | Resume PDF download from header |
| FR4 | Epic 2 | Dark/light theme toggle |
| FR5 | Epic 2 | Mobile hamburger menu |
| FR6 | Epic 2 | Resume download in mobile menu |
| FR7 | Epic 3 | Developer name displayed |
| FR8 | Epic 3 | Developer title displayed |
| FR9 | Epic 3 | Brief professional intro |
| FR10 | Epic 4 | Personal/professional summary |
| FR11 | Epic 4 | Background and approach |
| FR12 | Epic 4 | Scannable skill organization |
| FR13 | Epic 4 | Visual skill format |
| FR14 | Epic 4 | Primary technology competencies |
| FR15 | Epic 5 | 3+ project showcases |
| FR16 | Epic 5 | Project title, description, tech |
| FR17 | Epic 5 | Project screenshots |
| FR18 | Epic 5 | GitHub repository links |
| FR19 | Epic 5 | Live demo links |
| FR20 | Epic 5 | Project card hover feedback |
| FR21 | Epic 6 | Chronological work experience |
| FR22 | Epic 6 | Role titles, companies, timeframes |
| FR23 | Epic 6 | Career progression |
| FR24 | Epic 6 | Email access |
| FR25 | Epic 6 | LinkedIn profile access |
| FR26 | Epic 6 | GitHub profile access |
| FR27 | Epic 7 | Source code repository link |
| FR28 | Epic 7 | Social links in footer |
| FR29 | Epic 1 | Dark mode default |
| FR30 | Epic 1 | Theme persistence |
| FR31 | Epic 1 | System theme detection |
| FR32 | Epic 1 | Theme resolution priority |
| FR33 | Epic 2 | Theme toggle visual feedback |
| FR34 | Epic 1 | Styled content <500ms |
| FR35 | Epic 1 | Progressive content reveal |
| FR36 | Epic 1 | B&W loading aesthetic |
| FR37 | Epic 1 | WASM failure fallback |
| FR38 | Epic 7 | Mobile layout (<640px) |
| FR39 | Epic 7 | Tablet layout (640-1024px) |
| FR40 | Epic 7 | Desktop layout (>1024px) |
| FR41 | Epic 7 | 44px touch targets |
| FR42 | Epic 2 | Smooth scroll navigation |
| FR43 | Epic 1 | Meta tags for SEO |
| FR44 | Epic 1 | OpenGraph tags |
| FR45 | Epic 1 | Semantic HTML structure |

## Epic List

### Epic 1: Project Foundation & Loading Experience
**Goal:** Visitors see a professional, styled page immediately upon loading - no blank screens or spinners. The B&W aesthetic establishes credibility within 500ms.

**FRs covered:** FR29, FR30, FR31, FR32, FR34, FR35, FR36, FR37, FR43, FR44, FR45
**NFRs addressed:** NFR1-NFR7 (Performance), NFR12 (WASM fallback), NFR15-NFR19 (Maintainability)

**Includes:**
- Blazor WASM project initialization with starter template
- Bootstrap removal + Tailwind CSS v4 setup
- index.html loading shell with static hero HTML
- Theme resolution script (localStorage > system > dark)
- CSS fade transition for Blazor hydration
- WASM fallback message (10s timeout)
- Meta tags and OpenGraph for SEO
- GitHub Actions deployment workflow

---

### Epic 2: Navigation & Theme System
**Goal:** Visitors can navigate smoothly between sections and control their viewing experience with instant theme switching.

**FRs covered:** FR1, FR2, FR4, FR5, FR6, FR33, FR42
**NFRs addressed:** NFR6 (Theme toggle <100ms), NFR7 (60fps scroll), NFR9-NFR10 (Keyboard nav, focus)

**Includes:**
- Sticky header component (NavBar)
- Theme toggle with instant feedback
- ThemeService with IThemeService interface
- Mobile hamburger menu with full-screen overlay
- Smooth scroll navigation (400-500ms eased)
- ScrollService with JS interop
- Keyboard navigation and focus indicators

---

### Epic 3: Hero & Identity Section
**Goal:** Visitors instantly identify who this portfolio belongs to - name, title, and professional intro visible in the first 3 seconds (Rachel's F-pattern scan).

**FRs covered:** FR3, FR7, FR8, FR9
**NFRs addressed:** NFR8 (WCAG AA contrast), NFR11 (44px touch targets)

**Includes:**
- HeroSection component (full viewport)
- Name display (text-5xl/6xl)
- Title/role display
- Professional intro text
- Primary CTA: Resume download (1-click)
- Secondary CTA: View Projects
- Resume PDF asset integration

---

### Epic 4: About & Skills Sections
**Goal:** Visitors validate professional background and technical competencies in a scannable format - Rachel's 3-6 second skills validation.

**FRs covered:** FR10, FR11, FR12, FR13, FR14
**NFRs addressed:** NFR8 (Contrast), NFR11 (Touch targets)

**Includes:**
- AboutSection component
- SkillsSection component
- SkillBadge shared component (pill-shaped badges)
- Scannable badge grid layout
- Responsive column adjustments (2->3->4 columns)

---

### Epic 5: Projects Showcase
**Goal:** Visitors can see proof of work through project showcases with GitHub links for code validation - Marcus's technical deep-dive.

**FRs covered:** FR15, FR16, FR17, FR18, FR19, FR20
**NFRs addressed:** NFR13 (No broken assets), NFR8 (Contrast)

**Includes:**
- ProjectsSection component
- ProjectCard shared component
- Project screenshots/visuals
- GitHub repository links
- Live demo links (where available)
- Hover effects (elevation, shadow)
- Responsive grid (1->2->3 columns)

---

### Epic 6: Timeline & Contact Sections
**Goal:** Visitors understand career progression and have clear paths to connect - completing the full portfolio experience.

**FRs covered:** FR21, FR22, FR23, FR24, FR25, FR26
**NFRs addressed:** NFR8-NFR11 (Accessibility)

**Includes:**
- TimelineSection component
- TimelineItem shared component (vertical timeline)
- Chronological work/education history
- ContactSection component
- SocialLink shared component
- Email, LinkedIn, GitHub links

---

### Epic 7: Footer & Mobile Polish
**Goal:** Complete the professional experience with footer attribution and ensure full mobile parity - Rachel's mobile check passes.

**FRs covered:** FR27, FR28, FR38, FR39, FR40, FR41
**NFRs addressed:** NFR11 (44px touch targets), NFR14 (Cross-browser)

**Includes:**
- Footer component
- "Built with Blazor" colophon
- Social links in footer
- Mobile responsive validation
- Touch target verification (44px minimum)
- Cross-browser testing confirmation

---

### Epic Dependencies

```
Epic 1 (Foundation) -> Independent, enables all others
Epic 2 (Navigation) -> Requires Epic 1
Epic 3 (Hero) -> Requires Epic 1 + 2
Epic 4 (About/Skills) -> Requires Epic 1 + 2
Epic 5 (Projects) -> Requires Epic 1 + 2
Epic 6 (Timeline/Contact) -> Requires Epic 1 + 2
Epic 7 (Footer/Mobile) -> Requires Epic 1-6 (final polish)
```

Each epic is **standalone after completion** - Epic 3 doesn't need Epic 4 to function.

---

## Epic 1: Project Foundation & Loading Experience

**Goal:** Visitors see a professional, styled page immediately upon loading - no blank screens or spinners. The B&W aesthetic establishes credibility within 500ms.

### Story 1.1: Initialize Blazor WASM Project with Tailwind CSS

As a **developer**,
I want **a properly configured Blazor WASM project with Tailwind CSS v4**,
So that **I have a clean foundation following architecture decisions for building the portfolio**.

**Acceptance Criteria:**

**Given** no existing project structure
**When** the developer runs the initialization commands
**Then** a Blazor WASM project is created using `dotnet new blazorwasm -o BhavanPortfolio --framework net10.0`
**And** Bootstrap CSS is completely removed from the project
**And** Tailwind CSS v4 is installed via standalone CLI (no npm)
**And** tailwind.config.js is created with `darkMode: 'class'` and B&W palette constraints
**And** tailwind-input.css contains the @tailwind directives
**And** MSBuild target is added to BhavanPortfolio.csproj for Tailwind compilation
**And** folder structure matches architecture: Components/Layout/, Components/Sections/, Components/Shared/, Services/
**And** `.nojekyll` file exists in wwwroot for GitHub Pages
**And** `.gitattributes` contains `*.js binary` rule
**And** `dotnet build` compiles successfully with Tailwind CSS output

---

### Story 1.2: Create Loading Shell with Theme Resolution

As a **visitor**,
I want **to see styled content within 500ms of page load**,
So that **I have a professional first impression before WASM initializes**.

**Acceptance Criteria:**

**Given** a visitor navigates to the portfolio URL
**When** the page begins loading
**Then** index.html renders a static hero section matching the HeroSection component design
**And** the loading shell displays name "Bhavan" and title "Full Stack Developer" with correct typography (text-5xl/6xl)
**And** the loading shell uses the B&W aesthetic with proper Tailwind classes
**And** an inline script executes before body to resolve theme: localStorage > system preference > dark default
**And** the body element receives the correct class (`dark` or `light`) immediately without flash
**And** CSS transitions are defined for `.blazor-loading` state fade-out
**And** the loading shell renders within 500ms (NFR5)

---

### Story 1.3: Implement WASM Fallback and Error Handling

As a **visitor**,
I want **to see a helpful message if the application fails to load**,
So that **I understand the situation rather than seeing a broken page**.

**Acceptance Criteria:**

**Given** a visitor's browser where WASM fails to initialize
**When** 10 seconds pass without Blazor becoming interactive
**Then** a fallback message is displayed: "This site requires a modern browser with JavaScript enabled"
**And** the fallback message maintains the B&W aesthetic
**And** a `<noscript>` tag provides a message for JavaScript-disabled browsers
**And** the fallback does not appear if Blazor initializes successfully
**And** the loading shell gracefully transitions to the fallback state

---

### Story 1.4: Configure SEO Meta Tags and OpenGraph

As a **visitor sharing the portfolio link**,
I want **proper meta tags for search engines and social sharing**,
So that **the portfolio appears professionally when shared or searched**.

**Acceptance Criteria:**

**Given** the index.html file
**When** a search engine or social platform crawls the page
**Then** meta title tag contains "Bhavan - Full Stack Developer"
**And** meta description summarizes the portfolio purpose
**And** meta keywords include relevant terms
**And** OpenGraph tags (og:title, og:description, og:image, og:url) are present
**And** Twitter card tags are present
**And** semantic HTML structure is used (proper heading hierarchy)
**And** the favicon is configured

---

### Story 1.5: Setup GitHub Actions Deployment Pipeline

As a **developer**,
I want **automated deployment to GitHub Pages on push to main**,
So that **the portfolio is automatically updated when changes are merged**.

**Acceptance Criteria:**

**Given** changes are pushed to the main branch
**When** GitHub Actions workflow triggers
**Then** Tailwind CLI is downloaded (no npm dependency in CI)
**And** Tailwind CSS is compiled with --minify flag
**And** `dotnet publish -c Release` builds the Blazor WASM app
**And** the publish/wwwroot folder is deployed to GitHub Pages via `actions/deploy-pages@v4`
**And** the deployment completes successfully
**And** the site is accessible at the GitHub Pages URL
**And** README.md includes setup and build instructions (NFR18)

---

## Epic 2: Navigation & Theme System

**Goal:** Visitors can navigate smoothly between sections and control their viewing experience with instant theme switching.

### Story 2.1: Create MainLayout with Theme Class Binding

As a **visitor**,
I want **the page layout to reflect my theme preference**,
So that **the entire site displays consistently in dark or light mode**.

**Acceptance Criteria:**

**Given** a visitor has the site loaded
**When** the MainLayout component renders
**Then** the layout applies the correct theme class from ThemeService
**And** the layout includes skip-to-content link for accessibility
**And** the layout structure supports NavBar at top, main content, and Footer
**And** the layout uses semantic HTML (`<header>`, `<main>`, `<footer>`)
**And** all child components inherit the theme context

---

### Story 2.2: Implement ThemeService with JS Interop

As a **visitor**,
I want **my theme preference to persist across sessions**,
So that **I don't have to re-select my preferred mode each visit**.

**Acceptance Criteria:**

**Given** a visitor toggles the theme
**When** ThemeService.ToggleThemeAsync() is called
**Then** the theme switches immediately (<100ms perceived)
**And** the new preference is saved to localStorage via theme.js
**And** OnThemeChanged event fires to update subscribed components
**And** IThemeService interface is implemented with InitializeAsync, ToggleThemeAsync, CurrentTheme, OnThemeChanged
**And** ThemeService syncs with the theme applied by index.html on initialization
**And** wwwroot/js/theme.js provides getStoredTheme, setStoredTheme, getSystemPreference functions

---

### Story 2.3: Build Sticky Header Navigation (NavBar)

As a **visitor**,
I want **a sticky header that stays visible while scrolling**,
So that **I can navigate to any section or download the resume from anywhere on the page**.

**Acceptance Criteria:**

**Given** a visitor is viewing any part of the portfolio
**When** they look at the header
**Then** the NavBar is fixed at the top with `fixed top-0 left-0 right-0 z-50`
**And** the NavBar has backdrop blur effect (`bg-gray-900/95 backdrop-blur-sm dark:bg-gray-900/95`)
**And** the NavBar displays name/logo on the left
**And** navigation links (About, Skills, Projects, Experience, Contact) are visible on desktop
**And** Resume download button is styled as primary CTA (filled)
**And** ThemeToggle component is included
**And** the header height is 64px (`h-16`)
**And** the header has bottom border (`border-b border-gray-700 dark:border-gray-700`)
**And** `role="navigation"` and `aria-label="Main navigation"` are applied

---

### Story 2.4: Implement ThemeToggle Component

As a **visitor**,
I want **a visible toggle to switch between dark and light modes**,
So that **I can view the portfolio in my preferred color scheme**.

**Acceptance Criteria:**

**Given** a visitor clicks the theme toggle
**When** the toggle is activated
**Then** the icon changes from moon (dark mode) to sun (light mode) or vice versa
**And** the transition is instant with subtle animation
**And** the toggle button meets 44px minimum touch target
**And** `aria-label` and `aria-pressed` attributes are set correctly
**And** the toggle is keyboard accessible (Enter/Space activation)
**And** focus indicator is visible (`focus:ring-2 focus:ring-white focus:ring-offset-2`)

---

### Story 2.5: Build Mobile Hamburger Menu

As a **mobile visitor**,
I want **a hamburger menu for navigation**,
So that **I can access all sections and the resume on smaller screens**.

**Acceptance Criteria:**

**Given** a visitor views the site on a mobile device (< 768px)
**When** they tap the hamburger icon
**Then** a full-screen overlay menu opens with smooth animation (`transition-transform duration-300 ease-out`)
**And** all navigation links are displayed vertically
**And** Resume download button is accessible in the menu
**And** ThemeToggle is accessible in the menu
**And** the menu closes on: X button tap, outside tap, navigation link tap, or ESC key
**And** `aria-expanded` attribute toggles correctly
**And** focus is trapped within the menu when open
**And** background content has `aria-hidden="true"` when menu is open

---

### Story 2.6: Implement Smooth Scroll Navigation

As a **visitor**,
I want **smooth scrolling when I click navigation links**,
So that **the navigation feels polished and intentional**.

**Acceptance Criteria:**

**Given** a visitor clicks a navigation link (e.g., "Projects")
**When** the scroll animation executes
**Then** the page smoothly scrolls to the target section
**And** the scroll duration is 400-500ms with easing
**And** the scroll offset accounts for sticky header height (64px)
**And** ScrollService is implemented with IScrollService interface
**And** wwwroot/js/scroll.js provides scrollToSection function using scrollIntoView
**And** the animation runs at 60fps without jank (NFR7)
**And** `prefers-reduced-motion` media query is respected

---

## Epic 3: Hero & Identity Section

**Goal:** Visitors instantly identify who this portfolio belongs to - name, title, and professional intro visible in the first 3 seconds (Rachel's F-pattern scan).

### Story 3.1: Create HeroSection Component

As a **visitor**,
I want **to immediately see who this portfolio belongs to**,
So that **I can validate this is the right candidate within 3 seconds**.

**Acceptance Criteria:**

**Given** a visitor lands on the portfolio
**When** the HeroSection renders
**Then** the section takes full viewport height (`min-h-screen`)
**And** content is centered vertically and horizontally (`flex items-center justify-center`)
**And** the name "Bhavan" is displayed prominently (`text-5xl md:text-6xl font-bold`)
**And** the title "Full Stack Developer" is displayed below (`text-xl md:text-2xl text-gray-400`)
**And** a brief professional introduction is visible
**And** the section has proper padding and container constraints (`max-w-6xl mx-auto px-4 md:px-6`)
**And** text meets WCAG AA contrast requirements (NFR8)

---

### Story 3.2: Add Hero Call-to-Action Buttons

As a **visitor**,
I want **clear action buttons in the hero section**,
So that **I can quickly download the resume or view projects**.

**Acceptance Criteria:**

**Given** a visitor views the hero section
**When** they see the CTA buttons
**Then** "Download Resume" is styled as primary CTA (filled: `bg-white text-black` in dark mode)
**And** "View Projects" is styled as secondary CTA (outline: `border-white text-white` in dark mode)
**And** both buttons have proper padding (`px-6 py-3`)
**And** buttons are side-by-side on desktop, stacked on mobile
**And** buttons meet 44px minimum touch target (NFR11)
**And** hover states are implemented (`hover:bg-gray-200` for primary)
**And** focus indicators are visible on keyboard navigation

---

### Story 3.3: Integrate Resume PDF Download

As a **visitor**,
I want **to download the resume with one click**,
So that **I can save it for review or share with hiring managers**.

**Acceptance Criteria:**

**Given** a visitor clicks the "Download Resume" button
**When** the click event fires
**Then** the browser downloads the PDF file immediately
**And** the file is named "bhavan-resume.pdf" (or similar professional name)
**And** the PDF is stored in wwwroot/assets/resume.pdf
**And** the download link uses `download` attribute for direct download
**And** the same download is accessible from NavBar resume button
**And** the download works on mobile devices

---

## Epic 4: About & Skills Sections

**Goal:** Visitors validate professional background and technical competencies in a scannable format - Rachel's 3-6 second skills validation.

### Story 4.1: Create AboutSection Component

As a **visitor**,
I want **to read a brief professional summary**,
So that **I understand the developer's background and approach**.

**Acceptance Criteria:**

**Given** a visitor scrolls to the About section
**When** the AboutSection renders
**Then** the section has id="about" for navigation
**And** the section heading is styled (`text-3xl md:text-4xl font-semibold`)
**And** the professional summary is displayed in readable paragraphs
**And** the section has proper padding (`py-20 md:py-32`)
**And** the container is constrained (`max-w-6xl mx-auto px-4 md:px-6`)
**And** text uses appropriate line height (`leading-relaxed`)
**And** the content is scannable (not walls of text)

---

### Story 4.2: Create SkillsSection with SkillBadge Components

As a **visitor**,
I want **to quickly scan technical skills**,
So that **I can validate the developer matches my requirements in under 5 seconds**.

**Acceptance Criteria:**

**Given** a visitor scrolls to the Skills section
**When** the SkillsSection renders
**Then** the section has id="skills" for navigation
**And** skills are displayed as pill-shaped badges using SkillBadge component
**And** SkillBadge has styling: `rounded-full px-3 py-1 text-sm font-medium`
**And** badges have background (`bg-gray-800 dark:bg-gray-800`) and border (`border border-gray-700`)
**And** badges have subtle hover effect (`hover:bg-gray-700`)
**And** skills are organized in a responsive grid (2 cols mobile, 3 cols tablet, 4 cols desktop)
**And** badges are rendered as semantic list (`<ul>` with `<li>` items)
**And** the layout allows scanning in 3-5 seconds

---

### Story 4.3: Populate Skills Content

As a **visitor**,
I want **to see relevant technical skills**,
So that **I can determine if the developer's expertise matches my needs**.

**Acceptance Criteria:**

**Given** a visitor views the Skills section
**When** the skills are displayed
**Then** primary skills include: Blazor, .NET, C#, Azure, React, TypeScript, SQL, AI/ML
**And** skills are organized by category or priority (most relevant first)
**And** the skill list is maintainable (easy to update)
**And** no more than 15-20 skills to maintain scannability
**And** skills align with PRD target searches ("Bhavan AI Developer", "Bhavan .NET Developer")

---

## Epic 5: Projects Showcase

**Goal:** Visitors can see proof of work through project showcases with GitHub links for code validation - Marcus's technical deep-dive.

### Story 5.1: Create ProjectsSection Component

As a **visitor**,
I want **to see a showcase of projects**,
So that **I can validate the developer's practical experience**.

**Acceptance Criteria:**

**Given** a visitor scrolls to the Projects section
**When** the ProjectsSection renders
**Then** the section has id="projects" for navigation
**And** the section heading is properly styled
**And** projects are displayed in a responsive grid (1 col mobile, 2 cols tablet, 3 cols desktop)
**And** the section has proper padding (`py-20 md:py-32`)
**And** at least 3 projects are displayed (FR15)
**And** the grid has appropriate gap spacing (`gap-6`)

---

### Story 5.2: Create ProjectCard Component

As a **visitor**,
I want **to see project details in a clear card format**,
So that **I can understand what was built and access the code**.

**Acceptance Criteria:**

**Given** a visitor views a project card
**When** the ProjectCard renders
**Then** the card displays a screenshot/visual (`aspect-video object-cover`)
**And** the card shows project title (`text-xl font-semibold`)
**And** the card shows project description
**And** technology tags are displayed (reusing SkillBadge or similar)
**And** GitHub link is prominent with arrow icon (`→`)
**And** live demo link is shown when available (FR19)
**And** the card has proper styling (`bg-gray-800 rounded-lg overflow-hidden`)
**And** hover effect is implemented (`hover:shadow-lg hover:-translate-y-1 transition-all duration-200`)
**And** the card uses `<article>` with proper heading and descriptive image `alt`

---

### Story 5.3: Populate Project Content

As a **visitor**,
I want **to see real project examples**,
So that **I have concrete evidence of the developer's work**.

**Acceptance Criteria:**

**Given** a visitor views the Projects section
**When** projects are displayed
**Then** at least 3 projects are shown with real content
**And** each project has: title, description, technologies, screenshot, GitHub URL
**And** project screenshots are stored in wwwroot/assets/images/
**And** all images have descriptive alt text
**And** GitHub links open in new tab with `target="_blank" rel="noopener noreferrer"`
**And** projects showcase variety in technologies and domains

---

## Epic 6: Timeline & Contact Sections

**Goal:** Visitors understand career progression and have clear paths to connect - completing the full portfolio experience.

### Story 6.1: Create TimelineSection Component

As a **visitor**,
I want **to see work experience chronologically**,
So that **I can understand career progression and relevant experience**.

**Acceptance Criteria:**

**Given** a visitor scrolls to the Experience section
**When** the TimelineSection renders
**Then** the section has id="experience" for navigation
**And** the section heading is properly styled
**And** timeline entries are displayed vertically
**And** the section has proper padding (`py-20 md:py-32`)
**And** entries show career progression clearly

---

### Story 6.2: Create TimelineItem Component

As a **visitor**,
I want **to see details of each work experience**,
So that **I can evaluate relevant background**.

**Acceptance Criteria:**

**Given** a visitor views a timeline entry
**When** the TimelineItem renders
**Then** a vertical line connects entries (`border-l-2 border-gray-700`)
**And** a dot marks each entry (`w-3 h-3 rounded-full bg-white`)
**And** the date/period is displayed (`text-sm text-gray-400 font-medium`)
**And** the role title is prominent (`text-lg font-semibold`)
**And** the company name is shown (`text-base text-gray-400`)
**And** a brief role description is included
**And** entries use semantic list structure
**And** `<time>` elements have `datetime` attribute

---

### Story 6.3: Create ContactSection Component

As a **visitor**,
I want **clear ways to contact the developer**,
So that **I can reach out for opportunities**.

**Acceptance Criteria:**

**Given** a visitor scrolls to the Contact section
**When** the ContactSection renders
**Then** the section has id="contact" for navigation
**And** email link is displayed as `mailto:` link
**And** LinkedIn profile link is displayed
**And** GitHub profile link is displayed
**And** all external links open in new tab with `target="_blank" rel="noopener noreferrer"`
**And** links meet 44px touch target minimum
**And** the section has proper padding and styling

---

### Story 6.4: Create SocialLink Component

As a **visitor**,
I want **consistent styling for social/contact links**,
So that **I can easily identify and click contact options**.

**Acceptance Criteria:**

**Given** a visitor views contact links
**When** SocialLink components render
**Then** each link has an icon (email, LinkedIn, GitHub)
**And** the link text/icon is clearly visible
**And** hover state indicates interactivity
**And** focus indicators are visible for keyboard navigation
**And** the component is reusable across Contact and Footer sections
**And** `aria-label` provides context for screen readers

---

## Epic 7: Footer & Mobile Polish

**Goal:** Complete the professional experience with footer attribution and ensure full mobile parity - Rachel's mobile check passes.

> **Deferred to Post-MVP:** Active navigation section highlighting (via Intersection Observer) is a UX enhancement that can be added after initial launch. Core navigation functionality is complete in Epic 2.

### Story 7.1: Create Footer Component

As a **visitor**,
I want **a professional footer with attribution**,
So that **I see a complete, polished portfolio experience**.

**Acceptance Criteria:**

**Given** a visitor scrolls to the bottom of the page
**When** the Footer renders
**Then** "Built with Blazor" text/badge is displayed
**And** copyright notice is shown (`text-sm text-gray-500`)
**And** social links are displayed (reusing SocialLink component)
**And** link to portfolio source code repository is included (FR27)
**And** the footer is centered with minimal styling
**And** proper semantic `<footer>` element is used

---

### Story 7.2: Validate Mobile Responsive Layout *(QA/Validation Story)*

As a **mobile visitor**,
I want **the site to work perfectly on my phone**,
So that **I can review the portfolio on any device**.

**Acceptance Criteria:**

**Given** a visitor views the site on mobile (< 640px)
**When** all sections are viewed
**Then** content stacks in single column appropriately
**And** text is readable without zooming (base 16px)
**And** images resize proportionally
**And** navigation hamburger menu works correctly
**And** all touch targets are minimum 44px (NFR11)
**And** no horizontal scrolling occurs
**And** project cards stack vertically
**And** buttons stack vertically in hero section

---

### Story 7.3: Validate Tablet Responsive Layout *(QA/Validation Story)*

As a **tablet visitor**,
I want **the site to adapt well to medium screens**,
So that **I have an optimal viewing experience**.

**Acceptance Criteria:**

**Given** a visitor views the site on tablet (640-1024px)
**When** all sections are viewed
**Then** project grid shows 2 columns
**And** skills grid adjusts to 3 columns
**And** navigation may show condensed or hamburger depending on width
**And** section padding adjusts appropriately
**And** typography scales correctly

---

### Story 7.4: Cross-Browser Testing and Final Polish *(QA/Validation Story)*

As a **visitor using any modern browser**,
I want **consistent experience across browsers**,
So that **the portfolio works regardless of my browser choice**.

**Acceptance Criteria:**

**Given** a visitor uses Chrome, Firefox, Safari, or Edge (latest 2 versions)
**When** they view the portfolio
**Then** all layouts render identically
**And** all interactions work consistently
**And** theme switching works in all browsers
**And** smooth scroll works in all browsers
**And** no console errors appear

**Performance Validation (NFR1-NFR7):**
**And** Lighthouse Performance score is 90+ (NFR1)
**And** First Contentful Paint < 1.5s (NFR2)
**And** Largest Contentful Paint < 2.5s (NFR3)
**And** Time to Interactive < 5s (NFR4)
**And** Loading shell renders < 500ms (NFR5)
**And** Theme toggle responds < 100ms (NFR6)
**And** Smooth scroll maintains 60fps (NFR7)

**Accessibility Validation (NFR8-NFR11):**
**And** Color contrast meets WCAG AA 4.5:1 ratio (NFR8)
**And** All interactive elements are keyboard navigable (NFR9)
**And** Focus indicators are visible on all focusable elements (NFR10)
**And** Touch targets are >= 44px on mobile (NFR11)
**And** `prefers-reduced-motion` is respected for users with motion sensitivity
