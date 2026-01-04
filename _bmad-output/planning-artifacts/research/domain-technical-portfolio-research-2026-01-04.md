# Research: Developer Portfolio Best Practices & Blazor WASM Technical Implementation

**Research Type:** Domain + Technical (Combined)
**Topic:** Developer portfolio best practices and Blazor WebAssembly implementation
**Date:** 2026-01-04
**Researcher:** Bhavan

---

## Executive Summary

This research combines domain insights on what makes developer portfolios stand out to recruiters with technical best practices for implementing a Blazor WebAssembly portfolio hosted on GitHub Pages with Tailwind CSS. The findings strongly align with Bhavan's brainstormed approach of "less is more" and Apple-inspired clean execution.

**Key Findings:**
1. Recruiters spend ~8 seconds scanning portfolios - simplicity and clarity win
2. Quality over quantity - 3-5 curated projects beat many half-finished ones
3. B&W/minimalist design is a top 2025-2026 trend
4. Dark/Light mode toggle is highly recommended
5. Blazor WASM + GitHub Pages is well-supported with established workflows
6. Tailwind CSS v4 integration with Blazor is now much simpler

---

## Part 1: Domain Research - Developer Portfolio Best Practices

### What Recruiters Look For

According to [Pesto Tech](https://pesto.tech/resources/what-recruiters-look-for-in-developer-portfolios), hiring managers make decisions based on the **clarity, quality, and authenticity** of portfolios before even meeting candidates. Modern recruiters spend an average of just **8 seconds** scanning a portfolio.

Key elements recruiters want ([C# Corner](https://www.c-sharpcorner.com/article/how-to-create-a-strong-developer-portfolio-in-2025/)):
- **About Section** with a short bio
- **Skills Stack** showing programming languages, frameworks, and tools
- **Projects** with live demos, GitHub links, and case studies
- **Experience/Education** information

### Quality Over Quantity

Multiple sources emphasize this critical point:

> "Creating a strong tech portfolio doesn't mean listing every project you've touched. It means curating a few key examples that show depth, impact, and your ability to learn." - [TieTalent](https://tietalent.com/en/blog/220/beyond-the-ats-how-to-build-a-tech-portfolio)

> "A single working project that demonstrates problem-solving is more impactful than multiple half-finished experiments." - [DEV Community](https://dev.to/dareyio/how-to-build-a-standout-portfolio-in-tech-that-attracts-recruiters-in-2025-2p07)

**Recommendation:** Focus on 3-5 best projects rather than showcasing everything.

### Storytelling and Case Studies

According to [Proxify](https://proxify.io/knowledge-base/job-descriptions/what-makes-a-developer-portfolio-stand-out-to-recruiters), recruiters want to see:
- The problem or challenge
- Your approach and thought process
- Technologies and tools used
- Results (with metrics when possible)

> "Don't just display the finished product—explain the challenge, your role, the tools you chose, and most importantly, the impact."

### Design Trends 2025-2026

From [Colorlib's Portfolio Design Trends](https://colorlib.com/wp/portfolio-design-trends/) and [Design Shack](https://designshack.net/articles/trends/portfolio-design/):

| Trend | Description | Relevance to Bhavan's Vision |
|-------|-------------|------------------------------|
| **Minimalism** | Timeless, versatile, suits any niche | Directly aligned |
| **Dark Mode/B&W** | Black and white designs with optional accent | Exactly what was planned |
| **Light/Dark Switcher** | User preference toggle | Already planned |
| **Split-Screen Layouts** | Contrasting vertical sections | Could use for Hero |
| **Big Typography** | Bold, confident headlines | Apple-inspired approach |
| **Interactive Elements** | Subtle animations, hover effects | Planned as subtle features |

### What to Avoid

Common mistakes identified across sources:
- Cluttered design with unnecessary animations
- Listing too many projects
- No live demos
- Outdated technologies
- Poor code practices
- Generic URLs (get a custom domain if possible)

### Professional Presentation Essentials

From [BrainStation](https://brainstation.io/career-guides/how-to-build-a-web-developer-portfolio):
- **Responsive design** - Must work on all devices
- **Fast loading** - Reflects quality of work
- **Clean navigation** - Intuitive structure
- **Contact information** - Easy to reach you

---

## Part 2: Technical Research - Blazor WASM Implementation

### Blazor WebAssembly Performance Best Practices

From [Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/?view=aspnetcore-9.0):

> "Blazor is optimized for high performance in most realistic application UI scenarios. However, the best performance depends on developers adopting the correct patterns and features."

**Key Performance Considerations:**

1. **Startup Time** - The application needs to transfer a .NET runtime to the browser
2. **Runtime Throughput** - Optimize rendering and avoid unnecessary re-renders
3. **Download Size** - Use trimming and compression

### AOT Compilation (For Future Enhancement)

From [Developer's Voice](https://developersvoice.com/blog/dotnet/production-blazor-wasm-optimization-aot-pwa/):

> "AOT compiles IL into WebAssembly ahead of time during the build. Instead of interpreting IL at runtime, the browser executes native WebAssembly instructions."

**Trade-off:** Larger download size but faster execution. Recommended to couple with IL trimming.

**Recommendation for Phase 1:** Skip AOT initially to keep build simple; consider for future optimization.

### Component Optimization

From [Telerik Blazor Basics](https://www.telerik.com/blogs/blazor-basics-optimizing-performance-blazor-webassembly-applications):

- **Avoid unnecessary re-renders** using `ShouldRender()` lifecycle method
- **Use @key directive** for list rendering efficiency
- **Component virtualization** for large lists (not needed for portfolio)
- **Minimize JavaScript interop calls** - batch operations when possible

### Lazy Loading Assemblies

From [Steven Giesel's Blog](https://steven-giesel.com/blogPost/a8772410-847d-4fe7-ba93-3e03ab7748c0):

> "We can defer some assemblies by telling Blazor we want to load them at a later point in time."

**Recommendation:** Not critical for a small portfolio site, but useful to know for future.

### Hosting on GitHub Pages

From [Microsoft Learn GitHub Pages Guide](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly/github-pages?view=aspnetcore-10.0):

**Key Requirements:**
1. Add `.gitattributes` with `*.js binary` to prevent line ending issues
2. Update `<base href>` to match repository name
3. Add `.nojekyll` file to serve `_framework` folder
4. Enable Brotli/Gzip compression for static files

**GitHub Actions Workflow:**

From [Matthew Regis](https://matthewregis.dev/posts/blazor-web-assembly-github-pages-with-github-actions/):

```yaml
# Key steps in workflow:
1. Checkout code
2. Setup .NET SDK
3. Build and publish Blazor WASM
4. Rewrite base href (SteveSandersonMS/ghaction-rewrite-base-href)
5. Deploy to gh-pages branch
```

**Recent Tutorial (January 2025)** from [DC Coding](https://codingblog.carterdan.net/2025/01/08/blazor-tailwind-github-pages/):

> "In the GitHub web UI, go to Settings, click on Pages, and then under 'branch' select gh-pages. Your site will be deployed at {username}.github.io/{repository}."

### Tailwind CSS Integration with Blazor

From [Steven Giesel's Tailwind v4 Guide](https://steven-giesel.com/blogPost/364c43d2-b31e-4377-8001-ac75ce78cdc6):

> "Tailwind version 4 was just released, and with the new CLI, it is much easier to use Tailwind CSS with Blazor."

**Tailwind v4 Simplifications:**
- No `tailwind.config.js` required (though still supported)
- Simple CSS import approach
- Automatic class scanning

**Setup Steps** from [Tim Deschryver](https://timdeschryver.dev/blog/integrating-tailwind-css-in-blazor):

1. Install Tailwind CLI: `npm install tailwindcss @tailwindcss/cli`
2. Create input CSS file with Tailwind import
3. Configure content to scan `.razor` files
4. Add build target to project file for automatic compilation

**No-NPM Option** from [Blazorise](https://blazorise.com/blog/blazor-and-tailwind-quick-setup-without-npm):
- Download standalone Tailwind CLI executable
- No Node.js required
- Run from solution root folder

**Automated Builds:**

> "Add a build target to your project file that runs the Tailwind CSS command before the application is compiled. This will automatically run every time you build the application."

### Component Architecture Recommendations

Based on Bhavan's portfolio structure, recommended Blazor components:

```
Components/
├── Layout/
│   ├── MainLayout.razor
│   ├── NavBar.razor
│   └── Footer.razor
├── Sections/
│   ├── HeroSection.razor
│   ├── AboutSection.razor
│   ├── SkillsSection.razor
│   ├── ProjectsSection.razor
│   ├── TimelineSection.razor
│   └── ContactSection.razor
├── UI/
│   ├── ProjectCard.razor
│   ├── SkillBadge.razor
│   ├── TimelineItem.razor
│   └── ThemeToggle.razor
└── Pages/
    ├── Index.razor (Home)
    └── ProjectDetail.razor
```

---

## Validation: Research vs. Brainstorm Alignment

| Brainstorm Decision | Research Validation |
|---------------------|---------------------|
| B&W + subtle grays | Top 2025-2026 trend |
| Dark/Light mode toggle | Highly recommended |
| Apple-inspired minimalism | "Less is more" validated |
| 6 core sections | Aligns with recruiter expectations |
| Subtle animations | Recommended over flashy effects |
| Quality over quantity | Strongly emphasized |
| Blazor WASM + GitHub Pages | Well-documented workflow exists |
| Tailwind CSS | Easy v4 integration with Blazor |
| Clean execution philosophy | Matches "show don't tell" principle |

---

## Actionable Recommendations

### High Priority
1. **Keep it simple** - Research confirms minimalism wins
2. **Focus on 3-5 best projects** with case studies
3. **Ensure fast loading** - Use compression, optimize assets
4. **Mobile-responsive** - Test on all devices
5. **Include contact information** prominently

### Technical Implementation
1. Use **Tailwind CSS v4** with standalone CLI for simpler setup
2. Set up **GitHub Actions** workflow for automated deployment
3. Implement **theme toggle** (dark/light) from the start
4. Create **reusable Blazor components** for sections
5. Add **.nojekyll** and **.gitattributes** files for GitHub Pages

### Future Enhancements (Phase 2+)
1. Consider **AOT compilation** for better performance
2. Add **lazy loading** if site grows
3. Get **custom domain** for professional URL
4. Add **analytics** to track visitor behavior

---

## Sources

### Domain Research
- [C# Corner - How to Create a Strong Developer Portfolio in 2025](https://www.c-sharpcorner.com/article/how-to-create-a-strong-developer-portfolio-in-2025/)
- [BrainStation - How to Build a Web Developer Portfolio (2026 Guide)](https://brainstation.io/career-guides/how-to-build-a-web-developer-portfolio)
- [DEV Community - How to Build a Standout Portfolio in Tech](https://dev.to/dareyio/how-to-build-a-standout-portfolio-in-tech-that-attracts-recruiters-in-2025-2p07)
- [TieTalent - How to Build a Tech Portfolio That Gets You Hired](https://tietalent.com/en/blog/220/beyond-the-ats-how-to-build-a-tech-portfolio)
- [Pesto Tech - What Recruiters Look for in Developer Portfolios](https://pesto.tech/resources/what-recruiters-look-for-in-developer-portfolios)
- [Proxify - What Makes A Developer Portfolio Stand Out](https://proxify.io/knowledge-base/job-descriptions/what-makes-a-developer-portfolio-stand-out-to-recruiters)
- [Colorlib - Portfolio Design Trends 2025](https://colorlib.com/wp/portfolio-design-trends/)
- [Design Shack - Portfolio Design Trends for 2025](https://designshack.net/articles/trends/portfolio-design/)

### Technical Research
- [Microsoft Learn - Blazor Performance Best Practices](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/?view=aspnetcore-9.0)
- [Microsoft Learn - GitHub Pages Deployment](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly/github-pages?view=aspnetcore-10.0)
- [Developer's Voice - Production Blazor WASM Optimization](https://developersvoice.com/blog/dotnet/production-blazor-wasm-optimization-aot-pwa/)
- [Telerik - Optimizing Performance in Blazor WebAssembly](https://www.telerik.com/blogs/blazor-basics-optimizing-performance-blazor-webassembly-applications)
- [Steven Giesel - Tailwind v4 with Blazor](https://steven-giesel.com/blogPost/364c43d2-b31e-4377-8001-ac75ce78cdc6)
- [Tim Deschryver - Integrating Tailwind CSS in Blazor](https://timdeschryver.dev/blog/integrating-tailwind-css-in-blazor)
- [DC Coding - Deploying Blazor + Tailwind to GitHub Pages](https://codingblog.carterdan.net/2025/01/08/blazor-tailwind-github-pages/)
- [Matthew Regis - Blazor WASM GitHub Pages with GitHub Actions](https://matthewregis.dev/posts/blazor-web-assembly-github-pages-with-github-actions/)
- [Blazorise - Tailwind Quick Setup Without npm](https://blazorise.com/blog/blazor-and-tailwind-quick-setup-without-npm)

---

**Research Complete!**
