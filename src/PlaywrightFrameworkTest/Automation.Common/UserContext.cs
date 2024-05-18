using Ardalis.GuardClauses;

namespace PlaywrightFrameworkTest.Automation.Common.Utilities;

/// <summary>
/// Extensions : User context files
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class UserContext
{
    /// <summary>
    /// Determine if the user context file has already been saved to disk
    /// </summary>
    /// <param name="destinationFolder"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    private static bool IsContextSaved(string destinationFolder, string userName)
    {
        var fileName = GetUserContextFileName(destinationFolder, userName);
        return File.Exists(fileName);
    }

    /// <summary>
    /// Determine if the user context exists on disk and has not expired 
    /// </summary>
    /// <param name="destinationFolder"></param>
    /// <param name="userName"></param>
    /// <param name="thresholdInHours"></param>
    /// <returns></returns>
    public static bool IsContextExpired(string destinationFolder, string userName, int thresholdInHours)
    {
        if (!IsContextSaved(destinationFolder, userName))
        {
            return true;
        }

        var fileCreationDate = File.GetCreationTime(GetUserContextFileName(destinationFolder, userName));
        return fileCreationDate < DateTime.Now.AddHours(thresholdInHours * -1);
    }

    /// <summary>
    /// Combines the destination and username to provide the full path for a user context file
    /// </summary>
    /// <param name="destinationFolder"></param>
    /// <param name="userName"></param>
    /// <returns></returns>
    public static string GetUserContextFileName(string destinationFolder, string userName)
    {
        Guard.Against.NullOrEmpty(destinationFolder);
        Guard.Against.NullOrEmpty(userName);

        return Path.Combine(destinationFolder, userName);
    }
}