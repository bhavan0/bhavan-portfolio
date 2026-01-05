---
stepsCompleted: [1, 2]
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

