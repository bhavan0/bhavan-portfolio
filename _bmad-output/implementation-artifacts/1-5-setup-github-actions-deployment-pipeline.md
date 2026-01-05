# Story 1.5: Setup GitHub Actions Deployment Pipeline

Status: done

## Story

As a **developer**,
I want **automated deployment to GitHub Pages on push to main**,
So that **the portfolio is automatically updated when changes are merged**.

## Acceptance Criteria

1. **AC1**: Changes pushed to the main branch trigger GitHub Actions workflow
2. **AC2**: Tailwind CLI is downloaded (no npm dependency in CI)
3. **AC3**: Tailwind CSS is compiled with --minify flag
4. **AC4**: `dotnet publish -c Release` builds the Blazor WASM app
5. **AC5**: publish/wwwroot folder is deployed to GitHub Pages via `actions/deploy-pages@v4`
6. **AC6**: Deployment completes successfully
7. **AC7**: Site is accessible at the GitHub Pages URL
8. **AC8**: README.md includes setup and build instructions (NFR18)

## Tasks / Subtasks

- [x] **Task 1: Create GitHub Actions Workflow File** (AC: 1, 2, 3, 4, 5, 6)
  - [x] 1.1: Create `.github/workflows/deploy.yml` directory structure
  - [x] 1.2: Configure workflow trigger on push to main branch
  - [x] 1.3: Add checkout step using `actions/checkout@v4`
  - [x] 1.4: Add .NET 10 setup step using `actions/setup-dotnet@v4`
  - [x] 1.5: Add Tailwind CLI download step (Linux x64 binary, no npm)
  - [x] 1.6: Add Tailwind CSS compilation step with `--minify` flag
  - [x] 1.7: Add dotnet publish step with Release configuration
  - [x] 1.8: Add GitHub Pages configuration and artifact upload steps
  - [x] 1.9: Add deployment step using `actions/deploy-pages@v4`

- [x] **Task 2: Configure Repository for GitHub Pages** (AC: 5, 6, 7)
  - [x] 2.1: Verify `.nojekyll` file exists in wwwroot (required for `_framework` folder)
  - [x] 2.2: Verify `.gitattributes` contains `*.js binary` rule
  - [x] 2.3: Add `base href` consideration for repository deployment - documented in README
  - [x] 2.4: Add 404.html for SPA routing support on GitHub Pages - created via workflow copy step

- [x] **Task 3: Handle Blazor SPA Routing on GitHub Pages** (AC: 7)
  - [x] 3.1: Create 404.html that redirects to index.html for SPA routing - workflow copies index.html to 404.html
  - [x] 3.2: Verify index.html base href is correctly configured - set to "/"

- [x] **Task 4: Update README.md with Build Instructions** (AC: 8, NFR18)
  - [x] 4.1: Add project overview and purpose
  - [x] 4.2: Document local development prerequisites (.NET 10, Tailwind CLI)
  - [x] 4.3: Document local build commands
  - [x] 4.4: Document deployment process (automatic on push to main)
  - [x] 4.5: Document project structure

- [ ] **Task 5: Verify Deployment Pipeline** (AC: 6, 7)
  - [ ] 5.1: Commit and push changes to trigger workflow - requires manual push
  - [ ] 5.2: Verify workflow runs successfully in GitHub Actions - requires push
  - [ ] 5.3: Verify site is accessible at GitHub Pages URL - requires deployment
  - [ ] 5.4: Verify all assets load correctly (CSS, JS, images) - requires deployment

## Dev Notes

### Critical Architecture Constraints

**From Architecture Document (architecture.md):**

```yaml
# GitHub Pages Deployment - Key Decisions
Method: GitHub Actions artifact-based deployment
Trigger: Push to `main` branch
Action: `actions/deploy-pages@v4`
Tailwind in CI: Download standalone CLI (no npm dependency)
```

**Required CI Strategy (from architecture.md lines 252-260):**

```yaml
- name: Download Tailwind CLI
  run: |
    curl -sLO https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64
    chmod +x tailwindcss-linux-x64
    mv tailwindcss-linux-x64 tailwindcss
```

**Build Commands:**
```bash
# Tailwind (minified)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify

# Blazor publish
dotnet publish -c Release
```

### Previous Story Dependencies

**From Story 1.1 (already completed):**
- `.nojekyll` file exists in wwwroot
- `.gitattributes` with `*.js binary` rule exists
- Tailwind CSS v4 integrated via MSBuild target
- Project structure follows architecture decisions

**From Story 1.4 (already completed):**
- SEO meta tags configured
- og:url placeholder comment mentions Story 1.5 for GitHub Pages URL

### GitHub Actions Workflow Structure

**Recommended workflow structure based on current best practices (2025):**

```yaml
name: Deploy to GitHub Pages

on:
  push:
    branches: [ "main" ]
  workflow_dispatch:  # Allow manual trigger

permissions:
  contents: read
  pages: write
  id-token: write

concurrency:
  group: "pages"
  cancel-in-progress: false

jobs:
  build-and-deploy:
    runs-on: ubuntu-latest
    environment:
      name: github-pages
      url: ${{ steps.deployment.outputs.page_url }}
    steps:
      # ... workflow steps
```

### Blazor SPA Routing on GitHub Pages

