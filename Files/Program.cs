namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                ******* Directory and DirectoryInfo ******* 
               
                - Folders operations (create, enumerate, get files, etc)

                => Directory:  static members (simple, but performs security check for each operation).
                => DirectoryInfo: instance members
             */


            // Tasks
            // - List folders from a known folder
            // - List files from a known folder
            // - Create a folder


            // - Folder structure
            /*
             *                                     (Folders)        (Files)
               c: ->  temp ->    myfolder  ->       docs          doc1.txt and doc2.txt
                                                    notes         note1.txt and note2.txt
                                    |
                                    V
                
                                  (Files)
                                 file1.txt
                                 file2.txt
             */


            string path = @"c:\temp\myfolder";

            try
            {
                // List all subfolders from myfolder
                // Here there's a mask for searching : any filename and any extension.
                var folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories) ;
                Console.WriteLine("FOLDERS: ");
                foreach (string s in folders)
                {
                    Console.WriteLine(s);
                }

                // List all files from myfolder
                var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES: ");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

                // Create a folder
                // Suppose you want to create a new folder from myfolder.
                Directory.CreateDirectory(path + @"\newFolder");

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}