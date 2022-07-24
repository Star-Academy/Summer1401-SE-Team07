package textSearch;

import java.util.Map;
import java.util.Set;
import java.io.File;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

public class InvertedIndex {
    // Words that are used too often in english and take too much storage to index,
    // and are practically useless
    File stopWordsFile = new File("Files/stopwords.txt");
    private List<String> stopWords = FileReaderClass.readFile(stopWordsFile);

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

    private Set<Integer> getWordsDocs(Set<Integer> workingSet, Set<String> words, WordSetMode mode) {
        for (String word : words) {
            Set<Integer> docs = index.get(word);
            if (docs == null)
                continue;
            switch (mode) {
                case MANDATORY:
                    workingSet.retainAll(docs);
                    break;
                case OPTIONAL:
                    workingSet.addAll(docs);
                    break;
                case EXCLUDE:
                    workingSet.removeAll(docs);
                    break;
            }
        }
        return workingSet;
    }

    public Set<Integer> applySearchQuery(Set<String> mandatory, Set<String> optional, Set<String> exclude) {
        // Applies the search query to include all mandatory words, include at least one
        // optional word, and exclude all exclude words.
        Set<Integer> finalQueryDocs = new HashSet<>();
        Set<Integer> optionalWordsDocs = new HashSet<>();
        for (int i = 0; i < m_fileCount; i++) {
            finalQueryDocs.add(i);
        }

        // going through all the sets and applying appropriate search query
        finalQueryDocs = getWordsDocs(finalQueryDocs, mandatory, WordSetMode.MANDATORY);
        finalQueryDocs = getWordsDocs(finalQueryDocs, optional, WordSetMode.EXCLUDE);
        optionalWordsDocs = getWordsDocs(optionalWordsDocs, exclude, WordSetMode.OPTIONAL);

        // checking for empty optional queries
        if (!optional.isEmpty()) {
            finalQueryDocs.retainAll(optionalWordsDocs);
        }
        return finalQueryDocs;
    }

    private Pair<WordSetMode, String> flagWord(String word) {
        String[] splittedWord = word.split("[\\W]+");
        WordSetMode mode;
        // Check the first character of the word to determine the mode
        switch (word.charAt(0)) {
            case '+':
                mode = WordSetMode.OPTIONAL;
            case '-':
                mode = WordSetMode.EXCLUDE;
            default:
                mode = WordSetMode.MANDATORY;
        }
        word = splittedWord[splittedWord.length - 1];
        return new Pair<WordSetMode, String>(mode, word);
    }

    public Set<Integer> search(String Query) {
        Set<String> mandatory = new HashSet<String>();
        Set<String> optional = new HashSet<String>();
        Set<String> exclude = new HashSet<String>();

        String[] words = Query.split("\\s+");
        for (String word : words) {
            // Flag the uppercased word for mandatory, optional or exclude word and add to the respective set
            if (stopWords.contains(word)) {
                continue;
            }
            Pair<WordSetMode, String> flagged = flagWord(word.toUpperCase());
            switch (flagged.getKey()) {
                case MANDATORY:
                    mandatory.add(flagged.getValue());
                    break;
                case OPTIONAL:
                    optional.add(flagged.getValue());
                    break;
                case EXCLUDE:
                    exclude.add(flagged.getValue());
            }
        }
        Set<Integer> result = applySearchQuery(mandatory, optional, exclude);

        return result;
    }
}
