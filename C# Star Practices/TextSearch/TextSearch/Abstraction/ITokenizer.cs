
using TextSearch.DataReader;

namespace TextSearch;

public interface ITokenizer
{
    List<string> Tokenize(string contents);
    Dictionary<string, List<string>> TokenizeData(DataDict docNameToWords);
}