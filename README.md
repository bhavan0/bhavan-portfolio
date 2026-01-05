# Bhavan Portfolio

A developer portfolio, built with Blazor WebAssembly and Tailwind CSS v4, deployed to GitHub Pages.

## 🎯 Project Goal

This portfolio embodies a **"less is more"** philosophy - serving technical recruiters, engineering hiring managers, and developer peers through:

- **The codebase IS the portfolio** - The open-source repository demonstrates the same qualities being claimed: clean structure, good practices, thoughtful architecture
- **Dark mode as first-class citizen** - Defaults to what developers actually use, with light mode equally polished
- **Performance-first approach** - Fast loading, smooth interactions, no unnecessary bloat  
- **Recruiter-optimized UX** - Designed for the 8-second scan test with 1-click resume download

The portfolio positions Bhavan as a **Full Stack Developer who gets things done** - reliable, clean code, fast delivery.

## 🤖 Built with BMAD Method (AI Agents)

This project is being built using the **BMAD (Big Model Agent Development) Method** - an agentic approach to software development where specialized AI agents handle different aspects of the project lifecycle.

### How It Works

Instead of traditional development, BMAD uses role-specialized agents that each bring focused expertise:

| Phase | Agent | Responsibility |
|-------|-------|----------------|
| **Analysis** | `analyst` | Brainstorming, research, product brief creation |
| **Planning** | `pm` (Product Manager) | PRD creation, user journeys, requirements |
| **Design** | `ux-designer` | UX specification, wireframes, design system |
| **Solutioning** | `architect` | Technical architecture, component design |
| **Implementation** | `dev` | Story implementation, code writing |
| **Quality** | `tea` (Test Architect) | Test design, quality assurance |
| **Coordination** | `sm` (Scrum Master) | Sprint planning, workflow management |

### Project Artifacts

All BMAD-generated artifacts live in the `_bmad-output/` folder:

```
_bmad-output/
├── analysis/
│   └── brainstorming-session-*.md       # Creative ideation results
├── planning-artifacts/
│   ├── product-brief-*.md               # Vision & target users
│   ├── prd.md                           # Full requirements document  
│   ├── ux-design-specification.md       # UX/design decisions
│   ├── architecture.md                  # Technical architecture
│   └── epics.md                         # Epics and stories
└── implementation-artifacts/
    └── *.md                             # Story implementations
```

### Why BMAD?

1. **Structured approach** - Each phase builds on the previous, creating comprehensive documentation
2. **Specialized expertise** - Each agent focuses on what they do best
3. **Traceability** - Full audit trail from vision → requirements → implementation
4. **Quality gates** - Built-in checkpoints before moving to next phase

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
