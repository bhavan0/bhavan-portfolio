---
stepsCompleted: [1, 2, 3, 4, 5, 6, 7, 8]
lastStep: 8
status: 'complete'
completedAt: '2026-01-04'
inputDocuments:
  - "_bmad-output/planning-artifacts/prd.md"
  - "_bmad-output/planning-artifacts/product-brief-bhavan-portfolio-2026-01-04.md"
  - "_bmad-output/planning-artifacts/research/domain-technical-portfolio-research-2026-01-04.md"
  - "_bmad-output/analysis/brainstorming-session-2026-01-04.md"
workflowType: 'architecture'
project_name: 'bhavan-portfolio'
user_name: 'Bhavan'
date: '2026-01-04'
---

# Architecture Decision Document

_This document builds collaboratively through step-by-step discovery. Sections are appended as we work through each architectural decision together._

## Project Context Analysis

### Requirements Overview

**Functional Requirements:**
45 FRs across 11 capability areas defining a single-page portfolio with:
- Sticky header with navigation, resume download, and theme toggle
- 6 content sections (Hero, About, Skills, Projects, Timeline, Contact)
- Dark/light theme with localStorage persistence and system preference detection
- Styled loading experience for WASM initialization
- Full responsive design across mobile, tablet, and desktop
- SEO optimization through meta tags and semantic HTML

**Non-Functional Requirements:**
19 NFRs across 4 quality categories:
- Performance: Lighthouse 90+, FCP <1.5s, TTI <5s, styled shell <500ms
- Accessibility: WCAG AA contrast, keyboard navigation, 44px touch targets
- Reliability: WASM fallback, cross-browser consistency
- Maintainability: Defined folder structure, naming conventions, documentation

**Scale & Complexity:**

- Primary domain: Web (Blazor WASM SPA)
- Complexity level: Low
- Estimated architectural components: 15-18 Blazor components + 1-2 services

### Technical Constraints & Dependencies

| Constraint | Impact |
|------------|--------|
| Blazor WASM (.NET 10) | Client-side only, 2-5MB runtime download, JS interop for browser APIs |
| Tailwind CSS v4 | Utility-first styling, build-time CSS generation |
| GitHub Pages | Static hosting only, no server-side code, requires gh-pages branch deployment |
| Modern browsers only | No IE11 polyfills, can use modern CSS/JS features |
| Static-first architecture | Deliberate simplicity - content as code, version controlled, zero runtime dependencies, instant deployments, no infrastructure to maintain |

### Cross-Cutting Concerns Identified

| Concern | Affected Components | Architectural Pattern Needed |
|---------|---------------------|------------------------------|
| Theme State | All components | Global state with CSS custom properties |
| Responsive Layout | All components | Tailwind breakpoint utilities, mobile-first |
| Loading Orchestration | App shell | HTML loading state + Blazor progressive hydration |
| Accessibility | Interactive elements | Semantic HTML, ARIA where needed, focus management |
| Performance | All components | Lazy loading considerations, optimized images |
| Testability | Services, JS Interop | Interface-based dependencies, pure components |

## Starter Template Evaluation

### Primary Technology Domain

Web Application (Blazor WASM SPA) - Client-side static site for GitHub Pages deployment.

### Starter Options Considered

| Option | Description | Verdict |
|--------|-------------|---------|
| `dotnet new blazorwasm` | Official Microsoft template | **Selected** - stable, minimal, well-documented |
| Minimal Blazor Templates | Third-party stripped template | Good alternative, but standard is sufficient |
| BlazorWasmTailwind | Pre-configured Tailwind | May not support .NET 10 / Tailwind v4 |
| ServiceStack Blazor | Full-featured with Tailwind | Adds unnecessary dependencies |

### Selected Starter: Standard Blazor WebAssembly Template

**Rationale for Selection:**
- Official Microsoft template with best long-term support
- Clean starting point without unwanted dependencies
- Tailwind CSS v4 standalone CLI integrates easily (documented in research)
- No lock-in to third-party template maintainers

**Initialization Command:**

```bash
dotnet new blazorwasm -o BhavanPortfolio --framework net10.0
```

### Architectural Decisions Provided by Starter

**Language & Runtime:**
- C# with .NET 10
- Blazor WebAssembly (client-side only)
- Default project structure with wwwroot, Pages, Shared folders

