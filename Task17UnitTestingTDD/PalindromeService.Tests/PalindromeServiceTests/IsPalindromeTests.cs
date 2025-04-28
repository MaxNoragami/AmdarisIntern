namespace PalindromeService.Tests.PalindromeServiceTests;

public class IsPalindromeTests
{
    private readonly IPalindromeService _palindromeService;

    public static TheoryData<string, bool> BasicWordsData = new TheoryData<string, bool>()
    {
        { "mom", true },
        { "john", false },
        { "hannah", true },
        { "rotator", true },
        { "tractor", false },
    };

    public static TheoryData<string, bool> EdgeCasesData = new TheoryData<string, bool>()
    {
        { "", true },
        { null, true },
        { "z", true },
    };

    public static TheoryData<string, bool> CaseInsensitiveData = new TheoryData<string, bool>()
    {
        { "YoYOy", true },
        { "Panama", false },
        { "UFOtofu", true },
    };

    public IsPalindromeTests()
        =>  _palindromeService = new PalindromeService();

    [Theory]
    [MemberData(nameof(BasicWordsData))]
    [MemberData(nameof(EdgeCasesData))]
    [MemberData(nameof(CaseInsensitiveData))]
    public void IsPalindromeTest(string word, bool isPalindromeExpected)
    {
        var result = _palindromeService.IsPalindrome(word);

        Assert.Equal(isPalindromeExpected, result);
    }
}
