# ParkerPortfolio

A personal portfolio site for Aaron Joel Parker, software engineer.

Built in Blazor WebAssembly. Styled in the Fluent UI design language. Deployed as a static site to GitHub Pages.

The portfolio doubles as its own proof of skill: a .NET portfolio implemented in .NET, running C# in the browser via WebAssembly, with no JavaScript framework underneath.

## Featured projects

Each project gets its own deep-dive page with an aesthetic tuned to the project itself, not to the portfolio shell. The home page surfaces them as cards; the deep-dives own their full canvas.

- **RoomLoom** (the Weaver). Modular live-conference platform where scheduling providers and media backends plug into contracts the core owns.
- **Fulcrum** (the Broker). Surfaces market signal from news and filings without shouting or claiming certainty.
- **Lampyr** (the Firefly). Translates environmental sound into haptic and visual awareness for Deaf households, without breaking the quiet.
- **Between Bells** (the Balcony). A medieval HD-2D stealth game where a watchmaker slips past royal guards to reach the princess's balcony before the next bell tolls.

## Stack

This site itself is built on:

- .NET 10, C# 14
- Blazor WebAssembly
- Microsoft.FluentUI.AspNetCore.Components
- CSS isolation for per-page theming
- GitHub Pages for static hosting

## Run locally

```bash
git clone https://github.com/AJoParker/ParkerPortfolio.git
cd ParkerPortfolio
dotnet restore
dotnet run
```

The site will be available at `http://localhost:5xxx`. Hot reload picks up Razor and CSS changes as you save.

## Deploy

Deployment is a script you run, and the published bundle is committed to the repo:

```bash
./publish-pages.sh
git add docs && git commit -m "publish site"
git push
```

`publish-pages.sh` publishes the WebAssembly bundle into `docs/`, rewrites `<base href>` to the `/parkerportfolio/` project-page subpath, drops a `.nojekyll` flag so Jekyll doesn't strip `_framework/`, and copies `index.html` to `404.html` as the SPA fallback for deep links. `docs/` is generated — never hand-edit it.

GitHub Pages is configured as **Deploy from a branch → `main` → `/docs`**. The live site lives at [ajoparker.github.io/parkerportfolio](https://ajoparker.github.io/parkerportfolio/).

Because the site is served from a subpath, every internal link in the Razor source is **base-relative** (`href="projects/roomloom"`, not `href="/projects/roomloom"`). A leading slash bypasses the `<base>` tag and breaks in production while still appearing to work locally.

## Structure

```
Data/              project catalog, the source of truth for what shows on the home page
Layouts/           MainLayout for the site shell, ProjectLayout for the deep-dives
Models/            the Project record
Pages/             Home plus per-project deep-dives under Projects/
Shared/            SiteHeader, SiteFooter, ProjectCard, and other reused components
wwwroot/           static assets, global CSS, the host index.html
docs/              generated. the published bundle GitHub Pages serves
```

Per-page themes are scoped via Blazor's CSS isolation. Each `.razor` has a co-located `.razor.css`, and a project's deep-dive can override Fluent UI design tokens locally without affecting the rest of the site.

## Why Blazor

Most portfolio sites in this space are React, Astro, or Next. This one is Blazor because:

1. It demonstrates the skill the site claims I have.
2. The recursive proof beats a paragraph of self-description.
3. Static publish means GitHub Pages hosts it for free, same as any JS framework.

## Contact

- Email: aaronparker714@outlook.com
- LinkedIn: [aaron-parker714](https://www.linkedin.com/in/aaron-parker714)
- GitHub: [AJoParker](https://github.com/AJoParker)