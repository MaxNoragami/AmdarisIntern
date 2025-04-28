using System.Text.RegularExpressions;

namespace PalindromeService;

public class PalindromeService
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
