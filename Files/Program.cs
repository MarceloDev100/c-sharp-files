namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               "Using blocks"

              -Simplified syntax that garantees that IDisposable objects will be closed.
              -IDisposable objects are NOT managed by the CLR. They have to be manually closed.
              
             */

            string path = @"c:\temp\file1.txt";

            // Instantiated resources will be automatically closed.
            // "Using blocks" can be nested.
            // "Using blocks" will not handle exceptions. If you want to handle it, it must
            // have a try/catch block.

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {

                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("--------------------------------------------");

            // Other way instead of using nested blocks 

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}