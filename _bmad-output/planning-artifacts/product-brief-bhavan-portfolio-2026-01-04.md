---
stepsCompleted: [1, 2, 3, 4, 5]
inputDocuments:
  - "_bmad-output/analysis/brainstorming-session-2026-01-04.md"
  - "_bmad-output/planning-artifacts/research/domain-technical-portfolio-research-2026-01-04.md"
date: 2026-01-04
author: Bhavan
---

# Product Brief: Bhavan Portfolio

## Executive Summary

Bhavan Portfolio is a personal developer portfolio website designed to serve recruiters, engineering hiring managers, and developers through a singular philosophy: **less is more**. Built with Blazor WebAssembly, Tailwind CSS, and hosted on GitHub Pages, the portfolio demonstrates technical competence not through flashy features, but through clean execution, fast performance, and polished design.

The portfolio positions Bhavan as a **Full Stack Developer who gets things done** - reliable, clean code, fast delivery, and technical depth. The open-source codebase itself serves as proof of these qualities.

---

## Core Vision

### Problem Statement

Developers need a way to present their professional identity, skills, and work to diverse audiences (technical recruiters scanning in 8 seconds, engineering hiring managers evaluating fit, peers assessing technical depth) without maintaining multiple presentations or cluttered portfolios that dilute their message.

### Problem Impact

- Technical recruiters skip portfolios that don't immediately communicate competence
- Developers lose opportunities when their portfolio doesn't reflect their actual skill level
- Engineering hiring managers need quick validation of both technical ability and professional polish
- Peers can't assess credibility for referrals without clear evidence of competence

### Why Existing Solutions Fall Short

Most developer portfolios suffer from:
- Over-engineering that obscures rather than demonstrates skill
- Template-driven sameness that fails to differentiate
- Feature bloat that slows performance and clutters the message
- Inconsistent quality between light/dark modes
- Poor loading experiences during initial WASM download

### Proposed Solution

A minimalist, Apple-inspired portfolio with:
- **B&W + subtle grays** aesthetic with dark mode default
- **Both dark/light modes equally polished** (not an afterthought)
- **Six focused sections**: Hero, About, Skills, Projects, Contact, Timeline
- **Beautiful loading state** with simple fade-in matching the B&W aesthetic
- **Resume download button** as primary recruiter CTA
- **"Built with Blazor" visibility** in footer/colophon
- **Subtle animations and scroll effects** that enhance without distracting

### Key Differentiators

1. **The codebase IS the portfolio** - Open-source repository demonstrates the same qualities being claimed (clean structure, good practices)
2. **README and inline comments** for key decision points showcase thought process
3. **Dark mode as first-class citizen** - Default to what developers actually use
4. **Performance-first approach** - Fast load, smooth interactions, no unnecessary bloat
5. **"Getting things done" philosophy** visible in every detail - from load time to navigation

---

## Target Users

### Primary Users

**Rachel - Technical Recruiter**

A technical recruiter at a mid-size company or agency, screening 50+ candidates weekly. She has your portfolio open in one of 20 browser tabs, giving it 8-15 seconds before deciding to dig deeper or move on.

**Goals:**
- Quickly validate "Is this developer worth presenting to the engineering hiring manager?"
- Find skills that match job requirements
- See evidence of real work, not just tutorials
- Grab resume and contact info efficiently

**Success Criteria:** "This looks clean, skills match, projects are relevant - downloading resume now."

**Critical UX Requirements:**
- Resume download in sticky header (accessible within 1 click from any page position)
- Hero must communicate value in F-pattern scan zones (Name/Title top-left, CTA visible)
- First 3 seconds must prevent the "back button moment"

**Testable Acceptance Criteria:**
- [ ] Page loads in under 3 seconds on 3G
- [ ] Name + Title visible without scroll
- [ ] Resume download accessible within 1 click from any page position (sticky header)
- [ ] Skills section scannable in under 5 seconds
- [ ] At least 3 project examples visible

### Secondary Users

**Marcus - Engineering Hiring Manager**

Received the candidate profile from a technical recruiter, doing deeper technical validation. Assesses team fit technically and culturally by reviewing project depth, code quality (may check GitHub), and communication clarity.

**Dev (Technical Evaluator)**

Senior developer on hiring committee who validates technical decisions. Digs into GitHub, reviews code structure, assesses architectural choices.

**Dev (Peer/Referrer)**

Fellow developer who found the portfolio through GitHub, conferences, or networking. Needs to trust competence enough to stake their reputation on a referral.

**Testable Acceptance Criteria (Secondary Users):**
- [ ] GitHub link prominent
- [ ] Code demonstrates claimed skills
- [ ] README explains key decisions

*Note: Secondary user journeys out of scope for MVP. Recruiter-optimized design benefits secondary users as side effect.*

### User Journey (Primary: Technical Recruiter)

| Stage | Experience |
|-------|------------|
| **Discovery** | LinkedIn link, job application, or Google search |
| **First Impression (8 sec)** | Hero loads fast, sees [Title - TBD], clean design signals professionalism |
| **Validation** | Scrolls to Skills - checks requirements. Projects - sees real work |
| **Action** | Downloads resume via sticky header, copies contact email |
| **Outcome** | Presents candidate to engineering hiring manager with confidence |

