namespace TextSearch;

public class QueryHandler : IQueryHandler
{
    private ISearcher _searcher;

    public QueryHandler(ISearcher engine)
    {
        this._searcher = engine;
    }

    public HashSet<string> HandleQuery(ISearchQuery query)
    {
        var universalSet = _searcher.DocNameToTokenizedWords.Keys.ToHashSet();
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