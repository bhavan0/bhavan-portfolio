---
stepsCompleted: [1, 2, 3, 4]
inputDocuments:
  - "_bmad-output/planning-artifacts/prd.md"
  - "_bmad-output/planning-artifacts/architecture.md"
  - "_bmad-output/planning-artifacts/ux-design-specification.md"
  - "Bhavan_Anand_Resume.pdf"
workflowType: 'epics-and-stories'
lastStep: 4
status: 'complete'
project_name: 'bhavan-portfolio'
user_name: 'Bhavan'
date: '2026-01-05'
phase: 'Phase 2 - Content Update'
completionDate: '2026-01-05'
validationResults:
  frCoverage: '8/8 (100%)'
  nfrCoverage: '5/5 (100%)'
  totalEpics: 2
  totalStories: 4
  dependencyCheck: 'passed'
  architectureCompliance: 'passed'
---

# bhavan-portfolio - Phase 2: Content Update - Epic Breakdown

## Overview

This document provides the epic and story breakdown for Phase 2 of bhavan-portfolio, focusing on updating the portfolio website with actual professional details from Bhavan Anand's resume. This phase updates placeholder content with real work experience and skills data.

## Requirements Inventory

### Functional Requirements

**About Section (from PRD):**
- FR10: Visitors can read a personal/professional summary
- FR11: Visitors can understand the developer's background and approach

**Skills Section (from PRD):**
- FR12: Visitors can identify key skills through scannable visual organization
- FR13: Visitors can see skills organized in a scannable visual format
- FR14: Visitors can identify primary technology competencies

**Timeline Section (from PRD):**
- FR21: Visitors can view work experience in chronological order
- FR22: Visitors can see role titles, companies, and timeframes
- FR23: Visitors can understand career progression

### NonFunctional Requirements

**Maintainability (from PRD):**
- NFR15: Component Organization - Logical folder structure
- NFR16: Naming Conventions - Consistent PascalCase for components
- NFR17: Code Cleanliness - No commented-out code, no console.logs
- NFR18: README Documentation - Clear setup and architecture explanation
- NFR19: Inline Comments - Key decisions documented

### Additional Requirements

**From Resume (Bhavan_Anand_Resume.pdf):**

**Summary/About Data:**
- Full-stack Lead Engineer with 6+ years of experience building scalable enterprise applications
- Proven track record of leading engineering teams and developing AI-powered solutions
- Combines technical depth with strong leadership to deliver products that drive real business outcomes

**Work Experience Data:**
- Chatham Financial Corp. | PA, USA
  - Lead Engineer (Nov-2024 - Present)
  - Full Stack Software Developer (Feb-2023 - Nov-2024)
- My Money Karma Inc. | CA, USA
  - Full Stack Intern (Jun-2022 - Aug-2022)
- Eurofins IT Solutions Pvt Ltd | Bangalore, India
  - Software Engineer (Apr-2020 - Jul-2021)
  - Associate Software Engineer (Aug-2018 - Apr-2020)

**Skills Data:**
- Languages: C#, Python, TypeScript, JavaScript, HTML, CSS
- Frameworks: .NET Core, Angular, React, Node.js, NServiceBus, ServiceStack, Entity Framework, Dapper
- Architecture: Microservices, Domain Driven Design, Event Driven Architecture, RESTful APIs
- Testing: Playwright, Cypress, SpecFlow, xUnit
- Databases: MS SQL, MongoDB, PostgreSQL
- AI Tools: Claude, GitHub Copilot, Cursor, OpenAI Codex

**Education Data:**
- Masters - Computer Science - University at Buffalo, The State University of New York (2021-2022)
- Bachelors - Computer Science - New Horizon college of Engineering (2014-2018)

**From Architecture Document:**
- Component structure: TimelineSection.razor, SkillsSection.razor, and AboutSection.razor already exist
- Data structure: ExperienceEntry record and Skills List<string> already defined
- Timeline can accommodate both work experience and education entries using same ExperienceEntry structure
- Naming conventions: PascalCase for components, camelCase for JS modules

