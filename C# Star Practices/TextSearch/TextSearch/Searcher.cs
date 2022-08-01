namespace TextSearch;
public class Searcher : ISearcher
{

    public Dictionary<string, List<string>> DocNameToTokenizedWords { get; }
    public Dictionary<string, HashSet<string>> WordToDocName { get; }

    public Searcher()
    {
        DocNameToTokenizedWords = new Dictionary<string, List<string>>();
        WordToDocName = new Dictionary<string, HashSet<string>>();
    }

    private void IndexWord(string word, string docName)
    {
        if (!WordToDocName.ContainsKey(word))
        {
            WordToDocName.Add(word, new HashSet<string>());
        }
        WordToDocName[word].Add(docName);
    }

    private void IndexWords(List<string> words, string docName)
    {
        words.ForEach(word => IndexWord(word, docName));
    }

    public void IndexTokenizedData(Dictionary<string, List<string>> newDocs)
    {
        newDocs.ToList().ForEach(doc =>
        {
            DocNameToTokenizedWords.Add(doc.Key, doc.Value);
            IndexWords(doc.Value, doc.Key);
        });
    }

    public HashSet<string> Search(string word)
    {
        return WordToDocName.ContainsKey(word) ? WordToDocName[word] : new HashSet<string>();
    }

}
