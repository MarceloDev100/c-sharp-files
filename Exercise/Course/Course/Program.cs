using Course.Entities;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string sourcePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                string sourceFolderPath = Path.GetDirectoryName(sourcePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] items = line.Split(",");
                        string name = items[0];
                        double price = double.Parse(items[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(items[2]);

                        Product p = new Product(name, price, quantity);

                        sw.Write(p.Name);
                        sw.Write(",");
                        sw.WriteLine(p.Total().ToString("F2", CultureInfo.InvariantCulture));

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected exception!");
                Console.WriteLine(e.Message);
            }
        }
    }
}