# Story 1.1: Initialize Blazor WASM Project with Tailwind CSS

Status: ready-for-dev

## Story

As a **developer**,
I want **a properly configured Blazor WASM project with Tailwind CSS v4**,
So that **I have a clean foundation following architecture decisions for building the portfolio**.

## Acceptance Criteria

1. **AC1**: Blazor WASM project created using `dotnet new blazorwasm -o BhavanPortfolio --framework net10.0`
2. **AC2**: Bootstrap CSS completely removed from the project
3. **AC3**: Tailwind CSS v4 installed via standalone CLI (no npm dependency)
4. **AC4**: `tailwind.config.js` created with `darkMode: 'class'` and B&W palette constraints
5. **AC5**: `tailwind-input.css` contains the @tailwind directives (Tailwind v4 uses `@import "tailwindcss";`)
6. **AC6**: MSBuild target added to `BhavanPortfolio.csproj` for Tailwind compilation
7. **AC7**: Folder structure matches architecture: `Components/Layout/`, `Components/Sections/`, `Components/Shared/`, `Services/`
8. **AC8**: `.nojekyll` file exists in `wwwroot/` for GitHub Pages
9. **AC9**: `.gitattributes` contains binary rules for `*.js`, `*.dll`, `*.wasm`
10. **AC10**: `dotnet build` compiles successfully with Tailwind CSS output

## Tasks / Subtasks

- [ ] **Task 1: Initialize Blazor WASM Project** (AC: 1)
  - [ ] 1.1: Run `dotnet new blazorwasm -o BhavanPortfolio --framework net10.0`
  - [ ] 1.2: Verify project structure created correctly
  - [ ] 1.3: Ensure `BhavanPortfolio.csproj` targets `net10.0`

- [ ] **Task 2: Remove Bootstrap and Default Styling** (AC: 2)
  - [ ] 2.1: Delete `wwwroot/css/bootstrap/` folder entirely
  - [ ] 2.2: Delete `wwwroot/css/app.css` (will be replaced by Tailwind output)
  - [ ] 2.3: Remove Bootstrap references from `wwwroot/index.html`
  - [ ] 2.4: Remove any Bootstrap class usage from default `MainLayout.razor`
  - [ ] 2.5: Remove any Bootstrap class usage from `App.razor`

- [ ] **Task 3: Setup Tailwind CSS v4 Standalone CLI** (AC: 3, 5)
  - [ ] 3.1: Download Tailwind standalone CLI for Windows (`tailwindcss-windows-x64.exe`)
  - [ ] 3.2: Place executable in project root as `tailwindcss.exe`
  - [ ] 3.3: Add `tailwindcss.exe` to `.gitignore` (binary not committed)
  - [ ] 3.4: Create `tailwind-input.css` with `@import "tailwindcss";` directive
  - [ ] 3.5: Verify CLI runs: `./tailwindcss.exe -i ./tailwind-input.css -o ./wwwroot/css/app.css`

- [ ] **Task 4: Configure Tailwind for B&W Palette** (AC: 4)
  - [ ] 4.1: Create `tailwind.config.js` in project root
  - [ ] 4.2: Set `darkMode: 'class'`
  - [ ] 4.3: Configure content paths: `['./Components/**/*.razor', './wwwroot/index.html']`
  - [ ] 4.4: Define safelist for allowed B&W colors only (optional enforcement)
  - [ ] 4.5: Test config by running Tailwind CLI

- [ ] **Task 5: Configure MSBuild Integration** (AC: 6)
  - [ ] 5.1: Add `<Target Name="BuildTailwind">` to `BhavanPortfolio.csproj`
  - [ ] 5.2: Configure target to run before `Build` target
  - [ ] 5.3: Target executes: `tailwindcss.exe -i ./tailwind-input.css -o ./wwwroot/css/app.css`
  - [ ] 5.4: Add `--minify` flag for Release configuration
  - [ ] 5.5: Test with `dotnet build` - verify CSS generates

- [ ] **Task 6: Create Architecture Folder Structure** (AC: 7)
  - [ ] 6.1: Create `Components/Layout/` directory
  - [ ] 6.2: Create `Components/Sections/` directory
  - [ ] 6.3: Create `Components/Shared/` directory
  - [ ] 6.4: Create `Services/` directory
  - [ ] 6.5: Create `wwwroot/js/` directory
  - [ ] 6.6: Create `wwwroot/assets/` directory
  - [ ] 6.7: Move `MainLayout.razor` to `Components/Layout/`
  - [ ] 6.8: Update `_Imports.razor` with correct using statements

- [ ] **Task 7: Configure GitHub Pages Requirements** (AC: 8, 9)
  - [ ] 7.1: Create empty `.nojekyll` file in `wwwroot/`
  - [ ] 7.2: Create `.gitattributes` in project root with:
    ```
    *.dll binary
    *.wasm binary
    *.js binary
    ```
  - [ ] 7.3: Verify files are tracked by git

