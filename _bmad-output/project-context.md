---
project_name: 'bhavan-portfolio'
user_name: 'Bhavan'
date: '2026-01-04'
sections_completed: ['technology_stack', 'language_rules', 'framework_rules', 'code_quality', 'anti_patterns']
status: 'complete'
rule_count: 35
optimized_for_llm: true
---

# Project Context for AI Agents

_This file contains critical rules and patterns that AI agents must follow when implementing code in this project. Focus on unobvious details that agents might otherwise miss._

---

## Technology Stack & Versions

| Technology | Version | Notes |
|------------|---------|-------|
| .NET | 10.0 | Blazor WebAssembly, client-side only |
| C# | Latest | Modern language features enabled |
| Tailwind CSS | v4 | Standalone CLI, no npm dependency |
| Hosting | GitHub Pages | Static files only, artifact deployment |
| CI/CD | GitHub Actions | `actions/deploy-pages@v4` |
| Testing | bUnit | Blazor component testing framework |

**Critical Version Notes:**
- Use `dotnet new blazorwasm --framework net10.0` - flag is mandatory
- Tailwind v4 standalone CLI: `tailwindcss-windows-x64.exe` (local) / `tailwindcss-linux-x64` (CI)
- Tailwind config must be `tailwind.config.js` (no TypeScript support in standalone)
- Modern browsers only - no IE11 polyfills required

**Deployment Gotchas:**
- `.nojekyll` file required in wwwroot for `_framework` folder serving
- `.gitattributes` must include `*.dll binary`, `*.wasm binary`, `*.js binary`

## Critical Implementation Rules

### C# & Blazor Language Rules

**Nullable Reference Types:**
- Project uses nullable reference types (`<Nullable>enable</Nullable>`)
- Use `string?` for optional parameters, `string` with default for required
- Never use `null!` suppression - fix the actual nullability issue

**Component Parameters:**
- Required: `[Parameter, EditorRequired] public string Title { get; set; } = "";`
- Optional with default: `[Parameter] public string CssClass { get; set; } = "";`
- Optional nullable: `[Parameter] public string? GitHubUrl { get; set; }`

**Async Patterns:**
- Use `Task` return types for async methods, not `void`
- Exception: Event handlers can be `async void`
- Always `await` - never `.Result` or `.Wait()` (causes deadlocks in WASM)

**DI Registration:**
- Services: `builder.Services.AddSingleton<IThemeService, ThemeService>()`
- Always use interface + implementation pattern for testability

### Blazor Framework Rules

**Service Event Subscription Pattern (CRITICAL):**
```csharp
@implements IDisposable

@code {
    protected override void OnInitialized()
    {
        ThemeService.OnThemeChanged += HandleThemeChanged;
    }

    private void HandleThemeChanged() => StateHasChanged();

    public void Dispose()
    {
        ThemeService.OnThemeChanged -= HandleThemeChanged;
    }
}
```
- ALWAYS implement `IDisposable` when subscribing to service events
- Subscribe in `OnInitialized`, unsubscribe in `Dispose`
- Missing `Dispose` causes memory leaks

**JS Interop Rules:**
- Use `IJSRuntime` for all browser API calls
- JS modules in `wwwroot/js/` access browser APIs only (localStorage, matchMedia, scrollIntoView)
- DOM manipulation (adding/removing classes) done via Blazor, NOT JavaScript
- Import modules: `await JS.InvokeAsync<IJSObjectReference>("import", "./js/theme.js")`

**Component Lifecycle:**
- `OnInitialized` / `OnInitializedAsync` - Setup, subscribe to events
- `OnParametersSet` - React to parameter changes
- `Dispose` - Cleanup event subscriptions (REQUIRED if subscribed)

**StateHasChanged:**
- Call after service events fire to trigger re-render
- Never call in render cycle (causes infinite loop)

### Code Quality & Style Rules

**Naming Conventions:**
| Element | Convention | Example |
|---------|------------|---------|
| Razor components | PascalCase | `HeroSection.razor`, `ProjectCard.razor` |
| C# classes/interfaces | PascalCase | `ThemeService.cs`, `IThemeService.cs` |
| JS modules | camelCase | `theme.js`, `scroll.js` |
| CSS files | kebab-case | `app.css` |
| Asset files | kebab-case | `profile.jpg`, `resume.pdf` |

**Folder Organization:**
| Component Type | Folder | Rule |
|----------------|--------|------|
| Page layouts | `Components/Layout/` | MainLayout, NavBar, Footer only |
| Page sections | `Components/Sections/` | One per portfolio section |
| Reusable UI | `Components/Shared/` | Used across multiple sections |
| Services | `Services/` | Interface + implementation pairs |
| JS modules | `wwwroot/js/` | Browser API access only |
| Static assets | `wwwroot/assets/` | Images, PDFs, fonts |

**Tailwind Color Palette (STRICT):**
Only these colors allowed - no exceptions:
- `black`, `white`
- `gray-50`, `gray-200`, `gray-300`, `gray-400`
- `gray-600`, `gray-700`, `gray-800`, `gray-900`

Using any other color (e.g., `blue-500`, `red-400`) violates project design.

### Critical Anti-Patterns

**NEVER Do These:**
- ❌ `heroSection.razor` - Wrong: use PascalCase → `HeroSection.razor`
- ❌ `theme-toggle.razor` - Wrong: use PascalCase → `ThemeToggle.razor`
- ❌ `bg-blue-500` - Wrong: not in allowed color palette
- ❌ Direct DOM manipulation in JS modules - Use Blazor via IJSRuntime
- ❌ Missing `IDisposable` when subscribing to service events
- ❌ Using `.Result` or `.Wait()` on Tasks - Causes WASM deadlocks
- ❌ Calling `StateHasChanged()` during render - Causes infinite loop

**Theme System Gotchas:**
- Theme script in `index.html` runs BEFORE Blazor loads (prevents flash)
- `ThemeService.InitializeAsync()` must SYNC with index.html's applied theme
- Theme resolution: localStorage → system preference → dark (default)
- Body class is `dark` or `light` - Tailwind `darkMode: 'class'` config

**Loading Shell Rules:**
- Static HTML in `index.html` must MATCH `HeroSection` component exactly
- Use same Tailwind classes in both for seamless transition
- `<body class="dark blazor-loading">` - loading class removed when app ready
- 10s JavaScript timeout for WASM failure fallback (FR37)

**GitHub Pages Deployment:**
- `.nojekyll` required or `_framework` folder is ignored
- Base href must match repository name if not using custom domain
- All routes must work with `index.html` fallback (SPA routing)

---

## Usage Guidelines

**For AI Agents:**
- Read this file before implementing any code
- Follow ALL rules exactly as documented
- When in doubt, prefer the more restrictive option
- Update this file if new patterns emerge during implementation

**For Humans:**
- Keep this file lean and focused on agent needs
- Update when technology stack changes
- Review quarterly for outdated rules
- Remove rules that become obvious over time

Last Updated: 2026-01-04
