
using JetBrains.Annotations;

namespace PlaywrightFrameworkTest.Automation.Common.Configuration;

[UsedImplicitly]

public record TestSettings
{
    //Test Url
    public string? TestUrl { get; set; }

    //Gets and sets operation speed 
    public int OperationSpeed { get; set; }

    //setup Debugging options 
    public Debugging? Debugging { get; set; }

    //Manage viewports
    public Viewport? Viewport  { get; set;}

    public BrowserSettings? Browser { get; set; }
}