**From UX Design Document:**
- Timeline display: Vertical timeline with dates, roles, companies, descriptions
- Skills display: Badge-based grid layout (2 cols mobile, 3 cols tablet, 4 cols desktop)
- Maintain scannability: Skills should be 15-20 total for quick scanning

### FR Coverage Map

| FR | Epic | Description |
|----|------|-------------|
| FR10 | Epic 8 | Personal/professional summary |
| FR11 | Epic 8 | Developer's background and approach |
| FR12 | Epic 8 | Key skills scannable visual organization |
| FR13 | Epic 8 | Skills in scannable visual format |
| FR14 | Epic 8 | Primary technology competencies identification |
| FR21 | Epic 9 | Work experience in chronological order |
| FR22 | Epic 9 | Role titles, companies, and timeframes |
| FR23 | Epic 9 | Career progression understanding |

## Epic List

### Epic 8: Update Professional Identity & Skills
**Goal:** Visitors see accurate professional summary and technical competencies that reflect real experience and skills from resume.

**FRs covered:** FR10, FR11, FR12, FR13, FR14
**NFRs addressed:** NFR15-NFR19 (Maintainability)

**Includes:**
- Update AboutSection.razor with professional summary from resume
- Update SkillsSection.razor with actual skills from resume
- Organize skills by category (Languages, Frameworks, Architecture, Testing, Databases, AI Tools)
- Maintain 15-20 skill limit for scannability
- Prioritize most relevant skills first
- Maintain existing component structures (AboutSection, SkillsSection, SkillBadge)

---

### Epic 9: Update Career History & Education
**Goal:** Visitors see complete career progression including work experience and education, providing full professional context.

**FRs covered:** FR21, FR22, FR23
**NFRs addressed:** NFR15-NFR19 (Maintainability)

**Includes:**
- Update TimelineSection.razor with actual work experience entries
- Include all 5 positions from resume (Chatham Financial, My Money Karma, Eurofins)
- Add Education entries (Masters and Bachelors degrees)
- Ensure chronological order (most recent first)
- Include accurate dates, role titles, company names, and descriptions
- Maintain existing TimelineItem component structure
- Mix work experience and education in unified timeline display

---

## Epic 8: Update Professional Identity & Skills

**Goal:** Visitors see accurate professional summary and technical competencies that reflect real experience and skills from resume.

**FRs covered:** FR10, FR11, FR12, FR13, FR14
**NFRs addressed:** NFR15-NFR19 (Maintainability)

### Story 1.1: Update About Section with Professional Summary

As a **visitor**,
I want **to read an accurate professional summary**,
So that **I understand the developer's real background and expertise**.

**Acceptance Criteria:**

**Given** the AboutSection component exists with placeholder content
**When** a visitor views the About section
**Then** the section displays the professional summary from resume: "Full-stack Lead Engineer with 6+ years of experience building scalable enterprise applications. Proven track record of leading engineering teams and developing AI-powered solutions. Combines technical depth with strong leadership to deliver products that drive real business outcomes."
**And** the content is formatted in readable paragraphs (FR10)
**And** the summary accurately reflects the developer's background (FR11)
**And** the text maintains proper styling (`text-base md:text-lg text-gray-700 dark:text-gray-300 leading-relaxed`)
**And** the section maintains existing component structure and styling
**And** no placeholder text remains

---

### Story 1.2: Update Skills Section with Actual Technical Skills

As a **visitor**,
I want **to see accurate technical skills organized for quick scanning**,
So that **I can validate the developer's competencies match my requirements**.

**Acceptance Criteria:**

**Given** the SkillsSection component exists with placeholder skills
**When** a visitor views the Skills section
**Then** the section displays actual skills from resume, organized by priority
**And** all skills from resume are included (29 total skills across 6 categories):
  - Languages: C#, Python, TypeScript, JavaScript, HTML, CSS
  - Frameworks: .NET Core, Angular, React, Node.js, NServiceBus, ServiceStack, Entity Framework, Dapper
  - Architecture: Microservices, Domain Driven Design, Event Driven Architecture, RESTful APIs
  - Testing: Playwright, Cypress, SpecFlow, xUnit
  - Databases: MS SQL, MongoDB, PostgreSQL
  - AI Tools: Claude, GitHub Copilot, Cursor, OpenAI Codex