**Styling Solution:**
- Bootstrap included by default (will be removed)
- Tailwind CSS v4 will be added via standalone CLI
- CSS isolation (.razor.css) available but not required

**Build Tooling:**
- Standard dotnet build
- Tailwind CLI integrated via MSBuild target
- GitHub Actions for deployment

**Project Structure:**

```
BhavanPortfolio/
├── wwwroot/
│   ├── css/           # Tailwind output
│   ├── assets/        # Images, resume PDF
│   └── index.html     # Loading shell + WASM bootstrap
├── Components/
│   ├── Layout/        # MainLayout, NavBar, Footer
│   ├── Sections/      # Hero, About, Skills, Projects, Timeline, Contact
│   └── Shared/        # ThemeToggle, ProjectCard, SkillBadge, etc.
├── Services/          # ThemeService, ScrollService
├── App.razor
├── Program.cs
└── BhavanPortfolio.csproj
```

**Note:** First implementation task should be project initialization, Bootstrap removal, and Tailwind setup.

## Core Architectural Decisions

### Decision Priority Analysis

**Critical Decisions (Block Implementation):**
- State Management: Singleton Service pattern
- JS Interop: Module per concern (browser APIs only)
- Theme Application: Body class with Tailwind dark mode
- Deployment: GitHub Actions with deploy-pages

**Important Decisions (Shape Architecture):**
- Component Communication: Service Events pattern
- Theme Resolution: localStorage > system preference > dark default
- Loading Shell: Static hero HTML with CSS fade transition

**Deferred Decisions (Post-MVP):**
- Analytics integration
- CMS integration
- Custom domain configuration

### Frontend Architecture

#### State Management

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Pattern | Singleton Service | Testable, familiar .NET pattern, clean DI |
| Implementation | `IThemeService` / `ThemeService` | Interface for testability |
| Registration | `builder.Services.AddSingleton<IThemeService, ThemeService>()` | Single instance across app |

**IThemeService Contract:**

```csharp
public interface IThemeService
{
    string CurrentTheme { get; }
    event Action? OnThemeChanged;
    Task InitializeAsync();  // Syncs with index.html applied theme
    Task ToggleThemeAsync(); // Switches theme and persists to localStorage
}
```

#### Component Communication

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Pattern | Service Events | Decoupled, any component can subscribe |
| Implementation | `event Action OnStateChanged` | Standard .NET event pattern |
| Lifecycle | Subscribe in `OnInitialized`, unsubscribe in `Dispose` | Proper cleanup |

#### JS Interop Strategy

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Structure | Module per concern | Maintainable, extendable for future |
| Scope | Browser APIs only | localStorage, matchMedia, scrollIntoView |
| DOM Manipulation | Blazor via JSRuntime | More testable than JS functions |

**JS Module Structure:**

```
wwwroot/js/
├── theme.js      # getStoredTheme, setStoredTheme, getSystemPreference
└── scroll.js     # scrollToSection
```

**Note:** DOM class manipulation (adding/removing `dark` class) handled by Blazor via `IJSRuntime`, not JS modules. JS modules only access browser APIs that Blazor cannot directly access.

#### Theme Application

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Method | Body class (`dark` / `light`) | Tailwind dark mode compatible |
| Tailwind Config | `darkMode: 'class'` | Use `dark:` variant utilities |
| Flash Prevention | Inline script in index.html | Runs before Blazor loads |

**Theme Resolution Priority (FR32):**
1. localStorage `theme` value (if exists)
2. System preference via `prefers-color-scheme`
3. Default: `dark`

### Loading State Architecture

#### Loading Shell Strategy

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Shell Content | Static hero section HTML | Matches first visible component |
| Transition | CSS fade via class removal | Smooth handoff to Blazor |
| Fallback | JS timeout + noscript tag | WASM failure handling (FR37) |

**index.html Loading Shell:**
- Contains static HTML matching `HeroSection` component (name, title, brief intro)
- Styled with same Tailwind classes as Blazor component
- `<body class="dark blazor-loading">` - loading class removed when app ready
- CSS: `.blazor-loading` content fades out, Blazor content fades in

**WASM Fallback (FR37):**
- JavaScript timeout (10s) displays fallback message if Blazor doesn't initialize
- `<noscript>` tag for JavaScript-disabled browsers
- Message: "This site requires a modern browser with JavaScript enabled."

