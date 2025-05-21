using Moq;

namespace PalindromeService.Tests.PalindromeServiceTests;

public class IsPalindromeTests
{
    private readonly IPalindromeService _palindromeService;
    private readonly Mock<ILogger> _loggerMock;

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
        { null!, true },
        { "z", true },
    };

    public static TheoryData<string, bool> CaseInsensitiveData = new TheoryData<string, bool>()
    {
        { "YoYOy", true },
        { "Panama", false },
        { "UFOtofu", true },
    };

    public IsPalindromeTests()
    {
        _loggerMock = new Mock<ILogger>();
        _palindromeService = new PalindromeService(_loggerMock.Object);
    }

    [Theory]
    [MemberData(nameof(BasicWordsData))]
    [MemberData(nameof(EdgeCasesData))]
    [MemberData(nameof(CaseInsensitiveData))]
    public void IsPalindromeTest(string input, bool isPalindromeExpected)
    {
        var result = _palindromeService.IsPalindrome(input);

        Assert.Equal(isPalindromeExpected, result);

        _loggerMock.Verify(
                logger => logger.Log(It.Is<string>(message => 
                        message.Contains($"Checking if '{input}' is a palindrome"))), 
                Times.Once);
        _loggerMock.Verify(
                logger => logger.Log(It.Is<string>(message => 
                        message.Contains($"Result for '{input}': {isPalindromeExpected}"))), 
                Times.AtMostOnce);
    }
}
