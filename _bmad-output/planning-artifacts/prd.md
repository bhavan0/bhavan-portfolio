---
stepsCompleted: [1, 2, 3, 4, 7, 8, 9]
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

## Web Application Specific Requirements

### Browser Support Matrix

| Browser | Version | Support Level |
|---------|---------|---------------|
| Chrome | Latest 2 versions | Full |
| Firefox | Latest 2 versions | Full |
| Safari | Latest 2 versions | Full |
| Edge | Latest 2 versions | Full |
| IE11 | Any | Not Supported |

**Rationale:** Modern evergreen browsers only. No polyfills or legacy support needed, simplifying development and reducing bundle size.

### SEO Strategy

**Target Search Terms:**
- "Bhavan developer"
- "Bhavan Full Stack Developer"
- "Bhavan .Net Developer"
- "Bhavan AI Developer"

**SPA SEO Approach:**
- Semantic HTML structure with proper heading hierarchy
- Meta tags for title, description, keywords
- OpenGraph tags for social sharing previews
- Prerendered index.html with key content visible
- Descriptive alt text on images

**Note:** Full SEO optimization limited by SPA nature - focus on personal branding searches rather than competitive keywords.

### Responsive Design Requirements

| Breakpoint | Target Devices | Layout Behavior |
|------------|----------------|-----------------|
| < 640px | Mobile phones | Single column, hamburger menu, stacked project cards |
| 640-1024px | Tablets | Adaptive columns, condensed navigation |
| > 1024px | Desktop | Full layout, sticky header with all nav items |

**Mobile-First Priorities:**
- Touch-friendly tap targets (minimum 44px)
- Readable text without zooming
- Hamburger menu with smooth animation
- Resume download accessible in mobile menu

### Performance Targets

| Metric | Target | Rationale |
|--------|--------|-----------|
| Lighthouse Performance | 90+ | Industry standard for quality |
| First Contentful Paint | < 1.5s | User perceives page loading |
| Time to Interactive | < 5s | WASM-realistic target |
| Largest Contentful Paint | < 2.5s | Core Web Vitals threshold |
| Styled Loading State | < 500ms | Prevent blank screen |

### Accessibility Level

**Target:** Basic best practices (not formal WCAG compliance)

**Implementation:**
- Semantic HTML elements (nav, main, section, article)
- Keyboard navigation support
- Focus indicators on interactive elements
- Sufficient color contrast in both themes
- Alt text on images
- Skip-to-content link

**Out of Scope:** Full WCAG 2.1 AA compliance, screen reader optimization, automated accessibility testing.

### Implementation Considerations

**Loading State Strategy:**
- Immediate styled HTML shell (hero section visible)
- Subtle fade-in animation during WASM load
- No spinner - use progressive content reveal
- B&W aesthetic maintained during loading

**Theme Implementation:**
- CSS custom properties for color tokens
- localStorage for preference persistence
- System preference detection as fallback
- No flash of wrong theme on reload

## Project Scoping & Phased Development

### MVP Strategy & Philosophy

**MVP Approach:** Experience MVP - Deliver the complete recruiter-first experience with minimal features, focusing on the 8-second scan test and 1-click resume download.

**Why This Approach:**
- Personal portfolio = no revenue pressure
- Single developer = resource-constrained
- Clear success metric = "Does this represent me well?"
- The execution quality IS the product

**Resource Requirements:**
- Solo developer (Bhavan)
- Estimated effort: Weekend project scope
- Tech stack: Familiar (.NET/Blazor ecosystem)

### MVP Feature Set (Phase 1)

**Core User Journeys Supported:**
- Rachel's 8-Second Decision (primary)
- Marcus's Technical Validation (GitHub link prominent)
- Dev's Peer Assessment (clean codebase)
- Mobile Check (full responsive parity)

**Must-Have Capabilities:**

| Capability | Journey Support | MVP Priority |
|------------|-----------------|--------------|
| Sticky header with resume download | Rachel - 1-click access | Critical |
| Hero with name/title | Rachel - 8-second scan | Critical |
| Skills section (scannable) | Rachel - quick validation | Critical |
| Projects section (3+ cards) | Rachel, Marcus - credibility | Critical |
| GitHub links | Marcus, Dev - code validation | Critical |
| Dark mode default | Marcus, Dev - developer preference | Critical |
| Mobile hamburger menu | Rachel Redux - mobile parity | Critical |
| Styled loading state | All - no "back button moment" | Critical |
| Clean component architecture | Dev - codebase quality | Critical |

