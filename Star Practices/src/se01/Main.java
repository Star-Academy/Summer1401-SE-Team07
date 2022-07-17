package se01;

import java.io.File;
import java.nio.file.Paths;
import java.util.Scanner;
import java.util.Set;


public class Main {

    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        System.out.println("please enter a folder to search at (leave blank for default folder):");
        String folder_path = scn.nextLine();
        if (folder_path == "") {
            folder_path = Paths.get(".", "Summer1401-SE-Team07", "Files").toString();
        }
        // File files = new File(folder_path).listFiles();
        File files = new File(folder_path);

        System.out.println("please enter a query to search for:");
        String Query = scn.nextLine();

        FileReaderClass Read_Files = new FileReaderClass(files);
        InvertedIndex invertedIndex = new InvertedIndex(Read_Files.get_tokens());

        Set<Integer> result = invertedIndex.search(Query);
        if (result !=null) {
            for (int index : result) {
                System.out.println(Read_Files.get_files().get(index));
            }
        }

        scn.close();
    }


}