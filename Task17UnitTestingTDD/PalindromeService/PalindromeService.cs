using System.Text.RegularExpressions;

namespace PalindromeService;
public interface IPalindromeService
{
    public bool IsPalindrome(string input);
    public string Normalize(string input);
}

public class PalindromeService(ILogger logger) : IPalindromeService
{
    private readonly ILogger _logger = logger;

    public bool IsPalindrome(string input)
    {
        _logger.Log($"Checking if '{input}' is a palindrome");

        if (string.IsNullOrWhiteSpace(input))
            return true;

        var normalizedInput = Normalize(input);
        var result = normalizedInput == string.Join("", normalizedInput.Reverse());

        _logger.Log($"Result for '{input}': {result}");

        return result;
    }

    public string Normalize(string input)
        => Regex.Replace(input, @"[.,!?\- ]+", string.Empty).ToLower();
}
