namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               StreamWriter
               - It's a stream capable of writing characters from a binary stream (E.G. FileStream).
               - Data support in text format.

               - Instantiation:
                   -Several constructors
                   -File/FileInfo
                         - CreateText(path)
                         - AppendText(String)
         
             */


            /*
               Read all content from file1 and save it in file2 in an uppercase format .
             */
            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using(StreamWriter sr = File.AppendText(targetPath))
                {
                    foreach(string line in lines)
                    {
                        sr.WriteLine(line.ToUpper());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}