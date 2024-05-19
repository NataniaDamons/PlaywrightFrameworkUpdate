
using JetBrains.Annotations;

namespace PlaywrightFrameworkTest.Automation.Common.Configuration;

[UsedImplicitly]

public record TestSettings
{
    //Login address 
    public string? LoginUrl { get; set; }

    public string? TestUrl { get; set; }

    //Gets and sets operation speed 
    public int OperationSpeed { get; set; }

    //setup Debugging options 
    public Debugging? Debugging { get; set; }

    //Manage viewports
    public Viewport? Viewport  { get; set;}
}
