package textSearch;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class FileReaderClass {

    private List<Pair<String,Integer>> words = new ArrayList<Pair<String,Integer>>();

    private List<File> m_files;


    private void readFile(File file, int index) {
        // Reads a file and adds the tokens to the list
        try {
            BufferedReader reader = new BufferedReader(new FileReader(file));
            for (String line = reader.readLine(); line != null; line = reader.readLine()) {
                for (String _word : line.split("\\W+")) {
                    words.add(new Pair<String,Integer>(_word, index));
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


    private List<File> ReadDirectory(File directory) {
        // Returns a list of text files in the directory
        File[] files = directory.listFiles();
        return Arrays.asList(files);
    }

    public ArrayList<Pair<String, Integer>> getWords() {
        // Returns the list of tokens
        return new ArrayList<Pair<String,Integer>>(words);
    }

    public List<File> getFiles() {
        // Returns the list of files
        return new ArrayList<File>(m_files);
    }

    public int getFileCount() {
        // Returns the number of files
        return m_files.size();
    }
}