**Explicitly Out of MVP:**
- Analytics/tracking
- Contact form (links only)
- Blog/writing section
- Project filtering
- Live demos/previews
- CMS integration

### Post-MVP Features

**Phase 2 (Growth):**
- Project live previews or interactive demos
- "Unexpected element" - memorable detail that sparks conversation
- Blog or writing section for thought leadership
- Data-driven project content (JSON/model for easier updates)
- Enhanced project filtering/sorting

**Phase 3 (Expansion):**
- Custom domain (bhavan.dev or similar)
- CMS for easier content updates
- Multilingual support
- Case study deep-dives with detailed project breakdowns
- Testimonials section

### Risk Mitigation Strategy

**Technical Risks:**

| Risk | Likelihood | Mitigation |
|------|------------|------------|
| Blazor WASM bundle size (2-5MB) | High | Styled loading state, lazy loading |
| Lighthouse score <90 | Medium | Pre-render critical content, optimize images |
| Theme flash on reload | Medium | localStorage check before render |

**Market Risks:**
- None significant - personal portfolio, not competing for market share
- Risk: Portfolio becomes outdated → Mitigation: Simple update workflow

**Resource Risks:**
- Solo developer → Keep scope minimal, avoid feature creep
- Time constraints → MVP-first, growth features only when time permits

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

## Functional Requirements

### Navigation & Header

- FR1: Visitors can see a sticky header that remains visible while scrolling
- FR2: Visitors can navigate to any section using header navigation links
- FR3: Visitors can download the resume PDF in one click from the header
- FR4: Visitors can toggle between dark and light themes
- FR5: Mobile visitors can access navigation through a hamburger menu
- FR6: Mobile visitors can access resume download from the mobile menu

### Hero Section

- FR7: Visitors can see the developer's name prominently displayed
- FR8: Visitors can see the developer's title/role (Full Stack Developer)
- FR9: Visitors can read a brief professional introduction

### About Section

- FR10: Visitors can read a personal/professional summary
- FR11: Visitors can understand the developer's background and approach

### Skills Section

- FR12: Visitors can identify key skills through scannable visual organization
- FR13: Visitors can see skills organized in a scannable visual format
- FR14: Visitors can identify primary technology competencies

### Projects Section

- FR15: Visitors can view at least 3 project showcases
- FR16: Visitors can see project title, description, and technologies used for each project
- FR17: Visitors can view a screenshot or visual for each project
- FR18: Visitors can access the GitHub repository link for each project
- FR19: Visitors can access live demo links when available for projects
- FR20: Visitors can see visual feedback when interacting with project cards

### Timeline Section

- FR21: Visitors can view work experience in chronological order
- FR22: Visitors can see role titles, companies, and timeframes
- FR23: Visitors can understand career progression

### Contact Section

- FR24: Visitors can access the developer's email address
- FR25: Visitors can access the developer's LinkedIn profile
- FR26: Visitors can access the developer's GitHub profile

### Footer

- FR27: Visitors can access the portfolio's source code repository
- FR28: Visitors can access social links from the footer

### Theme & Appearance

- FR29: The site can default to dark mode on initial visit
- FR30: The site can persist theme preference across sessions
- FR31: The site can detect and respect system theme preference as fallback
- FR32: The site can resolve theme using priority: stored preference > system preference > dark default
- FR33: The theme toggle can provide immediate visual transition feedback

### Loading Experience

- FR34: Visitors can see styled content within 500ms of page request
- FR35: Visitors can see a progressive content reveal during WASM initialization
- FR36: The loading state can maintain the B&W aesthetic
- FR37: Visitors can see a fallback message if the application fails to initialize

### Responsive Design

- FR38: The site can adapt layout for mobile devices (< 640px)
- FR39: The site can adapt layout for tablet devices (640-1024px)
- FR40: The site can adapt layout for desktop devices (> 1024px)
- FR41: Touch targets can meet minimum 44px size on mobile

### Navigation Experience

- FR42: Visitors can experience smooth scroll navigation between sections

### SEO & Discoverability

- FR43: The site can provide meta tags for search engines
- FR44: The site can provide OpenGraph tags for social sharing
- FR45: The site can use semantic HTML structure

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
