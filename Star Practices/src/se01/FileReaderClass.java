package se01;

import java.io.BufferedReader;
import java.io.File;
import java.io.FilenameFilter;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class FileReaderClass {

    private List<Pair<String, Integer>> tokens = new ArrayList<Pair<String, Integer>>();
    private List<File> m_files;

    

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
