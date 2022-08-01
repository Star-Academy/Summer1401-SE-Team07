namespace TextSearch;

public interface IQueryHandler
{
    HashSet<string> HandleQuery(ISearchQuery query);
}