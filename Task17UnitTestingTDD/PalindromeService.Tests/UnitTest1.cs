namespace PalindromeService.Tests;

public class PalindromeServiceTest
{
    private PalindromeService _palindromeService;

    public PalindromeServiceTest()
        =>  _palindromeService = new PalindromeService();

    [Theory]
    [InlineData("mom", true)]
    [InlineData("john", false)]
    [InlineData("hannah", true)]
    [InlineData("rotator", true)]
    [InlineData("tractor", false)]
    public void IsPalindrome_mom_Test(string word, bool isPalindromeExpected)
    {
        var result = _palindromeService.IsPalindrome(word);

        Assert.Equal(isPalindromeExpected, result);
    }
}
