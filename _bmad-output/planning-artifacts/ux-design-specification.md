---
stepsCompleted: [1, 2, 3, 4, 5, 6, 7]
inputDocuments:
  - "_bmad-output/planning-artifacts/product-brief-bhavan-portfolio-2026-01-04.md"
  - "_bmad-output/planning-artifacts/prd.md"
  - "_bmad-output/planning-artifacts/architecture.md"
  - "_bmad-output/project-context.md"
workflowType: 'ux-design'
lastStep: 1
project_name: 'bhavan-portfolio'
user_name: 'Bhavan'
date: '2026-01-04'
---

# UX Design Specification - Bhavan Portfolio

**Author:** Bhavan
**Date:** 2026-01-04

---

## Executive Summary

### Project Vision

A minimalist, Apple-inspired developer portfolio that demonstrates technical competence through clean execution rather than flashy features. Built with Blazor WebAssembly, Tailwind CSS, and hosted on GitHub Pages, the portfolio embodies a "less is more" philosophy where the codebase itself serves as proof of the qualities being claimed.

The portfolio positions Bhavan as a Full Stack Developer who gets things done - reliable, clean code, fast delivery, and technical depth.

### Target Users

| User | Role | Goal | Success Statement |
|------|------|------|-------------------|
| **Rachel** | Technical Recruiter | Quick validation in 8-15 seconds | "This looks clean, skills match, projects are relevant - downloading resume now." |
| **Marcus** | Engineering Hiring Manager | Technical validation, team fit assessment | "The code matches the claims. Schedule the technical screen." |
| **Dev** | Peer / Referrer | Assess credibility for referral | "Clean architecture, good patterns. Worth recommending." |

**Primary Focus:** Rachel's 8-second decision journey. All design choices optimize for the recruiter scan pattern.

### Key Design Challenges

1. **8-Second Test** - Name, title, and resume download must be findable instantly via F-pattern eye scan (top-left → top-right → scroll down)
2. **Dual Theme Polish** - Dark and light modes must be equally refined; light mode is not an afterthought
3. **WASM Loading Experience** - 2-5MB runtime download requires styled loading state to prevent the "back button moment"
4. **Minimalist Visual Hierarchy** - Create visual interest, guide attention, and establish hierarchy using only the grayscale palette (no color crutches)

### Design Opportunities

1. **Sticky Resume Download** - Primary CTA always visible, 1-click access from any scroll position
2. **Loading as Design Statement** - Static hero shell that fades seamlessly into live Blazor app, turning a technical constraint into a polished experience
3. **Code as Proof** - Prominent GitHub links position the codebase as portfolio evidence
4. **"Built with Blazor" Colophon** - Footer attribution becomes a conversation starter for developer peers

## Core User Experience

### Defining Experience

**Primary User Action:** Scan and decide - Rachel scans the hero, validates skills, downloads resume in 8-15 seconds total.

**Critical Action:** Resume download - 1-click from any scroll position via sticky header. This is the conversion moment.

**Effortless Goal:** Finding proof - Name, title, skills, projects, resume require zero hunting.

### Platform Strategy

| Platform | Priority | Experience |
|----------|----------|------------|
| **Desktop** | Primary | Full layout, sticky header with all nav items visible |
| **Mobile** | Equal | Hamburger menu, stacked cards, touch-friendly (44px targets) |
| **Tablet** | Adaptive | Responsive behavior between desktop and mobile |

**Input Method:** Mouse/keyboard primary, touch-friendly secondary
**Offline:** Not required (static site, always online)
**Browser Support:** Modern evergreen only (Chrome, Firefox, Safari, Edge - latest 2 versions)

### Effortless Interactions

| Interaction | Should Feel Like... |
|-------------|---------------------|
| Finding resume | It's just *there* - sticky header, always visible |
| Scanning skills | Glance, match, done - 5 seconds max |
| Theme toggle | Respects user agency - preference persists, context-aware |
| Navigation | Intentional scroll - 400-500ms with easing, signals quality |
| Loading | Seamless handoff - static shell pixel-identical to Blazor component |

