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
    public void IsPalindromeBasicWordsTest(string word, bool isPalindromeExpected)
    {
        var result = _palindromeService.IsPalindrome(word);

        Assert.Equal(isPalindromeExpected, result);
    }

    [Theory]
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData("z", true)]
    public void IsPalindromeEdgeCasesTest(string word, bool isPalindromeExpected)
    {
        var result = _palindromeService.IsPalindrome(word);

        Assert.Equal(isPalindromeExpected, result);
    }
}
