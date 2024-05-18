
namespace PlaywrightFrameworkTest.Automation.Common.Exceptions;

public class NotFoundException : Exception
{

    /// Construct with base message
    public NotFoundException(string message) : base(message)
    {
    }
    /// Construct with base message and inner exception
    public NotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}

