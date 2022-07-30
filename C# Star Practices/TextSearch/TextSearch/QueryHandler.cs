namespace TextSearch;

public class QueryHandler
{
    private Searcher _searcher;

    public void SetIndex(Searcher engine)
    {
        this._searcher = engine;
    }

    public QueryHandler(Searcher engine)
    {
        this._searcher = engine;
    }

    public HashSet<string> HandleQuery(SearchQuery query)
    {
        var universalSet = new HashSet<string>(_searcher.DocNameToTokenizedWords.Keys);
        var answer = GetIntersectionSet(query.MandatoryWords, universalSet);
        if (query.OptionalWords.Any())
        {
            answer.IntersectWith(GetUnionSet(query.OptionalWords));
        }

        answer.RemoveWhere(p => GetUnionSet(query.ExcludeWords).Contains(p));
        return answer;
    }

    private HashSet<string> GetUnionSet(List<string> words)
    {
        var set = new HashSet<string>();
        foreach (var word in words)
        {
            set.UnionWith(_searcher.Search(word));
        }

        return set;
    }

    private HashSet<string> GetIntersectionSet(List<string> words, HashSet<string> universalSet)
    {
        HashSet<string> set = new HashSet<string>(universalSet);
        foreach (string word in words)
        {
            set.IntersectWith(_searcher.Search(word));
        }

        return set;
    }
}