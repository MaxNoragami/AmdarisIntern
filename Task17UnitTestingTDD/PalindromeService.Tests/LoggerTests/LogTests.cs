using Moq;

namespace PalindromeService.Tests.LoggerTests;

public class LogTests
{
    [Fact]
    public void LogExceptionHandlingWithSafeLoggerTest()
    {
        // Arrange
        var unsafeLoggerMock = new Mock<ILogger>();
        unsafeLoggerMock.Setup(logger => logger.Log(It.IsAny<string>()))
            .Throws(new IOException("Simulated error while writing to file."));

        var safeLogger = new SafeLogger(unsafeLoggerMock.Object);

        var palindromeServiceSafe = new PalindromeService(safeLogger);

        // Act
        var result = palindromeServiceSafe.IsPalindrome("Murder for a jar of red rum.");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void LogExceptionHandlingWithUnsafeLoggerTest()
    {
        // Arrange
        var unsafeLoggerMock = new Mock<ILogger>();
        unsafeLoggerMock.Setup(logger => logger.Log(It.IsAny<string>()))
            .Throws(new IOException("Simulated error while writing to file."));

        var palindromeServiceUnsafe = new PalindromeService(unsafeLoggerMock.Object);

        // Act
        var exception = Record.Exception(() => 
            palindromeServiceUnsafe.IsPalindrome("Was it a car or a cat I saw?"));

        // Assert
        Assert.Multiple(
            () => Assert.NotNull(exception),
            () => Assert.IsType<IOException>(exception),
            () => Assert.Equal("Simulated error while writing to file.", exception.Message)
        );
    }
}