**And** skills are displayed in a scannable badge grid layout (FR12, FR13)
**And** skills are organized by category/priority for optimal scanning (FR14)
**Note:** All 29 skills are included for completeness, which may exceed the typical 15-20 guideline but provides comprehensive skill visibility
**And** skills are prioritized with most relevant technologies first
**And** the grid maintains responsive layout (2 cols mobile, 3 cols tablet, 4 cols desktop)
**And** each skill uses the existing SkillBadge component
**And** no placeholder skills remain
**And** the skills accurately reflect the resume categories: Languages, Frameworks, Architecture, Testing, Databases, AI Tools

---

## Epic 9: Update Career History & Education

**Goal:** Visitors see complete career progression including work experience and education, providing full professional context.

**FRs covered:** FR21, FR22, FR23
**NFRs addressed:** NFR15-NFR19 (Maintainability)

### Story 2.1: Update Timeline with Actual Work Experience

As a **visitor**,
I want **to see accurate work experience in chronological order**,
So that **I can understand the developer's career progression and relevant experience**.

**Acceptance Criteria:**

**Given** the TimelineSection component exists with placeholder work experience entries
**When** a visitor views the Experience section
**Then** the timeline displays all 5 actual positions from resume in chronological order (most recent first):
- Lead Engineer at Chatham Financial Corp. (Nov-2024 - Present)
- Full Stack Software Developer at Chatham Financial Corp. (Feb-2023 - Nov-2024)
- Full Stack Intern at My Money Karma Inc. (Jun-2022 - Aug-2022)
- Software Engineer at Eurofins IT Solutions Pvt Ltd (Apr-2020 - Jul-2021)
- Associate Software Engineer at Eurofins IT Solutions Pvt Ltd (Aug-2018 - Apr-2020)
**And** each entry displays accurate role title, company name, location, and date range (FR22)
**And** entries are ordered chronologically with most recent first (FR21)
**And** each entry includes key achievements/responsibilities using bullet points from resume:
  - Lead Engineer: Team leadership, AI-powered platform delivery, cross-functional AI working group, hiring committee
  - Full Stack Software Developer: Application modernization, test coverage improvement, E2E automation, event-driven systems
  - Full Stack Intern: Critical features for thousands of users, reusable React components, automated E2E testing
  - Software Engineer: Microservices design, .NET Framework migration, Angular UI components, comprehensive test suites
  - Associate Software Engineer: Entry-level development, business analysis collaboration, database optimization
**And** the timeline uses the existing TimelineItem component structure
**And** entries use proper datetime attributes for semantic HTML
**And** no placeholder entries remain
**And** the timeline clearly shows career progression (FR23)

---

### Story 2.2: Add Education Entries to Timeline

As a **visitor**,
I want **to see education history integrated with work experience**,
So that **I have complete professional context including academic background**.

**Acceptance Criteria:**

**Given** the TimelineSection component displays actual work experience
**When** a visitor views the Experience section
**Then** the timeline includes education entries mixed chronologically with work experience:
- Masters - Computer Science at University at Buffalo, The State University of New York (2021-2022)
- Bachelors - Computer Science at New Horizon College of Engineering (2014-2018)
**And** education entries use the same TimelineItem component structure as work experience
**And** entries are displayed in unified chronological order (most recent first)
**And** education entries use clear format:
  - Role: "Masters - Computer Science" (for Masters) or "Bachelors - Computer Science" (for Bachelors)
  - Company: Full university name (e.g., "University at Buffalo, The State University of New York")
  - Description: Brief note such as "Graduate degree in Computer Science" or minimal description
**And** education entries are clearly identifiable and visually consistent with work experience entries
**And** date ranges are accurate and formatted consistently
**And** entries use proper datetime attributes for semantic HTML
**And** the timeline maintains visual consistency between work and education entries
**And** the complete timeline (work + education) shows full professional progression

---
