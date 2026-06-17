using ParkerPortfolio.Models;

namespace ParkerPortfolio.Data;

public static class ProjectsCatalog
{
    public static IReadOnlyList<Project> All { get; } = new[]
    {
        new Project(
            Slug: "roomloom",
            Name: "RoomLoom",
            Archetype: "Weaver",
            Tagline: "Modular live-conference platform.",
            Description: "Real-time conferencing where scheduling providers and media backends plug into contracts the core owns. The core never knows which calendar or video system it talks to. Adding a new system means writing one adapter, not editing the center.",
            AccentHex: "#D8642E",
            AccentSecondaryHex: "#F0B080",
            Stack: new[] { "ASP.NET Core", "SignalR", "EF Core", "MAUI", "Azure", "GitHub Actions", "Hexagonal Architecture" },
            GitHubUrl: "https://github.com/AJoParker/roomloom"
        ),
        new Project(
            Slug: "fulcrum",
            Name: "Fulcrum",
            Archetype: "Broker",
            Tagline: "Market signal from news and filings.",
            Description: "Surfaces signal from news and filings without shouting or claiming certainty. Built for traders who want context, not noise. The information broker, not the bookie.",
            AccentHex: "#E8A82B",
            AccentSecondaryHex: "#22D3EE",
            Stack: new[] { "ASP.NET Core", "Blazor Server", "SignalR", "EF Core", "Azure", "Azure OpenAI", "TimescaleDB", "GitHub Actions", "Clean Architecture" },
            Status: "In progress"
        ),
        new Project(
            Slug: "lampyr",
            Name: "Lampyr",
            Archetype: "Firefly",
            Tagline: "Environmental sound, translated.",
            Description: "Translates environmental sound into haptic and visual awareness for Deaf households. The kitchen smoke alarm becomes a pulse on the wrist and a glow on the wall, without breaking the quiet.",
            AccentHex: "#5C5CE6",
            AccentSecondaryHex: "#FF6B6B",
            Stack: new[] { "ASP.NET Core", "Blazor", "SignalR", "EF Core", "MAUI", "ONNX Runtime", "Azure IoT Hub", "Azure Functions", "GitHub Actions", "Clean Architecture" },
            Status: "In progress"
        ),
        new Project(
            Slug: "between-bells",
            Name: "Between Bells",
            Archetype: "Balcony",
            Tagline: "A watchmaker. A balcony. No blades.",
            Description: "Medieval HD-2D stealth where a watchmaker slips past royal guards to reach the princess's balcony before the next bell tolls. Draw a blade and the game ends.",
            AccentHex: "#B8893D",
            AccentSecondaryHex: "#D8D8E8",
            Stack: new[] { "C# 13", ".NET 10", "Silk.NET", "OpenGL 4.1", "GLSL", "ImGui", "GitHub Actions", "Clean Architecture" },
            Status: "In progress"
        )
    };
}
