using TextSearch.DataReader;

namespace TextSearch.Test;

public class queryHandlerTest
{
    [Fact]
    public void HandleQuery_1MandatoryNoOptionalNoExclude_ReturnsHello()
    {
        // Arrange
        var mockedSearcher = new Mock<ISearcher>();
        mockedSearcher.Setup(x => x.Search("hello")).Returns(new HashSet<string> { "hello" });
        mockedSearcher.Setup(x => x.DocNameToTokenizedWords).Returns(new Dictionary<string, List<string>> {
            { "hello", new List<string> { "hello" } }
        });
        var mockedSearchQuery = new Mock<ISearchQuery>();
        mockedSearchQuery.Setup(x => x.MandatoryWords).Returns(new List<string> { "hello" });
        mockedSearchQuery.Setup(x => x.OptionalWords).Returns(new List<string> { "" });
        mockedSearchQuery.Setup(x => x.ExcludeWords).Returns(new List<string> { "" });
        // Act
        var actual = new QueryHandler(mockedSearcher.Object).HandleQuery(mockedSearchQuery.Object);
        // Assert
        actual.Should().BeEquivalentTo(new HashSet<string> { "hello" });
    }
}