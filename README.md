# Bhavan Portfolio

A modern developer portfolio built with Blazor WebAssembly and Tailwind CSS v4, deployed to GitHub Pages. This project serves as both a personal portfolio and a demonstration of AI-assisted development using the BMAD Method.

## 🎯 Project Goal

This portfolio was created with two primary objectives:

### 1. Professional Portfolio
A clean, modern portfolio to showcase skills and projects to technical recruiters, engineering hiring managers, and developer peers. The design philosophy centers on:

- **The codebase IS the portfolio** - The open-source repository demonstrates the same qualities being claimed: clean structure, good practices, thoughtful architecture
- **Dark mode as first-class citizen** - Defaults to what developers actually use, with light mode equally polished
- **Performance-first approach** - Fast loading, smooth interactions, no unnecessary bloat
- **Recruiter-optimized UX** - Designed for the 8-second scan test with 1-click resume download

### 2. BMAD Method Exploration
This project served as a real-world testbed for exploring the **BMAD (Big Model Agent Development) Method** - demonstrating how AI agents can assist throughout the entire software development lifecycle, from initial brainstorming to production deployment.

## 🤖 Built with BMAD Method

This project was developed using the **BMAD Method** - an agentic approach to software development where specialized AI agents handle different aspects of the project lifecycle. The entire development process, from initial concept to deployed application, was guided by BMAD workflows.

### Development Journey

The project progressed through BMAD's structured phases:

1. **Analysis Phase** - Used the `analyst` agent for brainstorming sessions, exploring portfolio concepts, target audiences, and unique value propositions
2. **Planning Phase** - The `pm` agent created a comprehensive PRD with user journeys, success metrics, and detailed requirements
3. **Design Phase** - The `ux-designer` agent produced UX specifications including wireframes, design system tokens, and interaction patterns
4. **Solutioning Phase** - The `architect` agent designed the technical architecture, component structure, and implementation approach
5. **Implementation Phase** - The `dev` agent executed stories, writing production code following the architectural decisions
6. **Iteration** - Continuous refinement with direct AI assistance for features, bug fixes, and enhancements

### BMAD Agents Used

| Phase | Agent | What It Did |
|-------|-------|-------------|
| **Analysis** | `analyst` | Brainstormed portfolio concepts, identified target users, defined unique selling points |
| **Planning** | `pm` | Created PRD with user stories, acceptance criteria, and success metrics |
| **Design** | `ux-designer` | Designed component layouts, color schemes, typography, and responsive breakpoints |
| **Solutioning** | `architect` | Defined Blazor component architecture, service patterns, and build pipeline |
| **Implementation** | `dev` | Wrote all components, services, and styles following the architecture |
| **Coordination** | `sm` | Managed sprint planning and story prioritization |

### Project Artifacts

All BMAD-generated artifacts are preserved in the `_bmad-output/` folder, providing full traceability from concept to code:

```
_bmad-output/
├── analysis/
│   └── brainstorming-session-*.md       # Initial ideation and concept exploration
├── planning-artifacts/
│   ├── product-brief-*.md               # Vision, goals, and target users
│   ├── prd.md                           # Complete requirements document
│   ├── ux-design-specification.md       # Design system and UX decisions
│   ├── architecture.md                  # Technical architecture
│   └── epics.md                         # Epics broken into implementable stories
└── implementation-artifacts/
    └── *.md                             # Individual story implementations
```

### Key Takeaways from Using BMAD

1. **Structured thinking** - The phased approach ensured thorough requirements before coding began
2. **Documentation as a byproduct** - Every decision is documented, making the project maintainable
3. **Faster iteration** - AI assistance accelerated development while maintaining quality
4. **Learning tool** - The process revealed best practices for Blazor, Tailwind, and modern web development

> Learn more about BMAD at the [BMAD Method repository](https://github.com/bmadcode/bmad-agent)

---

## Tech Stack

- **Framework:** Blazor WebAssembly (.NET 10)
- **Styling:** Tailwind CSS v4 (standalone CLI)
- **Hosting:** GitHub Pages
- **CI/CD:** GitHub Actions

## Features

- Dark/Light theme with system preference detection
- Responsive design (mobile, tablet, desktop)
- SEO optimized with meta tags and OpenGraph
- Fast loading with static HTML shell
- Smooth scroll navigation

## Local Development

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Tailwind CSS CLI (downloaded automatically on first build, or manually from [Tailwind releases](https://github.com/tailwindlabs/tailwindcss/releases))

### Running Locally

```bash
cd BhavanPortfolio

# Build and run (Tailwind compiles via MSBuild target)
dotnet run

# Or with hot reload
dotnet watch run
```

### Manual Tailwind Build

```bash
cd BhavanPortfolio

# Development (with watch)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --watch

# Production (minified)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify
```

## Project Structure

```
BhavanPortfolio/
├── Components/
│   ├── Layout/        # MainLayout, NavBar, Footer
│   ├── Sections/      # Hero, About, Skills, Projects, Timeline, Contact
│   └── Shared/        # Reusable components (ThemeToggle, ProjectCard, etc.)
├── Services/          # ThemeService, ScrollService
├── wwwroot/
│   ├── css/           # Tailwind output
│   ├── js/            # JS interop modules
│   └── assets/        # Images, resume PDF
├── tailwind-input.css # Tailwind directives
└── tailwind.config.js # Tailwind configuration
```

## Deployment

Deployment is automated via GitHub Actions:

1. Push changes to the `main` branch
2. GitHub Actions workflow triggers automatically
3. Tailwind CSS is compiled with minification
4. Blazor WASM app is published
5. Site is deployed to GitHub Pages

### Manual Deployment

```bash
cd BhavanPortfolio

# Build Tailwind (minified)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify

# Publish Blazor
dotnet publish -c Release -o publish

# Deploy publish/wwwroot to GitHub Pages
```

## Configuration

### Theme System

The site supports dark and light themes with the following priority:
1. User preference (stored in localStorage)
2. System preference (prefers-color-scheme)
3. Default: dark

### Base Href

For deployment to a repository project page (e.g., `username.github.io/repo-name`), update the base href in `wwwroot/index.html`:

```html
<base href="/repo-name/" />
```

For user/organization pages (`username.github.io`), keep it as:

```html
<base href="/" />
```

## License

MIT
