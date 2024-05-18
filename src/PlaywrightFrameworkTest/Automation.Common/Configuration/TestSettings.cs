
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

    //get the settings for the accounts available 
    public Account[]? Accounts { get; set; }

    //setup Debugging options 
    public Debugging? Debugging { get; set; }

    //Determine how many parallel login attempts should be executed at the same time
    public int LoginParallelism { get; set; }

    //Manage viewports
    public Viewport? Viewport  { get; set;}
}
