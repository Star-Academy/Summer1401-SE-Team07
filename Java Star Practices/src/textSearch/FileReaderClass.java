package textSearch;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class FileReaderClass {

    private List<Pair<String, Integer>> words = new ArrayList<Pair<String, Integer>>();

    private List<File> m_files;

    public static List<String> readFile(File file) {
        // read a file and return a list of words
        List<String> words = new ArrayList<String>();
        try {
            BufferedReader reader = new BufferedReader(new FileReader(file));
            for (String line = reader.readLine(); line != null; line = reader.readLine()) {
                for (String word : line.split("\\W+")) {
                    words.add(word);
                }
            }
            reader.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return words;
    }

    private void indexFileWords(File file, int index) {
        // Reads a file and adds the tokens to the list
        List<String> wordList = readFile(file);
        for (String word : wordList) {
            words.add(new Pair<String, Integer>(word, index));
        }
    }

    public FileReaderClass(File directory) {
        // Creates a list of files in the directory, and reads them
        List<File> files = ReadDirectory(directory);
        m_files = files;
        for (int i = 0; i < files.size(); i++) {
            File file = files.get(i);
            indexFileWords(file, i);
        }
    }

    private List<File> ReadDirectory(File directory) {
        if (!directory.exists())
            return new ArrayList<File>();
        // Returns a list of text files in the directory
        File[] files = directory.listFiles();
        return Arrays.asList(files);
    }

    public List<Pair<String, Integer>> getWords() {
        return new ArrayList<Pair<String, Integer>>(words);
    }

    public List<File> getFiles() {
        return new ArrayList<File>(m_files);
    }

    public int getFileCount() {
        return m_files.size();
    }
}
