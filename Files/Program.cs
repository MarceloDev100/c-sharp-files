namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *   Stream is a a data flow. It's common to transmit data sequence.
             * 
              ****** FileStream ****** 
              *
              -Provides a stream associated with a file allowing reading and writing operations.
              -Binary data support
              Instantiation:
              - Many constructors
              - File/ FileInfo

              ****** StreamReader ****** 
              *
              - It's a stream capable of reading characters from a binary stream(ex: FileStream).
              - Data support in text format.
              Instantiation:
              - Many constructors.
              - File/ FileInfo
             */

            string path = @"c:\temp\file1.txt";

            ReadFileMode1(path);
            ReadFileMode2(path);
            Console.WriteLine("-----------------------");
            ReadFileAllLines(path);
        }

        static void ReadFileMode1(string path)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(path, FileMode.Open);
                sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        static void ReadFileMode2(string path)
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(path);
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        static void ReadFileAllLines(string path)
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }
}