### Critical Success Moments

| Moment | Success | Failure |
|--------|---------|---------|
| **First 3 seconds** | "This looks professional" | Back button |
| **Skills scan** | "Matches our requirements" | "Can't find relevant skills" |
| **Resume click** | PDF downloads instantly | Broken link, slow download |
| **Mobile check** | "Works perfectly on phone" | Broken layout, tiny tap targets |
| **Theme toggle** | Smooth transition, preference remembered | Flash, resets on reload |
| **Scroll navigation** | Intentional, quality feel (400-500ms eased) | Jarring jump or sluggish crawl |

### Time-Bucketed Design (Rachel's 8-Second Journey)

| Time Bucket | UX Goal | What Earns Attention |
|-------------|---------|---------------------|
| **0-1.5s** | Professional first impression | Loading shell renders, clean B&W aesthetic |
| **1.5-3s** | "I know who this person is" | Name (top-left), Title, Resume button (top-right) |
| **3-6s** | "Matches my job req" | Skills section - scannable badges |
| **6-8s** | Decision & action | Resume downloaded or tab closed |

*Note: Projects, Timeline, Contact serve Marcus and Dev who go deeper. Rachel may never scroll past Skills.*

### Experience Principles

1. **Time-Bucketed Design** - Each 2-second window has a specific UX goal; every element earns its place in that window
2. **Prove, Don't Claim** - GitHub links, clean code, performance scores speak louder than words
3. **Zero Friction Download** - Resume is the primary CTA, always accessible, 1-click from anywhere
4. **Respect User Agency** - Theme preference persists, context-aware defaults, user choice honored
5. **Seamless Handoff** - Static loading shell pixel-identical to Blazor component; zero visual shift on hydrate
6. **Intentional Micro-Interactions** - Scroll behavior (400-500ms eased), transitions, and animations all signal quality

## Desired Emotional Response

### Primary Emotional Goals

| User | Should Feel | Why It Matters |
|------|-------------|----------------|
| **Rachel** | **Confident** | "I can trust this candidate is worth my time" |
| **Marcus** | **Impressed** | "This person knows what they're doing" |
| **Dev** | **Respect** | "Clean work. I'd recommend them." |

**The Core Emotion:** **Professional Trust** - Not flashy excitement, but quiet confidence. The feeling you get from a well-organized desk, a firm handshake, a person who means what they say.

### Emotional Journey Mapping

| Stage | Rachel's Emotion | Design Driver |
|-------|------------------|---------------|
| **First impression (0-3s)** | Relief → "Finally, a clean one" | Minimalist aesthetic, fast load |
| **Scanning (3-6s)** | Confidence → "Skills check out" | Scannable badges, clear hierarchy |
| **Decision (6-8s)** | Satisfaction → "Easy to act on" | 1-click resume, no friction |
| **After download** | Trust → "Professional choice" | Clean PDF, consistent branding |

### Micro-Emotions

**Emotions to Cultivate:**

| Emotion | How We Create It |
|---------|------------------|
| **Confidence** | Clear typography, consistent spacing, no visual noise |
| **Trust** | Professional aesthetic, working links, instant feedback |
| **Efficiency** | Zero hunting, information where expected, fast interactions |
| **Respect** | Attention to detail in both themes, polished micro-interactions |

**Emotions to Avoid:**

| Avoid | Cause | Prevention |
|-------|-------|------------|
| **Frustration** | Slow load, broken links, hunting for resume | Loading shell, sticky header, clear CTAs |
| **Confusion** | Unclear navigation, too much content | Single-page, 6 focused sections |
| **Skepticism** | Over-claiming, inconsistent quality | Let code speak, both themes polished |
| **Impatience** | Sluggish transitions, unresponsive UI | 400-500ms eased scroll, instant theme toggle |

### Emotional Design Principles

1. **Professional Trust Over Flash** - Quiet confidence through clean execution, not attention-grabbing gimmicks
2. **Relief Through Simplicity** - Rachel sees dozens of cluttered portfolios; ours is a breath of fresh air
3. **Confidence Through Consistency** - Same quality in dark mode, light mode, mobile, desktop
4. **Respect Through Speed** - Every millisecond saved says "I value your time"
5. **Trust Through Transparency** - GitHub links, open source, code speaks for itself

