namespace PalindromeService;

public class PalindromeService
{
    public bool IsPalindrome(string word)
        => word == string.Join("", word.Reverse());
}
