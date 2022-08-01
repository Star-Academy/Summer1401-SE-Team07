namespace TextSearch;

public interface ISearchQuery
{
    List<string> MandatoryWords { get; }
    List<string> OptionalWords { get; }
    List<string> ExcludeWords { get; }
    QueryType GetQueryType(string queryWord);
}