## UX Pattern Analysis & Inspiration

### Inspiring Products Analysis

| Product | Key UX Strengths | Applicable Patterns |
|---------|------------------|---------------------|
| **Apple.com** | Typography-driven hierarchy, whitespace mastery, dual-mode excellence | Hero typography (48-64px name), generous section padding (80-120px), loading strategy |
| **Linear.app** | Dark mode default, micro-interactions, developer focus | Theme toggle implementation, hover states, keyboard navigation |
| **Stripe.com** | Scannable content, professional polish, documentation clarity | Skills badges, project cards, information chunking |
| **Vercel.com** | B&W aesthetic, developer credibility, smooth scroll | Grayscale palette, code-as-proof, 400-500ms eased navigation |

### Transferable UX Patterns

**Navigation:**
- Sticky minimal header (name + nav + resume CTA + theme toggle)
- Smooth scroll to sections (400-500ms, eased)
- Mobile hamburger with full functionality

**Interactions:**
- Instant theme toggle (no flash, localStorage persist)
- Hover state elevation on cards (subtle lift/shadow)
- Focus indicators for keyboard navigation
- Button feedback (subtle scale/opacity)

**Visual:**
- Typography-driven hierarchy (large name, clear title levels)
- Generous whitespace (section padding 80-120px)
- Card-based content (projects, skills)
- Constrained B&W palette

**Loading:**
- Static shell matching final component
- Fade transition on hydration
- Progressive content reveal

### Anti-Patterns to Avoid

| Avoid | Reason | Prevention |
|-------|--------|------------|
| Animated backgrounds | Distracts, hurts performance | Static B&W focus |
| Color outside palette | Breaks cohesion | Strict grayscale only |
| Carousel/sliders | Hides content | Visible grid |
| Scroll hijacking | Frustrating UX | Native + smooth anchor |
| Buried resume | Fails 8-second test | Sticky header CTA |
| Light mode afterthought | Signals neglect | Both modes equally designed |
| Too much text | Recruiters scan | Badges, bullets, hierarchy |

### Design Inspiration Strategy

**Adopt:** Apple's typography hierarchy, Linear's dark mode excellence, Vercel's B&W aesthetic, Stripe's scannable organization

**Adapt:** Loading patterns for WASM shell, navigation for single-page, card design for grayscale

**Avoid:** Non-functional animation, off-palette colors, friction-adding interactions, theme inconsistency

## Design System Foundation

### Design System Choice

**Custom Design System with Tailwind Foundation**

A custom component system built on Tailwind CSS v4 utility classes, designed specifically for Blazor WebAssembly with strict B&W aesthetic constraints.

### Rationale for Selection

| Factor | Decision Driver |
|--------|-----------------|
| **Framework Alignment** | Blazor components (`.razor`) require custom implementation - no React/Vue component libraries apply |
| **Aesthetic Control** | Strict grayscale palette (black, white, grays only) - no library defaults to fight against |
| **Performance** | Zero unused component library code - only what we build ships |
| **Simplicity** | No additional dependencies or API learning curves beyond Tailwind utilities |
| **Maintainability** | Single developer project - custom is manageable and fully understandable |

### Implementation Approach

| Layer | Tool | Responsibility |
|-------|------|----------------|
| **Design Tokens** | `tailwind.config.js` + CSS custom properties | Colors, fonts, spacing, breakpoints |
| **Utility Classes** | Tailwind CSS v4 | Layout, typography, responsive, dark mode |
| **Components** | Custom Blazor `.razor` files | ProjectCard, SkillBadge, TimelineItem, etc. |
| **Theme Switching** | CSS custom properties + Tailwind `dark:` variants | Dark/light mode via body class |

### Customization Strategy

**Design Tokens (defined in Tailwind config):**

