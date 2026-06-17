namespace ParkerPortfolio.Models;

public record Project(
    string Slug,
    string Name,
    string Archetype,
    string Tagline,
    string Description,
    string AccentHex,
    string AccentSecondaryHex,
    string[] Stack,
    string Status = "Active",
    string? LiveDemoUrl = null,
    string? GitHubUrl = null
);