---

## Success Metrics

### Product Success (Quality Focus)

For this phase, success is measured by **quality of execution**, not conversion metrics or analytics. The portfolio succeeds when it meets the high bar set in the vision.

**Core Quality Criteria:**
- Clean, professional presentation that reflects "getting things done" philosophy
- Both dark and light modes equally polished
- Fast, smooth experience across devices
- Codebase quality matches the portfolio's claims

### Technical Performance Indicators

| Metric | Target |
|--------|--------|
| **Lighthouse Performance** | 90+ |
| **First Contentful Paint** | < 1.5s |
| **Time to Interactive** | < 5s (WASM realistic target) |
| **Largest Contentful Paint** | < 2.5s |
| **Loading Experience** | Styled content visible within 500ms |
| **Mobile Responsive** | Full parity with desktop |

*Note: Blazor WASM has a 2-5MB runtime. Targets assume Brotli compression and styled loading state to mask initial download.*

### User Experience Success

| Criteria | Validation |
|----------|------------|
| **8-Second Test** | New visitor can identify name, title, and find resume in 8 seconds |
| **Theme Toggle - Smooth** | Toggle transition has no flash, smooth animation |
| **Theme Toggle - Readable** | No unreadable text in either mode |
| **Theme Toggle - Hierarchy** | Same visual hierarchy maintained in both modes |
| **Loading Experience** | Styled loading state, not blank screen or spinner |
| **Navigation Clarity** | All 6 sections accessible within 2 clicks |

### Codebase Quality

**Project Structure:**
```
/Components
  /Layout (Header, Footer, Navigation)
  /Sections (Hero, About, Skills, Projects, Contact, Timeline)
  /Shared (ThemeToggle, ProjectCard, SkillBadge)
/wwwroot
  /css (or Tailwind setup)
  /assets (images, resume PDF)
/Services (theme state, etc.)
```

**Code Criteria:**
- [ ] No components > 200 lines
- [ ] Consistent naming (PascalCase components)
- [ ] CSS organized by component or utility-first pattern
- [ ] No commented-out code in main branch
- [ ] README with setup instructions and key architectural decisions
- [ ] Inline comments for key decision points only (not over-commented)

*Note: Analytics and conversion tracking out of scope for MVP. Success is qualitative - "does this represent me well?" - validated through self-review and peer feedback.*

---

## MVP Scope

### Core Features

**1. Foundation**
- Blazor WASM project with Tailwind CSS
- GitHub Pages deployment with template GitHub Actions workflow
- Dark mode default with light mode toggle
- Styled loading state (fade-in, B&W aesthetic)
- Single page with smooth scroll navigation
- Full mobile responsiveness

**2. Sticky Header**
- Name/Logo (top-left)
- Navigation links to all sections
- Resume download button (1-click, PDF)
- Theme toggle
- Mobile: Hamburger menu with same functionality

**3. Six Sections**
| Section | Purpose |
|---------|---------|
| **Hero** | Name, Title [TBD], brief intro - immediate value communication |
| **About** | Personal/professional summary |
| **Skills** | Tech stack visualization (scannable in 5 seconds) |
| **Projects** | 3+ project showcases (can link to detail route) |
| **Timeline** | Work experience chronology |
| **Contact** | Email, LinkedIn, GitHub links |

**4. Project Card Fields**
Each project showcase includes:
- Title
- Description
- Tech stack used
- GitHub link
- Screenshot (if available)

*Note: Project content hardcoded for MVP. Refactor to data-driven if project count grows.*

**5. Footer**
- "Built with Blazor" colophon
- Social links (GitHub, LinkedIn)

**6. Codebase Quality**
- Clean component structure per defined architecture
- README with setup instructions and key architectural decisions
- Inline comments for key decision points only

### Out of Scope for MVP

| Feature | Rationale |
|---------|-----------|
| Project live previews/embeds | Enhancement for future phase |
| "Unexpected element" / easter eggs | Defer to future phase |
| Analytics / tracking | Quality focus, not metrics |
| Contact form | Email link sufficient for MVP |
| Blog section | Not core to recruiter journey |
| CONTRIBUTING.md | Personal project, not open for contributions |
| Automated testing | Defer per user decision |
| Secondary user journey optimization | Recruiter-first, others benefit as side effect |
| Internationalization (i18n) | English only for MVP |
| Data-driven project content | Hardcoded sufficient for 3-5 projects |

### Future Vision

**Phase 2 Enhancements (Post-MVP):**
- Project live previews/interactive demos
- "Unexpected element" or memorable detail
- Blog or writing section
- Data-driven project content (JSON/model)
- Enhanced project filtering/categorization

**Long-term Possibilities:**
- Custom domain
- CMS for easier content updates
- Multilingual support
- Case study deep-dives

*The MVP establishes a solid, professional foundation. Future phases add personality and depth without compromising the core "less is more" philosophy.*
