using TextSearch.DataReader;

namespace TextSearch.Test;

public class TokenizerTest
{
    private readonly Tokenizer _tokenizer;

    public TokenizerTest()
    {
        _tokenizer = new Tokenizer();
    }

    [Theory]
    [InlineData("", new string[] { "" })]
    [InlineData("hello.", new string[] { "HELLO" })]
    [InlineData("hello!! wOrld.", new string[] { "HELLO", "WORLD" })]
    public void Tokenize_RawText_ReturnsTokenizedWords(string rawText, string[] expected)
    {
        // Arrange
        var mockedDataReader = new Mock<IDataReader>();
        mockedDataReader.Setup(reader => reader.ReadData(It.IsAny<string>())).Returns(rawText);
        // Act
        var actual = _tokenizer.Tokenize(mockedDataReader.Object.ReadData(""));
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TokenizeFolder_MockFiles_ReturnsTokenizedData()
    {
        // Arrange
        var mockedDataReader = new Mock<IDataReader>();
        mockedDataReader.Setup(reader => reader.ReadFolder(It.IsAny<string>())).Returns(new DataDict(
            new Dictionary<string, string>() { { "test.txt", "hello world." } }
        ));
        // Act
        var actual = _tokenizer.TokenizeData(mockedDataReader.Object.ReadFolder(""));
        // Assert
        actual.Should().BeEquivalentTo(new Dictionary<string, List<string>>() {
            { "test.txt", new List<string>() { "HELLO", "WORLD" } }
        });
    }
}