**Problem:** GitHub Pages serves 404 for any route other than index.html (e.g., `/about` returns 404).

**Solution:** Create a 404.html that redirects to index.html with the original path as a query parameter, then index.html uses JavaScript to restore the route.

**Alternative:** Use hash-based routing (`#/about`) but this is less preferred for SEO.

**Recommended approach:** Copy index.html to 404.html during build, OR create a simple redirect 404.html.

### Base Href Configuration

**For repository deployment (username.github.io/repo-name):**
- `<base href="/repo-name/" />` in index.html

**For user/org page (username.github.io):**
- `<base href="/" />` (already set)

**Note:** If deploying to a repository project page, the base href in index.html must be updated to match the repository name. This can be done in the workflow or as a manual step.

### Latest GitHub Actions Versions (2025)

| Action | Current Version |
|--------|-----------------|
| `actions/checkout` | v4 |
| `actions/setup-dotnet` | v4 |
| `actions/configure-pages` | v5 |
| `actions/upload-pages-artifact` | v3 |
| `actions/deploy-pages` | v4 |

### Project Structure Notes

**Files to Create:**
- `.github/workflows/deploy.yml` - Main deployment workflow
- `BhavanPortfolio/wwwroot/404.html` - SPA routing fallback

**Files to Update:**
- `README.md` - Add build instructions (NFR18)

**Existing Files (verify):**
- `.nojekyll` in wwwroot (from Story 1.1)
- `.gitattributes` with JS binary rule (from Story 1.1)

### Testing the Deployment

**After pushing, verify:**
1. GitHub Actions workflow triggers automatically
2. Build step completes without errors
3. Tailwind CSS compiles successfully
4. Site deploys to GitHub Pages
5. All pages/routes work correctly
6. Theme toggle functions properly
7. All assets (CSS, images, favicon) load

### References

- [Source: architecture.md#Infrastructure-&-Deployment] - GitHub Pages deployment decisions
- [Source: architecture.md#CI-Tailwind-Strategy] - Tailwind CLI download in CI
- [Source: epics.md#Story-1.5] - Acceptance criteria
- [Source: Story 1.4 Code Review] - og:url deferred to Story 1.5
- [GitHub: deploy-pages action](https://github.com/actions/deploy-pages)
- [GitHub: Blazor GitHub Pages action](https://github.com/na1307/blazor-github-pages)

## Dev Agent Record

### Agent Model Used

Claude Opus 4.5 (claude-opus-4-5-20251101)

### Debug Log References

None - implementation proceeded without errors.

### Completion Notes List

1. **GitHub Actions Workflow Created (AC1, AC2, AC3, AC4, AC5, AC6):**
   - Created `.github/workflows/deploy.yml`
   - Triggers on push to main branch + manual workflow_dispatch
   - Uses `actions/checkout@v4`, `actions/setup-dotnet@v4`
   - Downloads Tailwind CLI from GitHub releases (no npm)
   - Compiles Tailwind with `--minify` flag
   - Runs `dotnet publish -c Release`
   - Deploys via `actions/deploy-pages@v4`

2. **SPA Routing Support (AC7):**
   - Workflow copies index.html to 404.html after publish
   - This handles GitHub Pages 404 responses for SPA routes

3. **Repository Configuration Verified:**
   - `.nojekyll` exists in wwwroot (from Story 1.1)
   - `.gitattributes` has `*.js binary` rule (from Story 1.1)
   - Base href set to "/" for user/org pages

4. **README.md Updated (AC8, NFR18):**
   - Project overview with tech stack
   - Local development instructions
   - Build commands (local and production)
   - Deployment process documentation
   - Project structure outline
   - Theme and base href configuration

5. **Deployment Verification (AC6, AC7):**
   - Requires manual push to main branch
   - GitHub Pages must be enabled in repository settings (Source: GitHub Actions)
   - First deployment may require manual approval in repository settings

6. **Build verified:** dotnet build succeeded with 0 errors, 0 warnings

### Change Log

- **`.github/workflows/deploy.yml`:** New file - Complete GitHub Actions deployment workflow
- **`README.md`:** Updated with comprehensive build and deployment documentation

### File List

**Created:**
- `.github/workflows/deploy.yml`

**Modified:**
- `README.md`

### Post-Implementation Notes

**To complete AC6 and AC7 (live deployment), user must:**
1. Push changes to main branch
2. Enable GitHub Pages in repository Settings > Pages
3. Set Source to "GitHub Actions"
4. First workflow run will deploy the site

**Base Href Note:**
If deploying to a repository project page (e.g., `username.github.io/repo-name`), update base href in `wwwroot/index.html` from `"/"` to `"/repo-name/"`.

### Code Review Fixes Applied

1. **[MEDIUM] .NET 10 preview flag:** Added `dotnet-quality: "preview"` to setup-dotnet action to ensure .NET 10 preview SDK is available in CI.

2. **[MEDIUM] .nojekyll in publish output:** Added step `touch ./BhavanPortfolio/publish/wwwroot/.nojekyll` to ensure the file exists in the deployment artifact, guaranteeing `_framework` folder is served correctly.

3. **[LOW] Missing restore step:** Left as-is - `dotnet publish` implicitly restores. Can add caching in future optimization.

4. **[LOW] README paths:** Left as-is - paths are for reference and Unix-style works in most contexts.
