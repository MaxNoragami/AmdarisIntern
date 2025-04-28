using System.Text.RegularExpressions;

namespace PalindromeService;
public interface IPalindromeService
{
    public bool IsPalindrome(string input);
    public string Normalize(string input);
}

public class PalindromeService : IPalindromeService
{
    public bool IsPalindrome(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return true;

        var normalizedInput = Normalize(input);

        return normalizedInput == string.Join("", normalizedInput.Reverse());
    }

    public string Normalize(string input)
        => Regex.Replace(input, @"[.,!?\- ]+", string.Empty).ToLower();
}