| Token Category | Values |
|----------------|--------|
| **Colors** | black, white, gray-50, gray-200, gray-300, gray-400, gray-600, gray-700, gray-800, gray-900 |
| **Typography Scale** | text-sm, text-base, text-lg, text-xl, text-2xl, text-4xl, text-5xl, text-6xl |
| **Spacing Scale** | Tailwind default (4px base) |
| **Breakpoints** | sm: 640px, md: 768px, lg: 1024px, xl: 1280px |

**Component Pattern Library:**

| Component | Styling Pattern |
|-----------|-----------------|
| **Buttons** | Solid fill (primary CTA) vs outline (secondary) - grayscale only |
| **Cards** | Border + subtle shadow, hover elevation |
| **Badges** | Pill-shaped, border or filled background |
| **Section Containers** | py-20 to py-32 (80-128px), max-w-6xl centered |
| **Typography** | System font stack, clear weight hierarchy |

**Theme Implementation:**
- Tailwind `darkMode: 'class'` configuration
- Body class: `dark` or `light`
- All components use `dark:` variant utilities
- CSS custom properties for any non-Tailwind values

## Defining Experience

### Core Interaction

**"Scan → Validate → Download"**

Rachel lands on the page, scans the hero (name, title), validates skills match, downloads resume. Total time: 8 seconds.

*If a friend asked: "What's that portfolio site?" → "Clean developer portfolio - I could find everything in seconds and download his resume instantly."*

### User Mental Model

**How recruiters currently solve this:**
- LinkedIn profiles (structured, but generic)
- PDF resumes (portable, but no context)
- Personal websites (varied quality, often slow or confusing)

**Mental model Rachel brings:**
- "I scan, I don't read"
- "Resume button should be obvious"
- "Skills should be at a glance"
- "If I can't figure it out in 10 seconds, next candidate"

| Expectation | Our Design |
|-------------|------------|
| Name + title visible immediately | Hero section, largest typography |
| Resume accessible without hunting | Sticky header, always visible |
| Skills scannable quickly | Badge-based, no paragraphs |
| Works on mobile | Full responsive parity |

### Success Criteria

| Criteria | Measurement |
|----------|-------------|
| **"This just works"** | Zero confusion, F-pattern delivers expected info |
| **Feels fast** | Loading shell < 500ms, full interactive < 5s |
| **Accomplishment** | Resume downloaded in 1 click, no hunting |
| **Smart feedback** | Smooth scroll confirms navigation, theme toggle is instant |

**Rachel Success Statement:** "I found what I needed without thinking about it."

### Pattern Analysis

**100% Established Patterns** - No user education needed:

| Pattern | Source | Our Implementation |
|---------|--------|-------------------|
| Sticky header with CTA | Every SaaS site | Name + Nav + Resume + Theme |
| Single-page scroll | Portfolio standard | 6 sections, smooth anchor |
| Card-based projects | Universal pattern | ProjectCard component |
| Dark/light toggle | Linear, Vercel, GitHub | Icon toggle, localStorage |
| Badge-style skills | LinkedIn, GitHub | SkillBadge component |

**Differentiation:** Not novel interaction - execution quality within established patterns.

### Experience Mechanics

**1. Initiation (0-1.5s)**
- User clicks link (LinkedIn, job application, Google)
- Loading shell renders immediately (static HTML hero)
- B&W aesthetic establishes tone before Blazor loads

**2. Interaction (1.5-6s)**
- F-pattern scan: Name (top-left) → Resume button (top-right) → Scroll down
- Nav click: smooth scroll (400-500ms eased) to section
- Theme toggle: instant class switch, localStorage persist
- Passive scrolling reveals sections in order

**3. Feedback**
- Resume click: Browser download dialog (instant)
- Nav click: Smooth scroll animation confirms action
- Theme toggle: Immediate visual change, no flash
- Hover states: Cards elevate, buttons respond
- Error state (WASM fail): Fallback message after 10s

**4. Completion (6-8s)**
- Success: Resume downloaded, positive impression
- Deeper engagement (Marcus/Dev): Projects → GitHub links
- Exit: Tab closed, but impression made
