package textSearch;

import java.util.ArrayList;
import java.util.List;

public class Tokenizer {

    // blacklist characters to remove from a word
    private final static char[] blacklist = "!$^()_+=-.;,[]{}\'\"".toCharArray();
    private final List<Pair<String, Integer>> tokens = new ArrayList<Pair<String, Integer>>();

    public Tokenizer(List<Pair<String, Integer>> words) {
        for (Pair<String, Integer> word : words) {
            String trimmedWord = trimWord(word.getKey());
            tokens.add(new Pair<String, Integer>(trimmedWord, word.getValue()));
        }
    }

    private String trimWord(String word) {
        // remove blacklist characters
        word = word.toUpperCase();
        for (char c : blacklist) {
            word = word.replace(c, '\0');
        }
        return word;
    }

    public List<Pair<String, Integer>> getTokens() {
        return new ArrayList<Pair<String, Integer>>(tokens);
    }
}
