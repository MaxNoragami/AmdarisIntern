namespace PalindromeService;

public class PalindromeService
{
    public bool IsPalindrome(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return true;

        return word == string.Join("", word.Reverse());
    }
}
