# Bhavan Portfolio

A professional developer portfolio built with Blazor WebAssembly and Tailwind CSS v4, deployed to GitHub Pages.

## Tech Stack

- **Framework:** Blazor WebAssembly (.NET 10)
- **Styling:** Tailwind CSS v4 (standalone CLI)
- **Hosting:** GitHub Pages
- **CI/CD:** GitHub Actions

## Features

- Dark/Light theme with system preference detection
- Responsive design (mobile, tablet, desktop)
- SEO optimized with meta tags and OpenGraph
- Fast loading with static HTML shell
- Smooth scroll navigation

## Local Development

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Tailwind CSS CLI (downloaded automatically on first build, or manually from [Tailwind releases](https://github.com/tailwindlabs/tailwindcss/releases))

### Running Locally

```bash
cd BhavanPortfolio

# Build and run (Tailwind compiles via MSBuild target)
dotnet run

# Or with hot reload
dotnet watch run
```

### Manual Tailwind Build

```bash
cd BhavanPortfolio

# Development (with watch)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --watch

# Production (minified)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify
```

## Project Structure

```
BhavanPortfolio/
├── Components/
│   ├── Layout/        # MainLayout, NavBar, Footer
│   ├── Sections/      # Hero, About, Skills, Projects, Timeline, Contact
│   └── Shared/        # Reusable components (ThemeToggle, ProjectCard, etc.)
├── Services/          # ThemeService, ScrollService
├── wwwroot/
│   ├── css/           # Tailwind output
│   ├── js/            # JS interop modules
│   └── assets/        # Images, resume PDF
├── tailwind-input.css # Tailwind directives
└── tailwind.config.js # Tailwind configuration
```

## Deployment

Deployment is automated via GitHub Actions:

1. Push changes to the `main` branch
2. GitHub Actions workflow triggers automatically
3. Tailwind CSS is compiled with minification
4. Blazor WASM app is published
5. Site is deployed to GitHub Pages

### Manual Deployment

```bash
cd BhavanPortfolio

# Build Tailwind (minified)
./tailwindcss -i ./tailwind-input.css -o ./wwwroot/css/app.css --minify

# Publish Blazor
dotnet publish -c Release -o publish

# Deploy publish/wwwroot to GitHub Pages
```

## Configuration

### Theme System

The site supports dark and light themes with the following priority:
1. User preference (stored in localStorage)
2. System preference (prefers-color-scheme)
3. Default: dark

### Base Href

For deployment to a repository project page (e.g., `username.github.io/repo-name`), update the base href in `wwwroot/index.html`:

```html
<base href="/repo-name/" />
```

For user/organization pages (`username.github.io`), keep it as:

```html
<base href="/" />
```

## License

MIT