### Infrastructure & Deployment

#### GitHub Pages Deployment

| Decision | Choice | Rationale |
|----------|--------|-----------|
| Method | GitHub Actions artifact | Modern, no extra branch |
| Trigger | Push to `main` | Automatic deployment |
| Action | `actions/deploy-pages@v4` | Official GitHub action |
| Tailwind in CI | Download standalone CLI | No npm dependency |

**Required Files:**
- `.github/workflows/deploy.yml` - Deployment workflow
- `.nojekyll` - Serve `_framework` folder
- `.gitattributes` - `*.js binary` to prevent line ending issues

**CI Tailwind Strategy:**

```yaml
- name: Download Tailwind CLI
  run: |
    curl -sLO https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64
    chmod +x tailwindcss-linux-x64
    mv tailwindcss-linux-x64 tailwindcss
```

### Decision Impact Analysis

**Implementation Sequence:**
1. Project initialization + Tailwind setup + index.html loading shell with theme script
2. Theme system (ThemeService + JS modules)
3. Layout components (MainLayout, NavBar, Footer)
4. Section components (Hero → Contact)
5. Shared components (ProjectCard, SkillBadge, etc.)
6. GitHub Actions deployment workflow

**Cross-Component Dependencies:**
- Loading shell (index.html) must exist before any Blazor code
- All components depend on theme system being in place
- Section components depend on layout being complete
- Deployment depends on build pipeline (Tailwind integration)

## Implementation Patterns & Consistency Rules

### Pattern Categories Defined

**5 potential conflict areas** identified and addressed for AI agent consistency.

### Naming Patterns

| Element | Convention | Example |
|---------|------------|---------|
| Razor components | PascalCase | `HeroSection.razor`, `ProjectCard.razor` |
| C# classes | PascalCase | `ThemeService.cs`, `ScrollService.cs` |
| Interfaces | I + PascalCase | `IThemeService.cs` |
| JS modules | camelCase | `theme.js`, `scroll.js` |
| CSS files | kebab-case | `app.css`, `tailwind-output.css` |
| Asset files | kebab-case | `hero-image.png`, `resume.pdf` |

### Structure Patterns

| Component Type | Folder | Decision Rule |
|----------------|--------|---------------|
| Page layouts | `Components/Layout/` | Structural elements (MainLayout, NavBar, Footer) |
| Page sections | `Components/Sections/` | Full viewport sections (Hero, About, Skills, etc.) |
| Reusable UI | `Components/Shared/` | Components used across sections (ThemeToggle, ProjectCard) |
| Services | `Services/` | Business logic and state (ThemeService, ScrollService) |
| JS modules | `wwwroot/js/` | Browser API access only |
| Static assets | `wwwroot/assets/` | Images, PDFs, fonts |

### Styling Patterns - Tailwind Color Palette

**Constrained palette for B&W minimalist design:**

| Purpose | Dark Mode Class | Light Mode Class |
|---------|-----------------|------------------|
| Background (primary) | `bg-black` | `bg-white` |
| Background (secondary) | `bg-gray-900` | `bg-gray-50` |
| Text (primary) | `text-white` | `text-black` |
| Text (secondary) | `text-gray-400` | `text-gray-600` |
| Borders | `border-gray-800` | `border-gray-200` |
| Accents/highlights | `text-gray-300` | `text-gray-700` |

**Allowed grays only:** black, white, gray-50, gray-200, gray-300, gray-400, gray-600, gray-700, gray-800, gray-900

### Code Patterns - Component Parameters

| Scenario | Pattern | Example |
|----------|---------|---------|
| Required | `[EditorRequired]` | `[Parameter, EditorRequired] public string Title { get; set; } = "";` |
| Optional with default | Non-nullable with default | `[Parameter] public string CssClass { get; set; } = "";` |
| Optional "not provided" | Nullable | `[Parameter] public string? GitHubUrl { get; set; }` |

### Service Event Pattern

```csharp
// Component subscription pattern
@implements IDisposable

@code {
    protected override void OnInitialized()
    {
        ThemeService.OnThemeChanged += HandleThemeChanged;
    }

    private void HandleThemeChanged() => StateHasChanged();

    public void Dispose()
    {
        ThemeService.OnThemeChanged -= HandleThemeChanged;
    }
}
```

