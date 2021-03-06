package se01;

import java.io.File;
import java.nio.file.Paths;
import java.util.Scanner;
import java.util.Set;


public class Main {

    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        // getting the folder and query from user
        System.out.println("please enter a folder to search at (leave blank for default folder):");
        String folder_path = scn.nextLine();
        if (folder_path == "") {
            folder_path = Paths.get(".", "Summer1401-SE-Team07", "Files").toString(); // creating the default folder path
        }
        File files = new File(folder_path);

        System.out.println("please enter a query to search for:");
        String Query = scn.nextLine();


        // creating the tokens and revers index
        FileReaderClass Read_Files = new FileReaderClass(files);
        InvertedIndex invertedIndex = new InvertedIndex(Read_Files.get_tokens(), Read_Files.get_file_count());

        // making the search call
        Set<Integer> result = invertedIndex.search(Query);
        
        // printing files matching the search query
        if (result !=null) {
            for (int index : result) {
                System.out.println(Read_Files.get_files().get(index));
            }
        }

        scn.close();
    }


}