using System.Text.RegularExpressions;
using TextSearch.DataReader;

namespace TextSearch;

public class Tokenizer : ITokenizer
{
    private const string NonWordsRegex = "[^\\w\\s]";

    public List<string> Tokenize(string contents)
    {
        // remove all non-word characters and convert to upper case
        contents = Regex.Replace(contents, NonWordsRegex, "");
        return new List<string>(Regex.Split(contents.ToUpper(), "\\s+"));
    }

    public Dictionary<string, List<string>> TokenizeData(DataDict docNameToWords)
    {
        var docNameToTokenizedWords = new Dictionary<string, List<string>>();
        foreach (var docName in docNameToWords.Keys)
        {
            var docContent = docNameToWords[docName];
            docNameToTokenizedWords.Add(docName, Tokenize(docContent));
        }
        return docNameToTokenizedWords;
    }
}