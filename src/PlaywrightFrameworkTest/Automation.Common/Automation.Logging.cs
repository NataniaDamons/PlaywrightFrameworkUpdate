using NUnit.Framework;

namespace PlaywrightFrameworkTest.Automation.Common;

/// <summary>
/// Logging utilities for contextual information within the test
/// </summary>
/// <remarks>
/// Warnings are a built in concept for NUnit : https://docs.nunit.org/articles/nunit/writing-tests/Warnings.html
/// </remarks>
public partial class Automation
{
    /// <summary>
    /// Writes a message to the test log
    /// </summary>
    /// <param name="message"></param>
    protected async Task WriteLine(string message)
    {
        await TestContext.Out.WriteLineAsync(message);
    }
    
    /// <summary>
    /// Write an error message to the test log
    /// </summary>
    /// <param name="message"></param>
    public async Task WriteError(string message)
    {
        await TestContext.Error.WriteLineAsync(message);
    }
}