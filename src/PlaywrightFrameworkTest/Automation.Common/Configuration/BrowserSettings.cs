using JetBrains.Annotations;

namespace PlaywrightFrameworkTest.Automation.Common.Configuration;

[UsedImplicitly]
public record BrowserSettings{
    public string? Type { get; set; }
}