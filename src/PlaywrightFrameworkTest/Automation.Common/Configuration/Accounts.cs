using JetBrains.Annotations;


namespace PlaywrightFrameworkTest.Automation.Common.Configuration;

[UsedImplicitly]
public record Account
{
    public string? Name { get; init; }
    public string? EmailAddress { get; init; }
    public string? Password { get; init; }
}