- [ ] **Task 8: Update index.html for Tailwind** (AC: 2, 10)
  - [ ] 8.1: Update `<link>` tag to reference `css/app.css` (Tailwind output)
  - [ ] 8.2: Remove any Bootstrap references
  - [ ] 8.3: Add base Tailwind body classes: `class="bg-black text-white"`

- [ ] **Task 9: Verify Build Success** (AC: 10)
  - [ ] 9.1: Run `dotnet build` and verify no errors
  - [ ] 9.2: Verify `wwwroot/css/app.css` contains Tailwind output
  - [ ] 9.3: Run `dotnet run` and verify app launches
  - [ ] 9.4: Open browser and verify basic styling works

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document:**
- Starter command: `dotnet new blazorwasm -o BhavanPortfolio --framework net10.0` (EXACT command required)
- Tailwind CSS v4 standalone CLI - NO npm dependency
- Body class approach for theme: `dark` / `light` with `darkMode: 'class'`
- B&W palette ONLY: black, white, gray-50, gray-200, gray-300, gray-400, gray-600, gray-700, gray-800, gray-900

**From Project Context:**
- `.nojekyll` required for `_framework` folder serving on GitHub Pages
- `.gitattributes` must include `*.dll binary`, `*.wasm binary`, `*.js binary`
- Tailwind config must be `tailwind.config.js` (no TypeScript support in standalone)

### Tailwind CSS v4 Important Changes

**CRITICAL - Tailwind v4 Migration Notes:**
- In Tailwind v4, the CLI is a SEPARATE package (`@tailwindcss/cli`) or standalone binary
- The `tailwind.config.js` is OPTIONAL in v4 - CSS-first configuration is the new default
- Input file uses `@import "tailwindcss";` instead of separate `@tailwind base/components/utilities`
- For this project, we WILL use `tailwind.config.js` to enforce `darkMode: 'class'`

**Standalone CLI Download:**
```bash
# Windows
curl -sLO https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-windows-x64.exe
mv tailwindcss-windows-x64.exe tailwindcss.exe

# Linux (for CI)
curl -sLO https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64
chmod +x tailwindcss-linux-x64
mv tailwindcss-linux-x64 tailwindcss
```

### .NET 10 Blazor WASM Notes

**CRITICAL - .NET 10 Changes:**
- The standalone `blazorwasm` template still exists for client-only scenarios
- Use `--framework net10.0` flag (mandatory)
- Hot Reload is now automatic in .NET 10 - no configuration needed
- `blazor.web.js` is now fingerprinted and compressed (76% smaller)

### Project Structure After Completion

```
BhavanPortfolio/
├── .github/                    # (Created in Story 1.5)
├── Components/
│   ├── Layout/
│   │   └── MainLayout.razor    # Moved from default location
│   ├── Sections/               # Empty, ready for future stories
│   └── Shared/                 # Empty, ready for future stories
├── Services/                   # Empty, ready for future stories
├── wwwroot/
│   ├── css/
│   │   └── app.css             # Tailwind output (generated)
│   ├── js/                     # Empty, ready for future stories
│   ├── assets/                 # Empty, ready for future stories
│   ├── index.html              # Updated for Tailwind
│   └── .nojekyll               # GitHub Pages requirement
├── App.razor
├── Program.cs
├── _Imports.razor              # Updated with correct namespaces
├── BhavanPortfolio.csproj      # With MSBuild Tailwind target
├── tailwind.config.js          # Tailwind configuration
├── tailwind-input.css          # Tailwind input directives
├── tailwindcss.exe             # Standalone CLI (gitignored)
└── .gitattributes              # Binary file rules
```

### MSBuild Target Example

```xml
<Target Name="BuildTailwind" BeforeTargets="Build">
  <Exec Command=".\tailwindcss.exe -i .\tailwind-input.css -o .\wwwroot\css\app.css" Condition="'$(Configuration)' == 'Debug'" />
  <Exec Command=".\tailwindcss.exe -i .\tailwind-input.css -o .\wwwroot\css\app.css --minify" Condition="'$(Configuration)' == 'Release'" />
</Target>
```

### tailwind.config.js Example

```javascript
/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'class',
  content: [
    './Components/**/*.razor',
    './wwwroot/index.html'
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

### tailwind-input.css Example

```css
@import "tailwindcss";
```

### References

- [Source: architecture.md#Starter-Template-Evaluation] - Initialization command and rationale
- [Source: architecture.md#Implementation-Patterns] - Naming conventions and folder structure
- [Source: architecture.md#Infrastructure-Deployment] - GitHub Pages requirements
- [Source: project-context.md#Technology-Stack] - Version requirements and gotchas
- [Source: project-context.md#Critical-Anti-Patterns] - What NOT to do
- [Source: Tailwind CSS Standalone CLI](https://tailwindcss.com/blog/standalone-cli) - Official documentation
- [Source: Tailwind CSS v4 CLI Setup](https://dev.to/sharanappa_m/how-to-set-up-tailwind-css-v4-using-tailwind-cli-1481) - v4 specific setup guide

## Dev Agent Record

### Agent Model Used

{{agent_model_name_version}}

### Debug Log References

### Completion Notes List

### Change Log

### File List

