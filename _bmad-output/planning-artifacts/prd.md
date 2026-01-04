---
stepsCompleted: [1, 2, 3, 4]
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

## User Journeys

### Journey 1: Rachel Chen - The 8-Second Decision

Rachel is a senior technical recruiter at a mid-size fintech company, currently filling three Full Stack Developer positions. It's Tuesday afternoon, and she has 47 candidates to screen before her 4pm hiring manager sync. She's got LinkedIn, her ATS, and about 15 portfolio tabs open across two monitors. Slack is pinging constantly.

She clicks Bhavan's portfolio link from his job application. The page loads fast - a clean black and white design appears with a subtle fade-in. No spinner, no waiting. Her eyes dart to the top left: "Bhavan - Full Stack Developer." Good, matches the role. Top right: Resume button. She makes a mental note.

She scrolls down. Skills section - clean badges, easy to scan. React, .NET, Azure... checks the boxes. Projects section - three cards with screenshots. One catches her eye: "Real-time collaboration tool" - relevant to their product. She doesn't click through; she's seen enough.

Back to the sticky header. One click on "Resume" - PDF downloads instantly. She drags it into the ATS, tags the candidate as "Phone Screen," and moves to the next tab. Total time: 12 seconds. Bhavan made the cut.

### Journey 2: Marcus Wong - The Technical Validation

Marcus is the engineering manager who received Bhavan's profile from Rachel with the note: "Skills match, clean portfolio, worth a look." He's got 20 minutes before his next meeting to decide if this candidate warrants a technical interview slot.

He clicks the portfolio link. Dark mode loads by default - he appreciates that. Scrolls past the hero to Projects. The "real-time collaboration tool" Rachel mentioned. He clicks the GitHub link, opens in new tab.

Back on the portfolio, he scans the Skills section more carefully. Blazor, .NET 10, Azure... the tech stack aligns with their modernization initiative. He checks the Timeline - 5 years of relevant experience, progressive responsibility.

He switches to the GitHub tab. Clean README, clear architecture explanation. He clicks into the src folder - organized components, reasonable file sizes. Opens a random component file - PascalCase naming, consistent patterns, no commented-out code. The code looks like the portfolio claims: clean and professional.

Marcus replies to Rachel: "Schedule the technical screen. I'll take this one myself."

### Journey 3: Dev Patel - The Peer Assessment

Dev is a senior engineer on Marcus's team. They met Bhavan briefly at a .NET meetup last month and exchanged LinkedIn connections. Now Dev notices Bhavan updated his profile with a portfolio link. Curious, he clicks through during his lunch break.

The dark mode site loads. "Built with Blazor" in the footer catches his eye - impressive choice for a portfolio. He's genuinely curious how it performs. Opens DevTools, runs Lighthouse. 92 performance score on a Blazor WASM site? That's solid.

He digs into the GitHub repo. The component architecture is clean - separate Layout, Sections, and Shared folders. The ThemeToggle implementation catches his attention - localStorage persistence, no flash on reload. He bookmarks a pattern he might use himself.

Dev screenshots the portfolio and drops it in their team's #cool-stuff Slack channel: "Met this dev at the .NET meetup. Check out his portfolio - Blazor WASM with actually good performance. We should interview him for that senior role."

### Journey 4: Rachel Redux - The Mobile Check

It's 9pm. Rachel is on her couch, doing one final candidate review on her phone before tomorrow's hiring committee. She pulls up Bhavan's portfolio on mobile.

The hamburger menu works smoothly. She taps "Projects" - smooth scroll to the section. The project cards stack nicely, screenshots resize well. She taps the Resume button - PDF opens in her phone's viewer.

She texts Marcus: "That Bhavan candidate looks good on mobile too. Moving him to final round."

### Journey Requirements Summary

| Capability | Revealed By |
|------------|-------------|
| Fast initial load with styled loading state | Rachel's 8-second decision |
| Sticky header with always-visible Resume button | Rachel's quick download |
| Scannable Skills section | Rachel's rapid validation |
| Prominent GitHub links | Marcus's technical deep-dive |
| Clean, demonstrable codebase | Dev's peer assessment |
| Mobile-responsive with full functionality | Rachel's mobile check |
| Dark mode default, light mode option | Marcus, Dev appreciation |
| Lighthouse-auditable performance | Dev's technical curiosity |
