using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace PlaywrightFrameworkTest.Automation.Common.Extensions;

/// <summary>
/// Extensions : strings
/// </summary>
public static class StringExtensions
{
    private static readonly Random s_Random = new ();
    
    /// <summary>
    /// Removes all numbers, keeping letters and special characters.
    /// </summary>
    public static string RemoveNumbers(this string originalString)
    {
        return Regex.Replace(originalString, @"[\d-]", string.Empty);
    }

    /// <summary>
    /// Removes all special characters, keeping letters and numbers.
    /// </summary>
    public static string RemoveSpecialCharacters(this string originalString)
    {
        return Regex.Replace(originalString, "[^0-9A-Za-z]+", string.Empty);
    }

    /// <summary>
    /// Removes all letters, keeping special characters and numbers.
    /// </summary>
    public static string RemoveLetters(this string originalString)
    {
        return Regex.Replace(originalString, "[A-Za-z]", string.Empty);
    }
    
    /// <summary>
    /// Returns a random length string
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[s_Random.Next(s.Length)]).ToArray());
    }

    /// <summary>
    /// Escape email address to be used as a selector
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <returns></returns>
    public static string EscapeEmailAddress(this string emailAddress)
    {
        Guard.Against.Null(emailAddress, nameof(emailAddress));

        return emailAddress
            .Replace("@", @"\@")
            .Replace(".", @"\.");
    }
}