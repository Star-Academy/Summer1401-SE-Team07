package se01;

import java.util.Map;
import java.util.Set;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

public class InvertedIndex {

    private Map<String, Set<Integer>> index = new HashMap<String, Set<Integer>>();
    private int m_fileCount;

    // creating the inverted index
    public InvertedIndex(List<Pair<String, Integer>> tokens, int fileCount) {
        m_fileCount = fileCount;
        for (Pair<String, Integer> token : tokens) {
            if (index.get(token.getKey()) == null) {
                index.put(token.getKey(), new HashSet<Integer>());
            }
            index.get(token.getKey()).add(token.getValue());
        }
    }

    public Set<Integer> applySearchQuery(Set<String> mandatory, Set<String> optional, Set<String> exclude) {
        // Applies the search query to include all mandatory words, include at least one optional word, and exclude all exclude words.

        Set<Integer> result = new HashSet<>();
        Set<Integer> opt_result = new HashSet<>();
        for (int i = 0; i < m_fileCount; i++) {
            result.add(i);
        }
        
        // going through all the sets and applying appropriate search query
        for (String word : mandatory) {
            Set<Integer> docs = index.get(word);
            if (docs != null)
                result.retainAll(docs);
        }
        for (String word : exclude) {
            Set<Integer> docs = index.get(word);
            if (docs != null)
                result.removeAll(docs);
        }
        for (String word : optional) {
            Set<Integer> docs = index.get(word);
            if (docs != null)
                opt_result.addAll(docs);
        }
        // checking for empty optional queries
        if (!optional.isEmpty()) {
            result.retainAll(opt_result);
        }
        return result;
    }

    public Set<Integer> search(String Query) {
        Set<String> mandatory = new HashSet<String>();
        Set<String> optional = new HashSet<String>();
        Set<String> exclude = new HashSet<String>();

        String[] words = Query.split(" ");
        for (String word : words) {
            // Flag for mandatory, optional or exclude word and add to the respective set
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
