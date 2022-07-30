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
    [InlineData("hello! wOrld.", new string[] { "HELLO", "WORLD" })]
    public void Tokenize_RawText_ReturnsTokenizedWords(string rawText, string[] expected)
    {
        var mockedDataReader = new Mock<IDataReader>();
        mockedDataReader.Setup(reader => reader.ReadData(It.IsAny<string>())).Returns(rawText);
        var actual = _tokenizer.Tokenize(mockedDataReader.Object.ReadData(""));
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TokenizeFolder_MockFiles_ReturnsTokenizedData()
    {
        var mockedDataReader = new Mock<FileReader>();
        mockedDataReader.Setup(reader => reader.ReadFolder(It.IsAny<string>())).Returns(new DataDict(
            new Dictionary<string, string>() { { "test.txt", "hello world." } }
        ));

        var actual = _tokenizer.TokenizeData(mockedDataReader.Object.ReadFolder(""));

        Assert.Equal(actual, new Dictionary<string, List<string>>() {
            { "test.txt", new List<string>() { "HELLO", "WORLD" } }
        });
    }
}