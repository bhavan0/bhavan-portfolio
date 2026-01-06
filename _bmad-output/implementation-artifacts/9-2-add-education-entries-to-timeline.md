---
storyId: 9-2
epicId: 9
title: Add Education Entries to Timeline
status: done
completedDate: 2026-01-05
---

# Story 9-2: Add Education Entries to Timeline

## Summary

Added education entries from Bhavan's resume to the timeline, integrated chronologically with work experience, with distinct visual styling to differentiate from work entries.

## Acceptance Criteria - All Met ✅

- ✅ Timeline includes education entries mixed chronologically with work experience
- ✅ Education entries use the same TimelineItem component structure as work experience
- ✅ Entries are displayed in unified chronological order (most recent first)
- ✅ Education entries use clear format with degree, field, and institution
- ✅ Education entries are clearly identifiable with visual differentiation
- ✅ Date ranges are accurate and formatted consistently
- ✅ Entries use proper datetime attributes for semantic HTML
- ✅ The timeline maintains visual consistency between work and education entries
- ✅ The complete timeline shows full professional progression

## Implementation Details

### Education Entries Added

1. **Master's in Computer Science** - University at Buffalo, SUNY (Aug 2021 - Dec 2022)
   - Location: NY, USA
   - Description: Graduate studies focusing on distributed systems, machine learning, and software engineering

2. **Bachelor's in Computer Science** - New Horizon College of Engineering (2014 - 2018)
   - Location: Bangalore, India
   - Description: Undergraduate degree with focus on software development, data structures, and algorithms

### Visual Differentiation

- **Education entries feature:**
  - Green graduation cap (🎓) icon in timeline marker
  - Green "🎓 Education" badge next to date
  - Green-colored date text (emerald-600/emerald-400)
  - Description paragraph instead of bullet points

- **Work entries feature:**
  - Black/white briefcase icon in timeline marker
  - No type badge
  - Black/gray date text
  - Bullet point achievements

### Timeline Order (Most Recent First)

1. Lead Engineer - Chatham Financial (Nov 2024 - Present) [Work]
2. Full Stack Software Developer - Chatham Financial (Feb 2023 - Nov 2024) [Work]
3. Master's in Computer Science - UB SUNY (Aug 2021 - Dec 2022) [Education]
4. Full Stack Intern - My Money Karma (Jun 2022 - Aug 2022) [Work]
5. Software Engineer - Eurofins (Apr 2020 - Jul 2021) [Work]
6. Associate Software Engineer - Eurofins (Aug 2018 - Apr 2020) [Work]
7. Bachelor's in Computer Science - NHCE (2014 - 2018) [Education]

## Testing

- ✅ Education entries display with green graduation cap icons
- ✅ "🎓 Education" badge visible on education entries
- ✅ Chronological order maintained (work and education interleaved correctly)
- ✅ Light mode styling correct
- ✅ Dark mode styling correct
- ✅ Responsive layout maintained on mobile/tablet/desktop
