package se01;

import java.io.BufferedReader;
import java.io.File;
import java.io.FilenameFilter;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class FileReaderClass {

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
    private char[] blacklist = "!$^()_+=-.;,[]{}\'\"".toCharArray();

    private List<Pair<String,Integer>> tokens = new ArrayList<Pair<String,Integer>>();
    private List<File> m_files;

    public FileReaderClass(File directory) {
        List<File> files = ReadDirectory(directory);
        m_files = files;
        for (int i = 0; i < files.size(); i++) {
            File file = files.get(i);
            try {
                BufferedReader reader = new BufferedReader(new FileReader(file));
                for (String line = reader.readLine(); line != null; line = reader.readLine()) {
                    for (String _word : line.split("\\W+")) {
                        String word = _word.toUpperCase();
                        for (char c : blacklist)
                            word = word.replace(c, '\0');
                        if (stopWords.contains(word))
                            continue;
                        Pair<String,Integer> token = new Pair<String,Integer>(word, i);
                        tokens.add(token);
                    }
                }
                reader.close();

            } catch (Exception e) {
                e.printStackTrace();
            }

        }

    }

    private FilenameFilter txtFilter = new FilenameFilter() {
        public boolean accept(File dir, String name) {
            return name.toLowerCase().endsWith(".txt");
        }
    };

    public List<File> ReadDirectory(File directory) {
        File[] files = directory.listFiles(txtFilter);
        return Arrays.asList(files);
    }

    public List<Pair<String,Integer>> get_tokens() {
        return new ArrayList<Pair<String,Integer>>(tokens);
    }

    public List<File> get_files() {
        return new ArrayList<File>(m_files);
    }
}
