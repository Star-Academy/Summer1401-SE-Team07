package se01;

import java.util.Map;
import java.util.Set;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;

public class InvertedIndex {

    private Map<String, Set<Integer>> index = new HashMap<String, Set<Integer>>();

    public InvertedIndex(List<Pair<String, Integer>> tokens) {
        for (Pair<String, Integer> token : tokens) {
            if (index.get(token.getKey()) == null) {
                index.put(token.getKey(), new HashSet<Integer>());
            }
            index.get(token.getKey()).add(token.getValue());
        }

    }

    public Set<Integer> search(String Query) {
        return index.get(Query.toUpperCase());
    }
}
