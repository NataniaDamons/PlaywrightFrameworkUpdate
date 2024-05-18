
using JetBrains.Annotations;

namespace PlaywrightFrameworkTest.Automation.Common.Configuration;

public record Viewport
{
    //set width of the viewport 
    public int Width { get; [UsedImplicitly] set; }
    //set hight of the viewport 
    public int Height { get; [UsedImplicitly] set; }
}