### Enforcement Guidelines

**All AI Agents MUST:**

1. Use PascalCase for all `.razor` and `.cs` files
2. Place components in correct folders per decision rules above
3. Use only the defined Tailwind color palette - no other colors
4. Apply `[EditorRequired]` attribute to mandatory component parameters
5. Subscribe to service events in `OnInitialized`, unsubscribe in `Dispose`
6. Keep JS modules scoped to browser APIs only - DOM manipulation via Blazor

**Pattern Verification:**

- Code review should verify naming conventions
- Tailwind config can restrict color palette via safelist
- Component placement checked during PR review

**Anti-Patterns to Avoid:**

- ❌ `heroSection.razor` (wrong: lowercase)
- ❌ `theme-toggle.razor` (wrong: kebab-case)
- ❌ `bg-blue-500` (wrong: color not in palette)
- ❌ Direct DOM manipulation in JS modules
- ❌ Missing `IDisposable` when subscribing to events

## Project Structure & Boundaries

### Complete Project Directory Structure

```
BhavanPortfolio/
├── .github/
│   └── workflows/
│       └── deploy.yml              # GitHub Pages deployment workflow
├── wwwroot/
│   ├── index.html                  # Loading shell + WASM bootstrap + theme script
│   ├── css/
│   │   └── app.css                 # Tailwind output (generated)
│   ├── js/
│   │   ├── theme.js                # getStoredTheme, setStoredTheme, getSystemPreference
│   │   └── scroll.js               # scrollToSection
│   └── assets/
│       ├── images/
│       │   └── profile.jpg         # Profile photo
│       └── resume.pdf              # Downloadable resume
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor        # Root layout with theme class binding
│   │   ├── NavBar.razor            # Sticky header with navigation
│   │   └── Footer.razor            # Footer component
│   ├── Sections/
│   │   ├── HeroSection.razor       # Name, title, intro, CTA buttons
│   │   ├── AboutSection.razor      # Bio and background
│   │   ├── SkillsSection.razor     # Technical skills display
│   │   ├── ProjectsSection.razor   # Project showcase grid
│   │   ├── TimelineSection.razor   # Career/education timeline
│   │   └── ContactSection.razor    # Contact information and links
│   └── Shared/
│       ├── ThemeToggle.razor       # Dark/light mode toggle button
│       ├── ProjectCard.razor       # Individual project display card
│       ├── SkillBadge.razor        # Individual skill tag/badge
│       ├── TimelineItem.razor      # Single timeline entry
│       └── SocialLink.razor        # Social media link button
├── Services/
│   ├── IThemeService.cs            # Theme service interface
│   ├── ThemeService.cs             # Theme state management
│   ├── IScrollService.cs           # Scroll service interface
│   └── ScrollService.cs            # Smooth scroll navigation
├── App.razor                       # Root component, router
├── Program.cs                      # DI registration, app startup
├── _Imports.razor                  # Global using statements
├── BhavanPortfolio.csproj          # Project file with Tailwind MSBuild target
├── tailwind.config.js              # Tailwind v4 configuration
├── tailwind-input.css              # Tailwind directives (@tailwind base, etc.)
├── .nojekyll                       # Serve _framework folder on GitHub Pages
├── .gitattributes                  # *.js binary for line endings
└── README.md                       # Project documentation
```

### Architectural Boundaries

**Component Boundaries:**

| Boundary | Communication Pattern |
|----------|----------------------|
| Layout ↔ Sections | Cascading parameters (theme class) |
| Sections ↔ Shared | Component parameters |
| Components ↔ Services | DI injection + event subscription |
| Services ↔ JS Modules | `IJSRuntime` interop |

**Service Boundaries:**

| Service | Responsibility | JS Module Dependency |
|---------|---------------|---------------------|
| ThemeService | Theme state, persistence, change notification | `theme.js` |
| ScrollService | Smooth scroll to sections | `scroll.js` |

### Requirements to Structure Mapping

**FR Categories → Components:**

