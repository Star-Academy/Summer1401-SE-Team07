namespace TextSearch;

public class SearchQuery
{
    public List<string> MandatoryWords { get; }
    public List<string> OptionalWords { get; }
    public List<string> ExcludeWords { get; }

    public QueryType GetQueryType(string queryWord)
    {
        switch (queryWord.Substring(0, 1))
        {
            case "-":
                return QueryType.EXCLUDE;
            case "+":
                return QueryType.OPTIONAL;
            default:
                return QueryType.MANDATORY;
        }
    }

    public SearchQuery(List<string> tokenizedWords)
    {
        MandatoryWords = new List<string>();
        OptionalWords = new List<string>();
        ExcludeWords = new List<string>();

        tokenizedWords.ForEach(word =>
        {
            switch (GetQueryType(word))
            {
                case QueryType.MANDATORY:
                    MandatoryWords.Add(word);
                    break;
                case QueryType.OPTIONAL:
                    OptionalWords.Add(word.Substring(1));
                    break;
                case QueryType.EXCLUDE:
                    ExcludeWords.Add(word.Substring(1));
                    break;
            }
        });
    }
}