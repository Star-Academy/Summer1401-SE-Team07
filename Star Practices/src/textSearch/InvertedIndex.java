package textSearch;

import java.util.Map;
import java.util.Set;
import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

public class InvertedIndex {
    // Words that are used too often in english and take too much storage to index,
    // and are practically useless
    private List<String> stopWords = Arrays.asList("a", "able", "about",
            "across", "after", "all", "almost", "also", "am", "among", "an",
            "and", "any", "are", "as", "at", "be", "because", "been", "but",
            "by", "can", "cannot", "could", "dear", "did", "do", "does",
            "either", "else", "ever", "every", "for", "from", "get", "got",
            "had", "has", "have", "he", "her", "hers", "him", "his", "how",
            "however", "i", "if", "in", "into", "is", "it", "its", "just",
            "least", "let", "like", "likely", "may", "me", "might", "most",
            "must", "my", "neither", "no", "nor", "not", "of", "off", "often",
            "on", "only", "or", "other", "our", "own", "rather", "said", "say",
            "says", "she", "should", "since", "so", "some", "than", "that",
            "the", "their", "them", "then", "there", "these", "they", "this",
            "tis", "to", "too", "twas", "us", "wants", "was", "we", "were",
            "what", "when", "where", "which", "while", "who", "whom", "why",
            "will", "with", "would", "yet", "you", "your");

    private Map<String, Set<Integer>> index = new HashMap<String, Set<Integer>>();
    private int m_fileCount;

    // creating the inverted index
    public InvertedIndex(List<Pair<String, Integer>> tokens, int fileCount) {
        m_fileCount = fileCount;
        for (Pair<String, Integer> token : tokens) {
            if (stopWords.contains(token.getKey())) {
                continue;
            }
            if (index.get(token.getKey()) == null) {
                index.put(token.getKey(), new HashSet<Integer>());
            }
            index.get(token.getKey()).add(token.getValue());
        }
    }

    public Set<Integer> applySearchQuery(Set<String> mandatory, Set<String> optional, Set<String> exclude) {
        // Applies the search query to include all mandatory words, include at least one optional word, and exclude all exclude words.
        Set<Integer> finalQueryDocs = new HashSet<>();
        Set<Integer> optionalWordsDocs = new HashSet<>();
        for (int i = 0; i < m_fileCount; i++) {
            finalQueryDocs.add(i);
        }
        
        // going through all the sets and applying appropriate search query
        for (String word : mandatory) {
            Set<Integer> docs = index.get(word);
            if (docs != null)
                finalQueryDocs.retainAll(docs);
        }
        for (String word : exclude) {
            Set<Integer> docs = index.get(word);
            if (docs != null)
                finalQueryDocs.removeAll(docs);
        }
        for (String word : optional) {
            Set<Integer> docs = index.get(word);
            if (docs != null)
                optionalWordsDocs.addAll(docs);
        }
        // checking for empty optional queries
        if (!optional.isEmpty()) {
            finalQueryDocs.retainAll(optionalWordsDocs);
        }
        return finalQueryDocs;
    }

    public Set<Integer> search(String Query) {
        Set<String> mandatory = new HashSet<String>();
        Set<String> optional = new HashSet<String>();
        Set<String> exclude = new HashSet<String>();

        String[] words = Query.split(" ");
        for (String word : words) {
            // Flag for mandatory, optional or exclude word and add to the respective set
            if(stopWords.contains(word)){
                continue;
            }
            word = word.toUpperCase();
            if (word.startsWith("+")) {
                word = word.substring(1);
                optional.add(word);
            } else if (word.startsWith("-")) {
                word = word.substring(1);
                exclude.add(word);
            } else {
                mandatory.add(word);
            }
        }
        Set<Integer> result = applySearchQuery(mandatory, optional, exclude);

        return result;
    }
}
