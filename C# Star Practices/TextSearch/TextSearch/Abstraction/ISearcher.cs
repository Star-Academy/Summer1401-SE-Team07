namespace TextSearch;

public interface ISearcher
{
    Dictionary<string, List<string>> DocNameToTokenizedWords { get; }
    Dictionary<string, HashSet<string>> WordToDocName { get; }
    void IndexTokenizedData(Dictionary<string, List<string>> newDocs);
    HashSet<string> Search(string word);
}