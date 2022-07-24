package textSearch;

import java.io.File;
import java.nio.file.Paths;
import java.util.List;
import java.util.Scanner;
import java.util.Set;

public class Main {

    private static InvertedIndex invertedIndexHandler(FileReaderClass Read_Files) {
        // generating the tokens and reverse index
        List<Pair<String, Integer>> words = Read_Files.getWords();
        Tokenizer tokenizer = new Tokenizer(words);
        InvertedIndex invertedIndex = new InvertedIndex(tokenizer.getTokens(), Read_Files.getFileCount());

        return invertedIndex;
    }

    private static FileReaderClass folderReaderHandler(String folderPath) {
        if (folderPath.isBlank()) {
            folderPath = Paths.get(".", "Summer1401-SE-Team07", "Files").toString(); // creating the default folder
        }
        File mainDir = new File(folderPath);
        FileReaderClass Read_Files = new FileReaderClass(mainDir);
        return Read_Files;
    }

    private static void inputHandler(String folderPath, String query) {
        // First read the files in the folder
        FileReaderClass Read_Files = folderReaderHandler(folderPath);
        // Then generate inverted index object and search in it
        InvertedIndex invertedIndex = invertedIndexHandler(Read_Files);
        Set<Integer> result = invertedIndex.search(query);
        // Printing files matching the search query
        if (result != null) {
            for (int index : result) {
                System.out.println(Read_Files.getFiles().get(index));
            }
        }
    }

    public static void main(String[] args) {
        Scanner inputScanner = new Scanner(System.in);

        // getting the folder and query from user
        System.out.println("please enter a folder to search at (leave blank for default folder):");
        String folderPath = inputScanner.nextLine();

        System.out.println("please enter a query to search for:");
        String query = inputScanner.nextLine();
        inputScanner.close();

        inputHandler(folderPath, query);
    }
}