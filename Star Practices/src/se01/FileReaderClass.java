package se01;

import java.io.BufferedReader;
import java.io.File;
import java.io.FilenameFilter;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class FileReaderClass {
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

    // blacklist characters to remove from a word
    private char[] blacklist = "!$^()_+=-.;,[]{}\'\"".toCharArray();

    private List<Pair<String, Integer>> tokens = new ArrayList<Pair<String, Integer>>();
    private List<File> m_files;

    private String trimWord(String _word){
        // remove blacklist characters
        String word = _word.toUpperCase();
        for (char c : blacklist)
            word = word.replace(c, '\0');
        return word;
    }

    private void readFile(File file, int index) {
        // Reads a file and adds the tokens to the list
        try {
            BufferedReader reader = new BufferedReader(new FileReader(file));
            for (String line = reader.readLine(); line != null; line = reader.readLine()) {
                for (String _word : line.split("\\W+")) {
                    String word = trimWord(_word);
                    if (stopWords.contains(word))
                        continue;
                    Pair<String, Integer> token = new Pair<String, Integer>(word, index);
                    tokens.add(token);
                }
            }
            reader.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public FileReaderClass(File directory) {
        // Creates a list of files in the directory, and reads them
        List<File> files = ReadDirectory(directory);
        m_files = files;
        for (int i = 0; i < files.size(); i++) {
            File file = files.get(i);
            readFile(file, i);
            
        }
    }

    private FilenameFilter txtFilter = new FilenameFilter() {
        // Filters out all files that are not .txt files
        public boolean accept(File dir, String name) {
            return name.toLowerCase().endsWith(".txt");
        }
    };

    public List<File> ReadDirectory(File directory) {
        // Returns a list of text files in the directory
        File[] files = directory.listFiles(txtFilter);
        return Arrays.asList(files);
    }

    public List<Pair<String, Integer>> get_tokens() {
        // Returns the list of tokens
        return new ArrayList<Pair<String, Integer>>(tokens);
    }

    public List<File> get_files() {
        // Returns the list of files
        return new ArrayList<File>(m_files);
    }

    public int get_file_count() {
        // Returns the number of files
        return m_files.size();
    }
}
