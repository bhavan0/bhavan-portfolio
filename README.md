# Bhavan Portfolio

A modern developer portfolio built with Blazor WebAssembly and Tailwind CSS v4, deployed to Azure Static Web Apps. This project serves as both a personal portfolio and a demonstration of AI-assisted development — initially built with the BMAD Method, now maintained using Spec-Driven Development with Antigravity.

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

### Reflections: From BMAD to Spec-Driven Development

While the BMAD Method provided excellent structure for this project, a key finding emerged through the process:

> **BMAD is a powerful but heavy framework** — its multi-agent, multi-phase approach (analyst → PM → UX designer → architect → dev → SM) is well-suited for large, complex projects with cross-functional teams. However, for smaller projects like a personal portfolio, the overhead of maintaining multiple agent personas, lengthy artifact chains, and formal phase gates introduced more friction than value.

#### The Shift: Spec-Driven Development with Antigravity

After the initial build, ongoing feature work and iterations shifted to a leaner approach — **Spec-Driven Development (SDD)** powered by [Antigravity](https://github.com/chromaorg/antigravity):

| Aspect | BMAD | Spec-Driven Development |
|--------|------|------------------------|
| **Best for** | Large, multi-team projects | Small–medium projects, solo/small teams |
| **Process** | 6 specialized agents, formal phase gates | Single agent, spec-first iteration |
| **Overhead** | High — multiple artifacts per phase | Low — lightweight specs, fast execution |
| **Speed** | Thorough but slower ramp-up | Rapid iteration with clear intent |
| **Traceability** | Full artifact chain | Specs + version control history |

**Why SDD with Antigravity works better here:**
- **Spec as the single source of truth** — A concise spec document captures intent, constraints, and acceptance criteria without the overhead of separate PRDs, UX docs, and architecture artifacts
- **Faster feedback loops** — Go from idea → spec → implementation → verification in a single focused session
- **Right-sized process** — The framework scales with the project instead of imposing enterprise-level ceremony on a personal site
- **AI-native workflow** — Antigravity's agentic capabilities handle planning, execution, and verification fluidly without needing to switch between specialized agent personas

---

## Tech Stack

- **Frontend:** Blazor WebAssembly (.NET 10)
- **Backend API:** Azure Functions (.NET 8, Isolated Worker)
- **AI:** OpenRouter (GPT-4o-mini) for the portfolio chatbot
- **Styling:** Tailwind CSS v4 (standalone CLI)
- **Hosting:** Azure Static Web Apps
- **CI/CD:** GitHub Actions → Azure Static Web Apps deployment
- **Analytics:** Google Analytics

## Features

- Dark/Light theme with system preference detection
- Responsive design (mobile, tablet, desktop)
- SEO optimized with meta tags, OpenGraph, and JSON-LD structured data
- Fast loading with static HTML shell
- Smooth scroll navigation
- **🤖 AI Chatbot ("Bhavan Bot")** — An interactive AI assistant powered by OpenRouter that answers questions about skills, projects, and experience
- **Google Analytics Integration** for traffic insights
- **Interactive Project Modals** for detailed case studies
- **Rich Technical Skills Display** with categorized visual breakdowns
- **Grouped Work Experience Timeline** with company groups and role progression

## Featured Projects

This portfolio demonstrates engineering capabilities across multiple domains. Explore the interactive "Projects" section in the app for full details, architecture diagrams, and case studies.

| Project | Domain | Key Tech Stack |
|---------|--------|----------------|
| **Budget App** | Full Stack / AI | .NET 10, React 19, Azure, PostgreSQL, OpenAI |
| **Pharma Supply Chain** | Blockchain | Ethereum, Solidity, Angular, MongoDB |
| **Architect for Men** | Mobile / Full Stack | Angular, Python Flask, AWS, Twilio |
| **Eco Voice Assistant** | Voice AI | Dialogflow, Firebase, TypeScript, Google Assistant |
| **Events NFT Marketplace** | Web3 / NFT | Angular, Solidity, Truffle, Web3.js |
| **Create Fullstack App** | Dev Tools / CLI | Node.js, Docker, .NET, Angular/React |
| **LockApp** | Mobile / Wellbeing | React Native, Kotlin, TypeScript, EmailJS |
| **Bhavan Portfolio** | Frontend Engineering | Blazor WASM, Tailwind CSS v4, GitHub Actions |

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
├── Api/                       # Azure Functions backend
│   ├── Functions/             # HTTP-triggered functions (ChatFunction)
│   ├── system-prompt.txt      # AI chatbot persona and knowledge base
│   └── Program.cs             # Function app configuration
├── BhavanPortfolio/           # Blazor WebAssembly frontend
│   ├── Components/
│   │   ├── Layout/            # MainLayout, NavBar, Footer
│   │   ├── Sections/          # Hero, About, Skills, Projects, Timeline, Education, Contact
│   │   ├── Shared/            # Reusable components (CompanyGroup, RoleItem, ProjectCard, etc.)
│   │   └── ChatBot.razor      # AI chatbot widget
│   ├── Services/              # ThemeService, ScrollService
│   ├── wwwroot/
│   │   ├── css/               # Tailwind output
│   │   ├── assets/            # Images, resume PDF
│   │   └── staticwebapp.config.json  # Azure SWA routing config
│   ├── tailwind-input.css     # Tailwind directives
│   └── tailwind.config.js     # Tailwind configuration
└── _bmad-output/              # BMAD artifacts (preserved for reference)
```

## Deployment

Deployment is automated via GitHub Actions to **Azure Static Web Apps**:

1. Push changes to the `main` branch
2. GitHub Actions workflow triggers automatically
3. Tailwind CSS is compiled with minification
4. Blazor WASM app is published
5. Azure Functions API is built
6. Both frontend and API are deployed to Azure Static Web Apps

### Manual Deployment

```bash
cd BhavanPortfolio

# Build Tailwind (minified)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify

# Publish Blazor
dotnet publish -c Release -o publish
```

## Configuration

### Theme System

The site supports dark and light themes with the following priority:
1. User preference (stored in localStorage)
2. System preference (prefers-color-scheme)
3. Default: dark

### Base Href

For Azure Static Web Apps with a custom domain, the base href should be:

```html
<base href="/" />
```

## License

MIT
