using Moq;

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
    private readonly IPalindromeService _palindromeService;
    private readonly Mock<ILogger> _loggerMock;

    public static TheoryData<string, string> WordsToLowerTestData => new TheoryData<string, string>()
    {
        { "BOOM", "boom" },
        { "BoNjOuR", "bonjour"}
    };

    public NormalizeTests()
    {
        _loggerMock = new Mock<ILogger>();
        _palindromeService = new PalindromeService(_loggerMock.Object);
    }

    [Theory]
    [MemberData(nameof(WordsToLowerTestData))]
    [ClassData(typeof(InputCleanUpTestData))]
    public void NormalizeTest(string input, string outputExpected)
    {
        var result = _palindromeService.Normalize(input);

        Assert.Equal(outputExpected, result);
    }
}