| FR Category | Component Location |
|-------------|-------------------|
| Header/Navigation (FR01-08) | `Components/Layout/NavBar.razor` |
| Hero Section (FR09-12) | `Components/Sections/HeroSection.razor` |
| About Section (FR13-16) | `Components/Sections/AboutSection.razor` |
| Skills Section (FR17-20) | `Components/Sections/SkillsSection.razor` |
| Projects Section (FR21-27) | `Components/Sections/ProjectsSection.razor`, `Components/Shared/ProjectCard.razor` |
| Timeline Section (FR28-31) | `Components/Sections/TimelineSection.razor`, `Components/Shared/TimelineItem.razor` |
| Contact Section (FR32-35) | `Components/Sections/ContactSection.razor`, `Components/Shared/SocialLink.razor` |
| Theme Toggle (FR36-40) | `Components/Shared/ThemeToggle.razor`, `Services/ThemeService.cs` |
| Loading Experience (FR41-45) | `wwwroot/index.html` (static shell) |

**Cross-Cutting Concerns → Locations:**

| Concern | Implementation Location |
|---------|------------------------|
| Theme State | `Services/ThemeService.cs` + `wwwroot/js/theme.js` |
| Responsive Layout | Tailwind classes in each component |
| Loading Orchestration | `wwwroot/index.html` |
| Accessibility | Semantic HTML + ARIA in components |

### Integration Points

**Internal Communication:**

```
User Action (click theme toggle)
    ↓
ThemeToggle.razor calls ThemeService.ToggleThemeAsync()
    ↓
ThemeService updates state + calls JS interop
    ↓
theme.js persists to localStorage
    ↓
ThemeService fires OnThemeChanged event
    ↓
Subscribed components call StateHasChanged()
```

**External Integrations:**

| Integration | Purpose | Access Pattern |
|-------------|---------|---------------|
| localStorage | Theme persistence | JS interop via `theme.js` |
| `prefers-color-scheme` | System theme detection | JS interop via `theme.js` |
| GitHub Pages | Static hosting | Artifact deployment via Actions |

### Data Flow

**Theme Resolution Flow:**

```
index.html loads
    ↓
Inline script checks localStorage → system preference → default (dark)
    ↓
Body class set immediately (no flash)
    ↓
Blazor initializes
    ↓
ThemeService.InitializeAsync() syncs with applied theme
    ↓
Components render with correct theme classes
```

**Navigation Flow:**

```
User clicks nav link
    ↓
NavBar calls ScrollService.ScrollToSection(sectionId)
    ↓
ScrollService calls JS interop
    ↓
scroll.js executes scrollIntoView with smooth behavior
```

### Development Workflow Integration

**Local Development:**

```bash
# Terminal 1: Blazor dev server with hot reload
dotnet watch run

# Terminal 2: Tailwind watch mode
tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --watch
```

**Build Process:**

```bash
# 1. Tailwind build (minified for production)
tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify

# 2. Blazor publish
dotnet publish -c Release -o publish
```

**Deployment Structure:**

```
publish/wwwroot/           # Deployed to GitHub Pages
├── _framework/            # Blazor WASM runtime + assemblies
├── css/app.css            # Compiled Tailwind
├── js/                    # JS modules
├── assets/                # Static assets
└── index.html             # Entry point
```

### File Organization Patterns

**Configuration Files (Root):**

| File | Purpose |
|------|---------|
| `BhavanPortfolio.csproj` | Project config + MSBuild Tailwind target |
| `tailwind.config.js` | Tailwind configuration (darkMode: 'class') |
| `tailwind-input.css` | Tailwind directives |
| `.gitattributes` | Line ending rules for JS files |
| `.nojekyll` | GitHub Pages _framework serving |

**Source Organization:**

| Directory | Contents | Rule |
|-----------|----------|------|
| `Components/Layout/` | 3 files | Structural components only |
| `Components/Sections/` | 6 files | One per portfolio section |
| `Components/Shared/` | 5 files | Reusable across sections |
| `Services/` | 4 files | Interfaces + implementations |
| `wwwroot/js/` | 2 files | Browser API modules only |

### Component Inventory

**Total: 17 Blazor components + 2 services**

| Category | Count | Components |
|----------|-------|------------|
| Layout | 3 | MainLayout, NavBar, Footer |
| Sections | 6 | Hero, About, Skills, Projects, Timeline, Contact |
| Shared | 5 | ThemeToggle, ProjectCard, SkillBadge, TimelineItem, SocialLink |
| Services | 2 | ThemeService, ScrollService |
| JS Modules | 2 | theme.js, scroll.js |

## Architecture Validation Results

### Coherence Validation ✅

