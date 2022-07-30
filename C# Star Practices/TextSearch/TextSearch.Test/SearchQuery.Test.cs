using TextSearch.DataReader;

namespace TextSearch.Test;

public class SearchQueryTest
{
    private readonly SearchQuery _searchQuery;

    public SearchQueryTest()
    {
        _searchQuery = new SearchQuery(new List<string>() { "hello", "-world", "+wow" });
    }

    [Fact]
    public void SearchQueryConstructor_QueryWords_MakesWordListFields()
    {
        Assert.Equal(_searchQuery.MandatoryWords, new List<string>() { "hello" });
        Assert.Equal(_searchQuery.OptionalWords, new List<string>() { "wow" });
        Assert.Equal(_searchQuery.ExcludeWords, new List<string>() { "world" });
    }

    [Theory]
    [InlineData("BLSDFDSF", QueryType.MANDATORY)]
    [InlineData("+1", QueryType.OPTIONAL)]
    [InlineData("-BasgSF", QueryType.EXCLUDE)]
    public void GetQueryType_QueryWord_ReturnsQueryType(string query, QueryType expected)
    {
        Assert.Equal(_searchQuery.GetQueryType(query), expected);
    }
}