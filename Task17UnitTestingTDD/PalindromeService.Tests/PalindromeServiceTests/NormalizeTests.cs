namespace PalindromeService.Tests.PalindromeServiceTests;

public class InputCleanUpTestData : TheoryData<string, string>
{
    public InputCleanUpTestData()
    {
        Add("Ed, I saw Harpo Marx ram Oprah W. aside.", "edisawharpomarxramoprahwaside");
        Add("Yo, banana boy!", "yobananaboy");
    }
}

public class NormalizeTests
{
    private readonly PalindromeService _palindromeService;

    public static TheoryData<string, string> WordsToLowerTestData => new TheoryData<string, string>()
    {
        { "BOOM", "boom" },
        { "BoNjOuR", "bonjour"}
    };

    public NormalizeTests()
        => _palindromeService = new PalindromeService();

    [Theory]
    [MemberData(nameof(WordsToLowerTestData))]
    public void NormalizeWordsToLowerTest(string input, string outputExpected)
    {
        var result = _palindromeService.Normalize(input);

        Assert.Equal(outputExpected, result);
    }

    [Theory]
    [ClassData(typeof(InputCleanUpTestData))]
    public void NormalizeInputCleanUpTest(string input, string outputExpected)
    {
        var result = _palindromeService.Normalize(input);

        Assert.Equal(outputExpected, result);
    }
}