**Decision Compatibility:**
All technology choices work together without conflicts:
- .NET 10 + Blazor WASM: Official Microsoft stack, stable
- Tailwind CSS v4 standalone: No npm conflicts, MSBuild integration works
- GitHub Pages: Static WASM output compatible with artifact deployment
- Singleton Services: Blazor DI fully supports singleton pattern
- JS Interop modules: Standard IJSRuntime approach, well-documented

**Pattern Consistency:**
All implementation patterns support architectural decisions:
- PascalCase naming applied consistently to .razor and .cs files
- Folder organization has clear rules for Layout/Sections/Shared/Services
- Tailwind palette constrained to defined B&W grays
- Service events follow standard pattern with IDisposable cleanup

**Structure Alignment:**
Project structure enables all architectural decisions:
- Components organized by architectural role (Layout, Sections, Shared)
- Services separated from components with interface abstractions
- JS modules isolated for browser APIs only
- Build process supports Tailwind CLI integration

### Requirements Coverage Validation ✅

**Functional Requirements Coverage:**

| FR Category | Coverage | Architectural Support |
|-------------|----------|----------------------|
| Header/Navigation (FR01-08) | ✅ 100% | NavBar.razor + ScrollService |
| Hero Section (FR09-12) | ✅ 100% | HeroSection.razor |
| About Section (FR13-16) | ✅ 100% | AboutSection.razor |
| Skills Section (FR17-20) | ✅ 100% | SkillsSection.razor + SkillBadge.razor |
| Projects Section (FR21-27) | ✅ 100% | ProjectsSection.razor + ProjectCard.razor |
| Timeline Section (FR28-31) | ✅ 100% | TimelineSection.razor + TimelineItem.razor |
| Contact Section (FR32-35) | ✅ 100% | ContactSection.razor + SocialLink.razor |
| Theme Toggle (FR36-40) | ✅ 100% | ThemeToggle.razor + ThemeService + theme.js |
| Loading Experience (FR41-45) | ✅ 100% | index.html static shell + CSS transitions |

**Non-Functional Requirements Coverage:**

| NFR Category | Coverage | Architectural Support |
|--------------|----------|----------------------|
| Performance (Lighthouse 90+) | ✅ | Static shell <500ms, optimized Tailwind, lazy considerations |
| Accessibility (WCAG AA) | ✅ | Semantic HTML patterns, ARIA guidelines, focus management |
| Reliability (WASM fallback) | ✅ | 10s timeout + noscript in index.html (FR37) |
| Maintainability | ✅ | Clear structure, naming conventions, documented patterns |

### Implementation Readiness Validation ✅

**Decision Completeness:**
- All technology choices documented with specific versions (.NET 10, Tailwind v4)
- IThemeService contract fully specified with method signatures
- JS module responsibilities clearly defined (browser APIs only)
- Deployment workflow documented with GitHub Actions steps

**Structure Completeness:**
- 17 components mapped to specific file paths
- 2 services with interfaces defined
- 2 JS modules with function responsibilities
- Complete directory tree with all files listed

**Pattern Completeness:**
- Naming conventions cover all file types (.razor, .cs, .js, .css, assets)
- Component parameter patterns specified with examples
- Service event subscription pattern with full code example
- Anti-patterns documented to prevent common mistakes

### Gap Analysis Results

**Critical Gaps:** None identified ✅

**Important Gaps:** None identified ✅

**Minor Enhancements (Non-Blocking):**
1. Testing strategy not specified - Can add unit test patterns for services during implementation
2. Image optimization guidance - Can document format/size recommendations when adding assets
3. Tailwind safelist configuration - Can enforce color constraints in tailwind.config.js

### Architecture Completeness Checklist

**✅ Requirements Analysis**
- [x] Project context thoroughly analyzed (45 FRs, 19 NFRs)
- [x] Scale and complexity assessed (Low complexity, 17 components)
- [x] Technical constraints identified (Blazor WASM, GitHub Pages, modern browsers)
- [x] Cross-cutting concerns mapped (Theme, Responsive, Loading, Accessibility, Testability)

**✅ Architectural Decisions**
- [x] Critical decisions documented with rationale
- [x] Technology stack fully specified (.NET 10, Blazor WASM, Tailwind v4)
- [x] Integration patterns defined (Service Events, JS Interop)
- [x] Performance considerations addressed (Loading shell, Tailwind optimization)

