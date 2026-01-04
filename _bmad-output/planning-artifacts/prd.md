---
stepsCompleted: [1, 2, 3]
inputDocuments:
  - "_bmad-output/planning-artifacts/product-brief-bhavan-portfolio-2026-01-04.md"
  - "_bmad-output/planning-artifacts/research/domain-technical-portfolio-research-2026-01-04.md"
  - "_bmad-output/analysis/brainstorming-session-2026-01-04.md"
workflowType: 'prd'
lastStep: 1
documentCounts:
  brief: 1
  research: 1
  brainstorming: 1
  projectDocs: 0
---

# Product Requirements Document - Bhavan Portfolio

**Author:** Bhavan
**Date:** 2026-01-04

## Executive Summary

Bhavan Portfolio is a personal developer portfolio website that demonstrates technical competence through clean execution rather than flashy features. Built with Blazor WebAssembly, Tailwind CSS, and hosted on GitHub Pages, this minimalist single-page site embodies a "less is more" philosophy inspired by Apple's design principles.

The portfolio serves technical recruiters as the primary audience - professionals who screen 50+ candidates weekly and spend just 8-15 seconds deciding whether to dig deeper. Every design decision optimizes for this 8-second scan: sticky header with 1-click resume download, F-pattern layout for immediate value communication, and fast loading to prevent the "back button moment."

The product positions Bhavan as a **Full Stack Developer who gets things done** - reliable, clean code, fast delivery, and technical depth. Secondary audiences (engineering hiring managers and developer peers) benefit from the same recruiter-optimized design while finding deeper validation through the open-source codebase itself.

### What Makes This Special

1. **The codebase IS the portfolio** - The open-source repository demonstrates the same qualities being claimed: clean structure, good practices, thoughtful architecture
2. **Dark mode as first-class citizen** - Defaults to what developers actually use, with light mode equally polished (not an afterthought)
3. **Performance-first approach** - Lighthouse 90+, Time to Interactive <5s, styled loading state to mask WASM download
4. **"Getting things done" philosophy** - Visible in every detail from load time to navigation clarity
5. **Recruiter-optimized UX** - 8-second test validation, resume download in sticky header, scannable skills section

## Project Classification

**Technical Type:** Web Application (SPA)
**Domain:** General (Personal Portfolio)
**Complexity:** Low
**Project Context:** Greenfield - new project

**Technology Stack:**
- Frontend: Blazor WebAssembly (.NET 10)
- Styling: Tailwind CSS v4
- Hosting: GitHub Pages
- CI/CD: GitHub Actions (template workflow)

**Repository Strategy:** Public GitHub repository serving dual purpose - deployment source AND portfolio artifact demonstrating code quality

**Key Technical Considerations:**
- Single page with smooth scroll navigation
- Dark/light mode toggle with localStorage persistence
- Mobile-responsive with hamburger menu
- Styled loading state for WASM initialization

## Success Criteria

### User Success

**Primary User (Rachel - Technical Recruiter):**
- Identifies name, title, and finds resume download within 8 seconds
- Downloads resume in 1 click from any scroll position (sticky header)
- Feels confident presenting candidate to engineering hiring manager
- Success statement: "This looks clean, skills match, projects are relevant - downloading resume now."

**Secondary Users (Hiring Manager, Dev Peers):**
- GitHub link prominent and accessible
- Codebase demonstrates claimed skills through clean structure
- README explains key architectural decisions

### Business Success

**Primary Metric:** Self-validation - "Does this represent me well?"

This is a personal portfolio, not a revenue-generating product. Success is qualitative:
- Pride in the finished product
- Confidence when sharing the link
- Positive peer feedback when solicited
- No analytics or conversion tracking required

**Long-term Indicator:** Portfolio serves as a reliable professional presence when opportunities arise.

### Technical Success

| Metric | Target |
|--------|--------|
| **Lighthouse Performance** | 90+ |
| **First Contentful Paint** | < 1.5s |
| **Time to Interactive** | < 5s |
| **Largest Contentful Paint** | < 2.5s |
| **Loading Experience** | Styled content visible within 500ms |
| **Mobile Responsive** | Full parity with desktop |

**Theme Quality:**
- Toggle transition smooth (no flash)
- No unreadable text in either mode
- Same visual hierarchy in both modes

**Codebase Quality:**
- No components > 200 lines
- Consistent naming (PascalCase)
- CSS utility-first pattern
- No commented-out code in main branch
- README with setup instructions
- Inline comments for key decisions only

### Measurable Outcomes

| Outcome | Validation Method |
|---------|-------------------|
| 8-Second Test | Manual test with new visitor |
| Resume Accessibility | 1-click from any page position |
| Theme Polish | Visual review both modes |
| Performance Targets | Lighthouse audit |
| Mobile Parity | Device testing |
| Code Quality | Self-review against criteria |

## Product Scope

### MVP - Minimum Viable Product

**Foundation:**
- Blazor WASM project with Tailwind CSS v4
- GitHub Pages deployment with template GitHub Actions workflow
- Dark mode default with light mode toggle
- Styled loading state (fade-in, B&W aesthetic)
- Single page with smooth scroll navigation
- Full mobile responsiveness

**Sticky Header:**
- Name/Logo (top-left)
- Navigation links to all sections
- Resume download button (1-click, PDF)
- Theme toggle
- Mobile: Hamburger menu

**Six Sections:**
| Section | Purpose |
|---------|---------|
| Hero | Name, Title, brief intro |
| About | Personal/professional summary |
| Skills | Tech stack (scannable in 5 seconds) |
| Projects | 3+ showcases with title, description, tech, GitHub link, screenshot |
| Timeline | Work experience chronology |
| Contact | Email, LinkedIn, GitHub links |

**Footer:**
- "Built with Blazor" colophon
- Social links

**Codebase:**
- Clean component structure
- README with setup/architecture
- Inline comments for key decisions

### Growth Features (Post-MVP)

- Project live previews/interactive demos
- "Unexpected element" or memorable detail
- Blog or writing section
- Data-driven project content (JSON/model)
- Enhanced project filtering

### Vision (Future)

- Custom domain
- CMS for easier content updates
- Multilingual support
- Case study deep-dives
