---
stepsCompleted: [1, 2, 3, 4]
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