**✅ Implementation Patterns**
- [x] Naming conventions established (PascalCase, camelCase, kebab-case rules)
- [x] Structure patterns defined (Layout/Sections/Shared/Services)
- [x] Communication patterns specified (Service events with IDisposable)
- [x] Process patterns documented (Theme resolution, navigation flow)

**✅ Project Structure**
- [x] Complete directory structure defined (all 17 components + services + assets)
- [x] Component boundaries established (4 boundary types documented)
- [x] Integration points mapped (Internal + External communication flows)
- [x] Requirements to structure mapping complete (all FR categories → components)

### Architecture Readiness Assessment

**Overall Status:** READY FOR IMPLEMENTATION ✅

**Confidence Level:** HIGH

All decisions are coherent, complete, and specific enough for consistent AI agent implementation. No critical or important gaps identified.

**Key Strengths:**
- Clear technology stack with verified compatibility
- Comprehensive naming and structure conventions
- Well-defined component boundaries and communication patterns
- Complete requirements coverage with explicit mappings
- Concrete code examples for key patterns

**Areas for Future Enhancement (Post-MVP):**
- Testing infrastructure and patterns
- Analytics integration architecture
- CMS integration for content management
- Custom domain configuration
- Image optimization pipeline

### Implementation Handoff

**AI Agent Guidelines:**
1. Follow all architectural decisions exactly as documented
2. Use implementation patterns consistently across all components
3. Respect project structure and boundaries (Layout/Sections/Shared/Services)
4. Refer to this document for all architectural questions
5. Use only the defined Tailwind color palette - no exceptions
6. Implement service event pattern with proper IDisposable cleanup

**First Implementation Priority:**

```bash
dotnet new blazorwasm -o BhavanPortfolio --framework net10.0
```

Then: Bootstrap removal, Tailwind v4 setup, index.html loading shell with theme script

## Architecture Completion Summary

### Workflow Completion

**Architecture Decision Workflow:** COMPLETED ✅
**Total Steps Completed:** 8
**Date Completed:** 2026-01-04
**Document Location:** `_bmad-output/planning-artifacts/architecture.md`

### Final Architecture Deliverables

**📋 Complete Architecture Document**
- All architectural decisions documented with specific versions
- Implementation patterns ensuring AI agent consistency
- Complete project structure with all files and directories
- Requirements to architecture mapping
- Validation confirming coherence and completeness

**🏗️ Implementation Ready Foundation**
- 12+ architectural decisions made
- 5 implementation pattern categories defined
- 17 Blazor components + 2 services specified
- 45 FRs + 19 NFRs fully supported

**📚 AI Agent Implementation Guide**
- Technology stack with verified versions (.NET 10, Blazor WASM, Tailwind v4)
- Consistency rules that prevent implementation conflicts
- Project structure with clear boundaries
- Integration patterns and communication standards

### Quality Assurance Checklist

**✅ Architecture Coherence**
- [x] All decisions work together without conflicts
- [x] Technology choices are compatible
- [x] Patterns support the architectural decisions
- [x] Structure aligns with all choices

**✅ Requirements Coverage**
- [x] All 45 functional requirements are supported
- [x] All 19 non-functional requirements are addressed
- [x] Cross-cutting concerns are handled
- [x] Integration points are defined

**✅ Implementation Readiness**
- [x] Decisions are specific and actionable
- [x] Patterns prevent agent conflicts
- [x] Structure is complete and unambiguous
- [x] Examples are provided for clarity

### Project Success Factors

**🎯 Clear Decision Framework**
Every technology choice was made collaboratively with clear rationale, ensuring all stakeholders understand the architectural direction.

**🔧 Consistency Guarantee**
Implementation patterns and rules ensure that multiple AI agents will produce compatible, consistent code that works together seamlessly.

**📋 Complete Coverage**
All project requirements are architecturally supported, with clear mapping from business needs to technical implementation.

**🏗️ Solid Foundation**
The chosen Blazor WASM starter template and architectural patterns provide a production-ready foundation following current best practices.

---

**Architecture Status:** READY FOR IMPLEMENTATION ✅

**Next Phase:** Begin implementation using the architectural decisions and patterns documented herein.

**Document Maintenance:** Update this architecture when major technical decisions are made during implementation.

