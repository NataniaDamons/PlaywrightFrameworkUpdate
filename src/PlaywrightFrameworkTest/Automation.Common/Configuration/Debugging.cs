
using JetBrains.Annotations;

namespace PlaywrightFrameworkTest.Automation.Common.Configuration;

[UsedImplicitly]
public record Debugging
{
    //Enable Headless mode 
    public bool HeadlessMode { get; set; }

    //output folder when debugging is done running - this is where deliverables and accounts will sit 
    public string ? OutputFolder { get; set; }
}