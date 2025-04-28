namespace PalindromeService.Tests;

public class PalindromeServiceTest
{
    private PalindromeService _palindromeService;

    public PalindromeServiceTest()
        =>  _palindromeService = new PalindromeService();

    [Fact]
    public void IsPalindrome_mom_Test()
    {
        var result = _palindromeService.IsPalindrome("mom");

        Assert.True(result);
    }
}
